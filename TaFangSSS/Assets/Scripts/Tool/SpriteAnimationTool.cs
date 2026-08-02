// 文件名: SpriteAnimationTool.cs
// 路径: Assets/Editor/
// 功能: 从序列帧文件夹生成图集、动画剪辑和动画控制器，支持拖拽文件夹到输入框

using UnityEngine;
using UnityEditor;
using UnityEditor.U2D;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine.U2D;

public class SpriteAnimationTool : EditorWindow
{
    private string folderPath = "";
    private float frameRate = 30f;
    private int atlasSize = 16384;
    private bool isImageAnimation = false; // 新增：是否生成Image动画

    [MenuItem("Tools/生成动画")]
    public static void ShowWindow()
    {
        GetWindow<SpriteAnimationTool>("生成序列帧动画");
    }

    private void OnGUI()
    {
        GUILayout.Label("序列帧动画生成器", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        // 选择文件夹（支持拖拽）
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("序列帧文件夹", GUILayout.Width(100));
        
        // 文本输入框，用于显示和手动编辑路径
        folderPath = EditorGUILayout.TextField(folderPath);
        
        // 选择按钮
        if (GUILayout.Button("选择文件夹", GUILayout.Width(100)))
        {
            string selectedPath = EditorUtility.OpenFolderPanel("选择序列帧文件夹", "Assets", "");
            if (!string.IsNullOrEmpty(selectedPath))
            {
                folderPath = GetRelativePath(selectedPath);
                if (!AssetDatabase.IsValidFolder(folderPath))
                {
                    EditorUtility.DisplayDialog("错误", "选择的文件夹不在 Assets 目录下", "确定");
                    folderPath = "";
                }
            }
        }
        EditorGUILayout.EndHorizontal();

        // 接受拖拽文件夹到该区域
        Rect lastRect = GUILayoutUtility.GetLastRect();
        HandleDragDrop(lastRect);

        // 参数设置
        frameRate = EditorGUILayout.FloatField("帧率 (FPS)", frameRate);
        atlasSize = EditorGUILayout.IntPopup("图集最大尺寸", atlasSize,
            new string[] { "512", "1024", "2048", "4096", "8192", "16384" },
            new int[] { 512, 1024, 2048, 4096, 8192, 16384 });
        
        // 新增：动画类型选择复选框
        isImageAnimation = EditorGUILayout.Toggle("生成Image动画", isImageAnimation);
        if (isImageAnimation)
        {
            EditorGUILayout.HelpBox("将生成适用于 UI Image 的动画（绑定 sprite 属性）", MessageType.Info);
        }
        else
        {
            EditorGUILayout.HelpBox("将生成适用于 SpriteRenderer 的动画（绑定 m_Sprite 属性）", MessageType.Info);
        }

        EditorGUILayout.Space();
        if (GUILayout.Button("生成动画", GUILayout.Height(30)))
        {
            GenerateAnimation();
        }
    }

    /// <summary>
    /// 处理拖拽文件夹到指定区域
    /// </summary>
    private void HandleDragDrop(Rect area)
    {
        Event evt = Event.current;
        if (!area.Contains(evt.mousePosition))
            return;

        switch (evt.type)
        {
            case EventType.DragUpdated:
            case EventType.DragPerform:
                // 检查拖拽对象是否是文件夹
                if (DragAndDrop.objectReferences.Length == 1)
                {
                    string path = AssetDatabase.GetAssetPath(DragAndDrop.objectReferences[0]);
                    if (AssetDatabase.IsValidFolder(path))
                    {
                        DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
                        if (evt.type == EventType.DragPerform)
                        {
                            DragAndDrop.AcceptDrag();
                            folderPath = path;
                            evt.Use();
                        }
                    }
                }
                break;
        }
    }

    /// <summary>
    /// 将绝对路径转换为 Assets 相对路径
    /// </summary>
    private string GetRelativePath(string absolutePath)
    {
        if (absolutePath.StartsWith(Application.dataPath))
        {
            return "Assets" + absolutePath.Substring(Application.dataPath.Length);
        }
        return absolutePath;
    }

    private void GenerateAnimation()
    {
        if (string.IsNullOrEmpty(folderPath))
        {
            EditorUtility.DisplayDialog("错误", "请先选择序列帧文件夹（可手动输入或拖拽）", "确定");
            return;
        }

        if (!AssetDatabase.IsValidFolder(folderPath))
        {
            EditorUtility.DisplayDialog("错误", "选择的文件夹无效\n请确保文件夹位于 Assets 目录下", "确定");
            return;
        }

        // 1. 获取文件夹内所有精灵，并进行自然排序
        string[] spriteGuids = AssetDatabase.FindAssets("t:Sprite", new[] { folderPath });
        List<Sprite> sprites = new List<Sprite>();

        foreach (string guid in spriteGuids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(assetPath);
            if (sprite != null && AssetDatabase.GetMainAssetTypeAtPath(assetPath) == typeof(Texture2D))
            {
                sprites.Add(sprite);
            }
        }

        sprites = sprites.OrderBy(s => s.name, new NaturalStringComparer()).ToList();

        if (sprites == null || sprites.Count == 0)
        {
            EditorUtility.DisplayDialog("错误", "该文件夹下没有找到精灵图片\n请确保图片 Texture Type 为 Sprite(2D and UI)", "确定");
            return;
        }

        // 2. 创建图集
        string folderName = new DirectoryInfo(folderPath).Name;
        string atlasPath = $"{folderPath}/{folderName}_Atlas.spriteatlas";

        if (AssetDatabase.LoadAssetAtPath<SpriteAtlas>(atlasPath) != null)
        {
            AssetDatabase.DeleteAsset(atlasPath);
            AssetDatabase.Refresh();
        }

        SpriteAtlas atlas = new SpriteAtlas();

        // 打包设置
        SpriteAtlasPackingSettings packingSettings = new SpriteAtlasPackingSettings()
        {
            enableRotation = false,
            enableTightPacking = false,
            padding = 2,
            blockOffset = 1,
        };
        atlas.SetPackingSettings(packingSettings);

        // 平台设置
        TextureImporterPlatformSettings platformSettings = new TextureImporterPlatformSettings()
        {
            name = "Standalone",
            maxTextureSize = atlasSize,
            format = TextureImporterFormat.Automatic,
        };
        atlas.SetPlatformSettings(platformSettings);

        // 将文件夹内所有纹理加入图集（处理多个独立图片文件的情况）
        Texture2D[] textures = sprites.Select(s => s.texture).Distinct().ToArray();
        atlas.Add(textures);

        AssetDatabase.CreateAsset(atlas, atlasPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        atlas = AssetDatabase.LoadAssetAtPath<SpriteAtlas>(atlasPath);

        // 获取图集内精灵
        Sprite[] atlasSprites = new Sprite[sprites.Count];
        for (int i = 0; i < sprites.Count; i++)
        {
            Sprite s = atlas.GetSprite(sprites[i].name);
            atlasSprites[i] = s != null ? s : sprites[i];
        }

        // 3. 生成动画剪辑
        AnimationClip clip = new AnimationClip();
        clip.frameRate = frameRate;
        clip.name = $"{folderName}_Anim";

        ObjectReferenceKeyframe[] keyFrames = new ObjectReferenceKeyframe[atlasSprites.Length];
        float timePerFrame = 1f / frameRate;
        for (int i = 0; i < atlasSprites.Length; i++)
        {
            keyFrames[i] = new ObjectReferenceKeyframe()
            {
                time = i * timePerFrame,
                value = atlasSprites[i]
            };
        }

        // 根据复选框选择不同的绑定路径
        if (isImageAnimation)
        {
            // 适用于 UnityEngine.UI.Image 的绑定
            // Image 组件的 sprite 属性路径是 "m_Sprite"
            // 但需要通过 typeof(Image) 来指定组件类型
            AnimationUtility.SetObjectReferenceCurve(clip,
                EditorCurveBinding.PPtrCurve("", typeof(UnityEngine.UI.Image), "m_Sprite"),
                keyFrames);
        }
        else
        {
            // 适用于 SpriteRenderer 的绑定（默认）
            AnimationUtility.SetObjectReferenceCurve(clip,
                EditorCurveBinding.PPtrCurve("", typeof(SpriteRenderer), "m_Sprite"),
                keyFrames);
        }

        string clipPath = $"{folderPath}/{clip.name}.anim";
        AssetDatabase.CreateAsset(clip, clipPath);

        // 4. 创建动画控制器
        string controllerPath = $"{folderPath}/{folderName}_Controller.controller";
        UnityEditor.Animations.AnimatorController controller =
            UnityEditor.Animations.AnimatorController.CreateAnimatorControllerAtPath(controllerPath);

        var rootStateMachine = controller.layers[0].stateMachine;
        var animState = rootStateMachine.AddState(clip.name);
        animState.motion = clip;
        rootStateMachine.defaultState = animState;

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        string animationType = isImageAnimation ? "Image" : "SpriteRenderer";
        EditorUtility.DisplayDialog("完成", $"动画生成成功！\n动画类型: {animationType}\n图集: {atlasPath}\n动画剪辑: {clipPath}\n控制器: {controllerPath}", "确定");
        EditorGUIUtility.PingObject(controller);
    }

    public class NaturalStringComparer : IComparer<string>
    {
        public int Compare(string a, string b)
        {
            string aPad = Regex.Replace(a, "[0-9]+", m => m.Value.PadLeft(10, '0'));
            string bPad = Regex.Replace(b, "[0-9]+", m => m.Value.PadLeft(10, '0'));
            return aPad.CompareTo(bPad);
        }
    }
}
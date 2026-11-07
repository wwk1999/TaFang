using System;
using System.Runtime.InteropServices;
using AOT;
using UnityEngine;
using Process = System.Diagnostics.Process;

/// <summary>
/// 老板键「遁形」：按下热键后游戏窗口隐匿至右下角系统托盘，仅留一枚托盘图标；
/// 单击托盘图标即刻现形复原。隐匿期间游戏继续挂机运行、声音自动静默。
/// 仅在 Windows 打包版生效，编辑器内自动禁用。
/// </summary>
public class 遁形 : XSingleton<遁形>
{
    [Header("老板键：按下后隐藏到右下角托盘")]
    public KeyCode 老板键 = KeyCode.B;
    [Header("托盘显示名称，留空则使用游戏名")]
    public string 托盘名称 = "洪荒之刷宝成圣";
    [Header("托盘图标文件名（.ico 格式，放在 StreamingAssets 目录下），留空则使用游戏图标")]
    public string 托盘图标文件名 = "icon.ico";

    // 托盘图标回调消息号（取 WM_APP 区段，避免与系统消息冲突）
    private const int 托盘回调消息 = 0x8000 + 0x51;
    private const int 托盘图标ID = 1;

    private const int SW_HIDE = 0;
    private const int SW_SHOW = 5;
    private const int SW_RESTORE = 9;
    private const int GWLP_WNDPROC = -4;
    private const int WM_GETICON = 0x007F;
    private const int WM_LBUTTONUP = 0x0202;
    private const int WM_LBUTTONDBLCLK = 0x0203;
    private const uint NIM_ADD = 0;
    private const uint NIM_DELETE = 2;
    private const int NIF_MESSAGE = 0x1;
    private const int NIF_ICON = 0x2;
    private const int NIF_TIP = 0x4;
    private static readonly IntPtr IDI_APPLICATION = new IntPtr(32512);

    private static IntPtr s_窗口句柄;
    private static IntPtr s_原窗口过程;
    private static IntPtr s_自加载图标;   // 从文件加载的托盘图标句柄，用完需手动销毁
    private static NOTIFYICONDATA s_托盘数据;
    private static bool s_托盘已添加;
    private static bool s_已隐藏;
    private static bool s_托盘待现形;   // 托盘点击标记，回到 Update 主循环再复原
    private static bool s_之前音频暂停;
    private static bool s_待隐藏;       // 全屏退回窗口化后延迟执行隐藏

    // 静态常驻引用，防止委托被 GC 回收后原生回调崩溃
    private static readonly WndProc委托 s_窗口过程 = 窗口过程钩子;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private static void 自动启动()
    {
        if (Application.platform != RuntimePlatform.WindowsPlayer) return;
        _ = S;
    }

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        // 隐匿后游戏窗口失去焦点，必须后台运行才能继续挂机并响应托盘点击
        Application.runInBackground = true;
    }

    private void Update()
    {
        if (s_待隐藏 && !Screen.fullScreen)
        {
            s_待隐藏 = false;
            执行隐匿();
            return;
        }
        if (s_托盘待现形)
        {
            s_托盘待现形 = false;
            现形();
            return;
        }
        // 输入框聚焦时不响应老板键，避免起名等打字场景误触隐匿
        if (Input.GetKeyDown(老板键) && !输入框聚焦中()) 遁去();
    }

    private static bool 输入框聚焦中()
    {
        var 事件系统 = UnityEngine.EventSystems.EventSystem.current;
        if (事件系统 == null) return false;
        var 选中 = 事件系统.currentSelectedGameObject;
        return 选中 != null && 选中.GetComponent<TMPro.TMP_InputField>() != null;
    }

    /// <summary>隐匿：窗口收入右下角托盘，声音静默，游戏继续挂机。</summary>
    private void 遁去()
    {
        if (s_已隐藏 || s_待隐藏) return;
        if (Screen.fullScreen)
        {
            // 独占全屏直接隐藏易异常，先退回窗口化，待切换完成后下一帧再隐藏
            s_待隐藏 = true;
            Screen.fullScreen = false;
            return;
        }
        执行隐匿();
    }

    private void 执行隐匿()
    {
        if (s_已隐藏) return;
        IntPtr 句柄 = Process.GetCurrentProcess().MainWindowHandle;
        if (句柄 == IntPtr.Zero) return;
        if (!挂载窗口钩子(句柄)) return;   // 钩子失败则放弃隐藏，避免窗口隐匿后无法复原
        if (!添加托盘图标(句柄)) return;
        s_之前音频暂停 = AudioListener.pause;
        AudioListener.pause = true;
        ShowWindow(句柄, SW_HIDE);
        s_已隐藏 = true;
    }

    /// <summary>现形：托盘图标消失，窗口复原并置于前台，声音恢复。</summary>
    private static void 现形()
    {
        if (!s_已隐藏) return;
        s_已隐藏 = false;
        if (s_托盘已添加)
        {
            Shell_NotifyIconW(NIM_DELETE, ref s_托盘数据);
            s_托盘已添加 = false;
        }
        销毁自加载图标();
        ShowWindow(s_窗口句柄, SW_SHOW);
        ShowWindow(s_窗口句柄, SW_RESTORE);
        SetForegroundWindow(s_窗口句柄);
        AudioListener.pause = s_之前音频暂停;
    }

    private static bool 挂载窗口钩子(IntPtr 句柄)
    {
        if (s_窗口句柄 == 句柄 && s_原窗口过程 != IntPtr.Zero) return true;   // 已挂载
        卸载窗口钩子();
        s_窗口句柄 = 句柄;
        s_原窗口过程 = IntPtr.Size == 8
            ? SetWindowLongPtr(句柄, GWLP_WNDPROC, s_窗口过程)
            : SetWindowLong32(句柄, GWLP_WNDPROC, s_窗口过程);
        return s_原窗口过程 != IntPtr.Zero;
    }

    private static void 卸载窗口钩子()
    {
        if (s_窗口句柄 == IntPtr.Zero || s_原窗口过程 == IntPtr.Zero) return;
        if (IntPtr.Size == 8) SetWindowLongPtr(s_窗口句柄, GWLP_WNDPROC, s_原窗口过程);
        else SetWindowLong32(s_窗口句柄, GWLP_WNDPROC, s_原窗口过程);
        s_原窗口过程 = IntPtr.Zero;
    }

    private bool 添加托盘图标(IntPtr 句柄)
    {
        销毁自加载图标();
        // 图标优先级：StreamingAssets 自定义 .ico → 游戏窗口自身图标 → 系统默认应用图标
        IntPtr 图标 = 加载自定义图标();
        if (图标 == IntPtr.Zero) 图标 = SendMessage(句柄, WM_GETICON, new IntPtr(1), IntPtr.Zero);        // ICON_BIG
        if (图标 == IntPtr.Zero) 图标 = SendMessage(句柄, WM_GETICON, IntPtr.Zero, IntPtr.Zero);   // ICON_SMALL
        if (图标 == IntPtr.Zero) 图标 = LoadIcon(GetModuleHandle(null), IDI_APPLICATION);

        string 提示 = string.IsNullOrEmpty(托盘名称) ? Application.productName : 托盘名称;
        if (提示.Length > 63) 提示 = 提示.Substring(0, 63);

        s_托盘数据 = new NOTIFYICONDATA
        {
            cbSize = Marshal.SizeOf(typeof(NOTIFYICONDATA)),
            hWnd = 句柄,
            uID = 托盘图标ID,
            uFlags = NIF_MESSAGE | NIF_ICON | NIF_TIP,
            uCallbackMessage = 托盘回调消息,
            hIcon = 图标,
            szTip = 提示,
        };
        s_托盘已添加 = Shell_NotifyIconW(NIM_ADD, ref s_托盘数据);
        return s_托盘已添加;
    }

    /// <summary>从 StreamingAssets 加载自定义 .ico 托盘图标，未配置或文件不存在时返回空句柄。</summary>
    private IntPtr 加载自定义图标()
    {
        if (string.IsNullOrEmpty(托盘图标文件名)) return IntPtr.Zero;
        string 路径 = System.IO.Path.Combine(Application.streamingAssetsPath, 托盘图标文件名);
        if (!System.IO.File.Exists(路径)) return IntPtr.Zero;
        // IMAGE_ICON=1，LR_LOADFROMFILE|LR_DEFAULTSIZE 从文件加载并按系统默认尺寸
        s_自加载图标 = LoadImage(IntPtr.Zero, 路径, 1, 0, 0, 0x00000010 | 0x00000040);
        return s_自加载图标;
    }

    private static void 销毁自加载图标()
    {
        if (s_自加载图标 == IntPtr.Zero) return;
        DestroyIcon(s_自加载图标);
        s_自加载图标 = IntPtr.Zero;
    }

    /// <summary>
    /// 托盘图标鼠标事件由主线程消息泵派发到此钩子，仅置标记，具体复原在 Update 执行，
    /// 避免在消息泵内直接调用 Unity API 引发重入问题。
    /// </summary>
    [MonoPInvokeCallback(typeof(WndProc委托))]
    private static IntPtr 窗口过程钩子(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam)
    {
        if (msg == 托盘回调消息)
        {
            long 鼠标消息 = lParam.ToInt64() & 0xFFFF;
            if (鼠标消息 == WM_LBUTTONUP || 鼠标消息 == WM_LBUTTONDBLCLK) s_托盘待现形 = true;
        }
        return CallWindowProc(s_原窗口过程, hWnd, msg, wParam, lParam);
    }

    private void OnApplicationQuit()
    {
        if (Application.platform != RuntimePlatform.WindowsPlayer) return;
        // 退出前务必删除托盘图标并还原窗口过程，否则托盘会残留幽灵图标
        if (s_托盘已添加)
        {
            Shell_NotifyIconW(NIM_DELETE, ref s_托盘数据);
            s_托盘已添加 = false;
        }
        销毁自加载图标();
        卸载窗口钩子();
    }

    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    private delegate IntPtr WndProc委托(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    [DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);
    [DllImport("user32.dll")]
    private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
    [DllImport("user32.dll")]
    private static extern IntPtr CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
    [DllImport("user32.dll", EntryPoint = "SetWindowLongPtrW", SetLastError = true)]
    private static extern IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, WndProc委托 dwNewLong);
    [DllImport("user32.dll", EntryPoint = "SetWindowLongPtrW", SetLastError = true)]
    private static extern IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong);
    [DllImport("user32.dll", EntryPoint = "SetWindowLongW", SetLastError = true)]
    private static extern IntPtr SetWindowLong32(IntPtr hWnd, int nIndex, WndProc委托 dwNewLong);
    [DllImport("user32.dll", EntryPoint = "SetWindowLongW", SetLastError = true)]
    private static extern IntPtr SetWindowLong32(IntPtr hWnd, int nIndex, IntPtr dwNewLong);
    [DllImport("user32.dll")]
    private static extern IntPtr LoadIcon(IntPtr hInstance, IntPtr lpIconName);
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern IntPtr LoadImage(IntPtr hInst, string lpszName, uint uType, int cxDesired, int cyDesired, uint fuLoad);
    [DllImport("user32.dll")]
    private static extern bool DestroyIcon(IntPtr hIcon);
    [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
    private static extern IntPtr GetModuleHandle(string lpModuleName);
    [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
    private static extern bool Shell_NotifyIconW(uint dwMessage, ref NOTIFYICONDATA lpData);

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    private struct NOTIFYICONDATA
    {
        public int cbSize;
        public IntPtr hWnd;
        public int uID;
        public int uFlags;
        public int uCallbackMessage;
        public IntPtr hIcon;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string szTip;
        public int dwState;
        public int dwStateMask;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string szInfo;
        public int uTimeoutOrVersion;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szInfoTitle;
        public int dwInfoFlags;
        public Guid guidItem;
        public IntPtr hBalloonIcon;
    }
}

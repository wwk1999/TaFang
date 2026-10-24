using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 肥料item : MonoBehaviour
{
    public Button bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI count;
    [NonSerialized] public 肥料Type 肥料Tyep;
    [NonSerialized] public QualityType QualityType;

    private void Start()
    {
        bg.onClick.AddListener(() =>
        {
            HeroWindowController.S.当前选择肥料 = 肥料Tyep;
            HeroWindowController.S.当前选择肥料品质 = QualityType;
            var 肥料icon = icon.sprite;
            Cursor.SetCursor(肥料icon.texture,
                new Vector2(肥料icon.texture.width * 0.5f, 肥料icon.texture.height * 0.5f),
                CursorMode.Auto);
            gameObject.SetActive(false);
        });
    }

    public void SetItem()
    {
        bg.image.sprite = ResourcesConfig.Get灵植背包格子(QualityType);
        icon.sprite = ResourcesConfig.Get肥料Icon(肥料Tyep, QualityType);
        name.text = 灵植园Config.肥料名[肥料Tyep];
        count.text = PlayerData.S.Get肥料数量(肥料Tyep, QualityType).ToString();
    }
}

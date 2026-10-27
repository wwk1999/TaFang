# 法器阶数制重构 · 任务清单

- [x] T1 `法器Config.cs`：法器Type 精简为 20 种，法器/法器打造Item/法器材料 增加 `品质`+`阶数`
- [x] T2 `法器Config.cs`：法器基础属性改 16 阶，`Get法器基础伤害(阶数, 品质)` 内乘品质倍率
- [x] T3 `法器Config.cs`：`法器Minmaxes` 改 16 阶 × 16 属性基础值（256 条）
- [x] T4 `法器Config.cs`：`Get打造法器材料(法器Type, 阶数)`、`Get法器Name`、`Get法器材料Name`、`Get阶数对应品质`
- [x] T5 `ResourcesConfig.cs`：法器/材料 Sprite 改 LoadAll 缓存 + `Get法器Sprite(Type, 阶数)`、`Get法器材料Sprite(Type, 阶数)`
- [x] T6 `PropConfig.cs`：材料枚举 `石1~16/铁1~16/羽1~16/砂1~16`，新增阶数解析与名称/品质/Info 兜底
- [x] T7 `道场Config.cs`：炼器室配置扩到 0~50 级，新增 `最高炼制阶数`
- [x] T8 `领主府.cs`：显示「最高炼器阶数」，满级取下一级加兜底
- [x] T9 炼器 UI：`法器打造panel/法器打造item/法器打造信息弹窗/打造item/法器打造itemImage` 全阶数化
- [x] T10 展示链路：`法器infoItem/法器信息弹窗/坊市/胜利弹窗/分解弹窗/装备背包/洗练/镶嵌/符文附魔` 名称与图标阶数化
- [x] T11 修复用户截图 10 条编译错误
- [x] T12 `法器附加属性item.cs`：显示 `count × 品质倍率`
- [x] T13 `坊市Config.cs`：自动购买 toast 名称带阶数
- [x] T14 静态扫尾 grep：`法器名Dic[` / `法器Minmaxes[` 旧键 / `PropQualityDic[材料]` 残留清零
- [x] T15 编译验证：`dotnet build Assembly-CSharp` 与 `Assembly-CSharp-Editor` 均 0 错误（含补 `using Config;` 修掉 法器打造信息弹窗 的 QualityType 报错）；进游戏核对 1/8/9/16 阶打造与炼器室等级门槛

# 法器阶数制重构 · 收尾规格

## 目标
把法器从「仅 8 品质」升级为「8 品质 × 16 阶」，并修复改造后遗留的编译错误与显示问题；炼器室扩容到 50 级，等级决定可打造的最高阶数。

## 已完成（待确认）
| 项 | 位置 | 说明 |
|---|---|---|
| 品质概率 | [法器Config.cs](file:///d:/TFSSS/TaFangSSS/Assets/Scripts/Config/法器Config.cs#L244) | 万分比，荒→洪→宙→宇→天→地→玄→黄滚动判定 |
| 品质倍率 | [法器Config.cs](file:///d:/TFSSS/TaFangSSS/Assets/Scripts/Config/法器Config.cs#L249) | 黄1 … 荒1000 |
| 法器Type 精简 | [法器Config.cs](file:///d:/TFSSS/TaFangSSS/Assets/Scripts/Config/法器Config.cs#L20) | 5 职业 × 4 部位 = 20 种；品质/阶数作为独立字段 |
| 16 阶基础伤害 | [法器Config.cs](file:///d:/TFSSS/TaFangSSS/Assets/Scripts/Config/法器Config.cs#L361) | 1阶10 → 8阶300 → 16阶3600；`Get法器基础伤害` 内乘品质倍率 |
| 词条 Minmaxes | [法器Config.cs](file:///d:/TFSSS/TaFangSSS/Assets/Scripts/Config/法器Config.cs#L848) | 16 属性 × 16 阶 = 256 条基础值，不含品质倍率 |
| 乘区约定 | [法器Config.cs](file:///d:/TFSSS/TaFangSSS/Assets/Scripts/Config/法器Config.cs#L426) | 词条只存基础值，品质倍率仅在 `Get法器属性` 统一乘算 |
| 材料道具 | [PropConfig.cs](file:///d:/TFSSS/TaFangSSS/Assets/Scripts/Config/PropConfig.cs) | `石1~石16 / 铁1~铁16 / 羽1~羽16 / 砂1~砂16`（64 条）+ 名称/品质兜底方法 |
| 打造材料取用 | [法器Config.cs](file:///d:/TFSSS/TaFangSSS/Assets/Scripts/Config/法器Config.cs#L326) | 按阶数 `材料类型 + 阶数` 解析到 PropType，即 9 阶用 9 阶材料 |
| 左栏阶数列表 | [法器打造panel.cs](file:///d:/TFSSS/TaFangSSS/Assets/Scripts/Window/炼器/法器打造panel.cs#L44) | 从最高阶数递减列出当前部位可打造法器 |
| 炼器室 0~50 级 | [道场Config.cs](file:///d:/TFSSS/TaFangSSS/Assets/Scripts/Config/道场Config.cs#L815) | 46 级起达 16 阶上限 |
| 最高炼制阶数 | [道场Config.cs](file:///d:/TFSSS/TaFangSSS/Assets/Scripts/Config/道场Config.cs#L83) | `clamp(1 + (等级-1)/3, 1, 16)`：1-3级1阶，4-6级2阶 … 46-50级16阶 |
| 领主府显示 | [领主府.cs](file:///d:/TFSSS/TaFangSSS/Assets/Scripts/Window/领主府/领主府.cs#L662-L672) | 「最高炼器品质」→「最高炼器阶数」，满级取不到下一级时沿用当前值 |
| 10 条编译错误 | 见下 | 签名补参、QualityType→阶数替换 |

## 编译错误逐条处置（用户截图 18:08）
| 文件 | 错误 | 处置 |
|---|---|---|
| StoreController.cs 553 | CS7036 缺阶数 | 传 `打造List[0].阶数` |
| StoreController.cs 564/567 | CS7036 | 传 `品质, 阶数` |
| 坊市item.cs 54 | CS7036 | 三参调用 |
| 法器材料分解弹窗.cs 79 | CS1503 | 改阶数制显示（阶数 / 材质名 / 材质图） |
| 法器打造信息弹窗.cs 22 | CS0103 | SetItem 全改阶数（背景框用 `Get阶数对应品质`） |
| 打造item.cs 41 | CS0103 | `Get道具背景框SpriteByQuality(品质)` |
| 法器打造item.cs 45 | CS7036 | 传 `阶数` |
| 法器打造panel.cs 99/186 | CS7036 | 传 `法器打造法器阶数` |
| 胜利弹窗item.cs 34 | CS1503 | `法器材料阶数` + `Get阶数对应品质` |

## 资源约定（已核对）
- `Assets/Resources/Sprite/法器/<职业><部位>.png`：单图 16 个切片 `_0~_15`，`Resources.LoadAll<Sprite>` 按序取，索引 0→1 阶。
- `Assets/Resources/Sprite/法器材料/{铁,石,羽,砂}.png`：单图 16 切片，同上。
- 背景框颜色仍由品质决定；9 阶以上沿用荒品背景/艺术字（`Get阶数对应品质` 夹到 1~8）。

## 待收尾（本次执行）
1. `法器附加属性item.cs`：显示值改为 `count × 法器品质倍率[QualityType]`，与 `Get法器属性` 的实际生效值一致（此前只显示基础值，高阶法器词条会显示偏小）。
2. `坊市Config.cs:245`：自动购买提示改用 `Get法器Name(item.法器Type, item.阶数)`，避免缺少阶数后缀。
3. 静态扫尾：确认无 `法器名Dic` / `法器Minmaxes` 旧品质键残留、无 `PropQualityDic[材料的PropType]` 残留。

## 验收
- Unity Console 零编译错误。
- 1~8 阶分别消耗 `X1`~`X8` 材料，9 阶消耗 `X9` 材料（暂不掉落 9 阶以上材料）。
- 炼器室 1 级左栏只列 1 阶，46 级列到 16 阶；领主府显示「最高炼器阶数 N 阶」。
- 法器信息弹窗内基础伤害与词条数值 = 阶数基础值 × 品质倍率。

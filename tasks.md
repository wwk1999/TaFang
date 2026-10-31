# 赌坊界面 Tasks

## T1 修复与新增存档字段
- [x] `Assets/Scripts/Store/PlayerData.cs`
  - `赌坊道具Dic` 删除 `随机看尺寸1~5`，新增 `藏品平均价值`。
  - 新增 `public 赌坊存档 赌坊存档 = new 赌坊存档();`
  - 新增 `public Dictionary<藏品Type, int> 藏品仓库Dic = new Dictionary<藏品Type, int>();`
- [x] `Assets/Scripts/Store/StoreDefine.cs`
  - `PlayData` 新增 `赌坊道具Dic` / `赌坊存档` / `藏品仓库Dic`，并在 `CopyFromRuntime` / `CopyToRuntime` 中双向复制，保证落盘。
- 验证：Unity 编译无 `赌坊道具Type` 未定义错误。

## T2 配置扩展
- [x] `Assets/Scripts/Config/赌坊Config.cs`
  - 顶层新增 `[Serializable] 赌坊藏品存档`、`[Serializable] 赌坊存档`。
  - 新增 `public static Dictionary<藏品Type, float> 藏品价格Dic`，覆盖全部 `藏品Type`，价格 = 品质基价 × 面积。
  - 新增尺寸换算（`藏品尺寸Type` → `Vector2Int`）。
- 验证：`藏品价格Dic.Count == 藏品配置.Count`。

## T3 随机占格背包增加生成接口
- [x] `Assets/Scripts/Window/随机占格背包.cs`
  - 新增 `开始生成(int 种子)`、`尝试放置`、`单格放置`、`创建藏品`、`已填满`、`已占格数`、`剩余格数`。
  - `重新随机()` 改为复用这些接口，保持原行为。
- 验证：编辑器右键「重新随机」仍能正常铺满。

## T4 新建道具背包 item 脚本
- [x] 新建 `Assets/Scripts/Window/赌坊/赌坊道具item.cs`
  - `SetItem()` 显示品质框/名称/持有数量，数量为 0 或本轮已用时半透明。
  - 左键发送 `"赌坊道具Item点击"`。
- 验证：点击事件携带正确的 `赌坊道具Type`。

## T5 新建赌坊界面脚本
- [x] 新建 `Assets/Scripts/Window/赌坊/赌坊界面.cs`
  - 生命周期、事件注册、LayoutGroup 延迟重建。
  - 恢复存档、赌坊列表、底格刷新、仓库生成/渲染。
  - 道具使用、下一轮、买下、换仓、切换确认。
  - 价格/轮数/灵气/按钮状态刷新。
- 验证：编译通过；逐条对照 `spec.md` 第 9 节验收标准。

## T6 商品 item 落盘
- [x] `Assets/Scripts/Window/赌坊/赌坊商品item.cs` 购买成功后调用 `StoreController.S.SaveStoreData()`。

## T7 预制体接线（用户手动）
- [ ] `赌坊界面.prefab` 挂 `赌坊界面` 组件并接线 Inspector 字段。
- [ ] `赌坊道具item.prefab` 移除 `赌坊商品item` 组件，改挂 `赌坊道具item` 并接线 bg/name/count。
- [x] 确认 `藏品` 节点已挂 `随机占格背包`（预制体中已确认挂载）。
- [ ] 确认 `每格像素=96`、`物品间距=4`、`列数=10`。

## T8 联调验证
- [ ] 首次进入/切换赌坊/换仓/下一轮/道具/买下/退出重进全部通过。
- [ ] 存档文件写入后重进，赌坊状态完整恢复。

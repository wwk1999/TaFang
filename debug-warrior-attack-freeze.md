# Debug Session: warrior-attack-freeze

## Status: [OPEN]

## Symptom
战士(广目天王/牛魔王/哪吒/孙悟空/盘古/元始等需下场的英雄)只对当前全局目标怪攻击一次，之后不再普攻、不放神通，直到该怪死亡才恢复。循环反复。

## Environment
- Unity 项目: TaFangSSS (d:\塔防刷刷刷)
- 运行: Unity Editor (Play Mode)

## Verified Static Facts
1. 全局目标 = `FightController.GetAttackMonster()`：分区1..7 中首个存活怪（最靠前/最接近城墙）。
2. 怪物从右侧生成（x≈7.5），向左行走，到达 `怪物攻击距离Dic`（普通-4.3/精英-4.1/Boss-3.8）后**停在原地打墙直到死亡**。
3. 英雄站位：人物Parent(x=-7.03,scale 0.71/0.87) + root(0.53, scale 0.8/0.63) → 英雄世界坐标 x≈-6.65。
4. 战士攻击范围触发器：CircleCollider2D 半径3.964 × tri缩放10(战士) × 层级缩放(0.8×0.42×0.71) ≈ 半轴 9.46(x)×8.68(y)。
   → 覆盖 x ∈ [-16.1, 2.81]，城墙(-4.3)在范围内；出生点(x>2.81)在范围外。
5. 普攻分支要求 `攻击范围内怪物.Contains(全局目标)`；神通分支要求 `攻击范围内怪物列表.Count>0`。
6. 历史改动：
   - Fix#1 (已应用): 移除 OnTriggerEnter2D/OnTriggerExit2D 中的 `if(上场) return;`
   - Fix#2 (已应用): Update 中新增"替补目标"逻辑（全局目标不在范围内时改打范围内 x 最小的怪）

## Hypotheses
- H1: 怪物进场时刻恰逢战士 `上场=true`，Enter 事件被旧代码跳过 → 该怪永远不在战士集合中 → 卡死。(Fix#1 已针对，但用户反馈仍复现，存疑)
- H2: DOTween Sequence/协程中抛异常（对象池耗尽等，该项目历史上有此类 bug）→ `上场`/`是否在神通` 标志永远不复位 → 冻结。但"怪死后恢复"与此矛盾。
- H3: `上场` 或 `是否在神通` 标志因 Sequence 被 DOTween SafeMode 杀死而卡在 true。
- H4: Fix#1/Fix#2 与实际场景配置（层级缩放/触发器实际尺寸）不符，范围判断与真实几何不一致。
- H5: Physics2D 层碰撞矩阵 / kinematic 配置导致某些怪物的 Enter/Exit 事件根本没有回调。

## Evidence Log

### Editor.log 分析 (199MB, 最后写入 2026-09-30 19:48，早于本次会话的所有修改)

**E1. 战斗期间 DOTween 回调内抛异常（现行代码仍存在）：**
```
DOTWEEN ► An error inside a tween callback was taken care of (Void ThrowForEmptyQueue()) ► Queue empty.
  at System.Collections.Generic.Queue`1[T].Dequeue ()
  at FightController.Shot普通魔法弹 () [FightController.cs:1534]   ← 丹童神通Queue.Dequeue() 无判空
  at FightController.人物神通 () [FightController.cs:344]
  at 人物item+<>c__DisplayClass75_0.<释放神通>b__1 () [人物item.cs:427]   ← 释放神通的 AppendCallback 内部!
  at DG.Tweening.Tween.OnTweenCallback ()
```
→ DOTween SafeMode 杀掉整个 Sequence → 末尾 `是否在神通 = false` 永不执行 → 该英雄永久冻结（普攻+神通全停）。

**E2. 怪物对象池耗尽（现行代码仍存在，重复 23+ 次）：**
```
InvalidOperationException: Queue empty.
  at FightController.CreateNormalMonster () [FightController.cs:1819]   ← 普通怪Queue.Dequeue() 无判空
  at FightController.Update () [FightController.cs:2064]
```
→ 每帧重试每帧抛异常（`当前创建普通怪物时间=0` 永不执行），且不再出新怪。

**E3. DOTween SafeMode 汇总报告：** "errors inside callbacks (these might be important)" / "missing target or field errors" 多次出现。

**E4. 场景卸载噪音：** `<上场技能>b__0`/`<释放神通>b__1` 中 Animator/人物item destroyed 访问错误（仅换场时）。

**E5. 无关异常：** HeroImage.Update:53 每帧 NRE（编队拖拽 UI bug，独立问题）。

### 关键时间线
- 用户最后一次实际测试: 9/30（早于 Fix#1/Fix#2）
- "还是不行"的反馈基于旧代码的体验，两个修复尚未经过任何运行验证

## Hypotheses Status
- H1 (上场跳过 Enter 事件→怪永久丢失): **代码静态验证成立**，解释"打一次→冻结→怪死恢复"。Fix#1 针对此。
- H2/H3 (DOTween 回调异常杀序列→标志卡死): **运行时证据确认成立** (E1)。尚无修复。
- H4 (范围几何与实际不符): 几何计算支持"出生点在范围外、城墙在范围内"，H1 成立的前提。
- H5 (层矩阵导致无回调): 被证据否定——Enter/Exit 回调确实在工作（E1 的触发链正常经过）。

## Next Steps
1. ~~机制B修复~~ 已完成 (2026-10-01)：
   - 人物item.上场技能/释放神通：Sequence 增加 OnKill 兜底（SafeMode 杀序列也复位 上场/是否在神通 + 归位）
   - FightController.CreateNormalMonster/CreateEliteMonster/CreateBossMonster：Dequeue 前 Count 判空
   - FightController.Shot普通魔法弹：整体 try-catch（池耗尽跳过弹幕，防 DOTween 序列被杀）
2. ~~机制C修复~~ 已完成 (2026-10-01)：多触发器误删
3. 用户运行验证（注意必须先让 Unity 重编译，之前一次验证跑的是旧程序集）

## 机制C：多触发器 Exit 误删（已确认+已修复 2026-10-01）

### 用户日志证据
在 Boss+孙悟空 条件下对 Enter/Exit 加 Debug.LogError，观察到：
- 战士下场期间首领 Enter/Exit 来回抖动 30+ 次
- 首领走到墙边后最后一个事件必为 Exit（删除），再无 Enter，但首领明显仍在攻击范围内

### 根因（prefab 静态验证）
英雄根节点（挂 Rigidbody2D，kinematic + FullKinematicContacts）下有**多个 IsTrigger 碰撞体**，全部向人物item脚本发送 Enter/Exit：
1. 攻击范围圆："tri"(374551246084844845) → 子物体"collider"(737615794233946079) CircleCollider2D 半径3.964（SetItem 按职业缩放 10/12/14）
2. **石敢当神通三角形**："石敢当神通Obj"(GameObject 2814914002701570181) 下 "collider (1)"(4978346782751212964) PolygonCollider2D（IsTrigger=1，尖端朝左最远 x=-5.11）
3. 牛魔王技能触发圆（半径 2.998）等

缺陷组合：HashSet 去重 Enter（第二个触发器的 Enter 不记），但**任一触发器的 Exit 都会 Remove 成功**。首领停在墙边打墙时攻击动画使其碰撞体在三角形尖端边缘抖动 → 30+ 次抖动；最后一次抖出三角形 → Exit 删除，但首领从未离开攻击范围圆 → 圆不会补发 Enter → 集合永久丢失 → Count==0 → 战士停手。

### 修复（人物item.cs 行111-150）
- 新增 `攻击范围Collider` 缓存（Get攻击范围Collider() 惰性获取）
- Enter：`!rangeCol.IsTouching(other)` 时忽略（非攻击范围圆的进入）
- Exit：`rangeCol.IsTouching(other)` 时忽略（附属触发器的退出，怪仍在攻击圈内）
- IsTouching 仅在触发事件时调用，无每帧开销
- 顺带移除用户手加的 Debug.LogError 调试日志

### 验证方法
重编译后进入战斗，打到只剩首领怪：战士应持续对墙边首领普攻/神通；断点确认 攻击范围内怪物列表.Count 包含首领。


using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;

public class PlayerData : XSingleton<PlayerData>
{
    protected override void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public bool 消耗传道次数=true;
    public bool 传道所有=false;

    public bool 是否第一次游戏=true;

    public bool 元素人人为我开关=true;
    public bool 职业人人为我开关=true;

    public bool 是否自动下一关=true;
    public int 坊市等级 = 1;
    public bool 是否加入愿望单 = false;
    public 符文之地Type 符文之地最大关卡 = 符文之地Type.青木林;
    public 主页地图Type 主页地图Type = 主页地图Type.东胜神州;
    public string Name = "修仙者";
    public JingJieType 历史最高境界 = JingJieType.练气;
    public JingJieType 当前轮回境界 = JingJieType.练气;
    public int 轮回次数 = 0;
    public BigDouble 初始跟脚 = 1;
    public bool 是否首次进入游戏 = false;
    public bool 是否首次进入主页面 = false;
    public bool 是否首次进入英雄界面 = false;
    public bool 是否首次进入关卡 = false;
    public bool 是否首次通关关卡 = false;
    public bool 是否首次配置神通 = false;

    public float 灵兽蛋数量 = 10;
    public List<灵兽> 灵兽列表 = new List<灵兽>();
    public float Exp;
    public int 当前出战编队 = 1;
    public int 长生道体年数 = 0;
    public 体质Type 当前体质 = 体质Type.凡体;
    public float 道龄S = 0;
    public int 道龄年;
    public 主线关卡Type 最大主线关卡=主线关卡Type.花果山;
    public 神物Type 最大神物关卡 = 神物Type.最终伤害;
    public int 混沌虚空最大层数 = 1;
    public int 城墙等级 = 1;
    public int 招募积分 = 0;
    public float 关卡倍速 = 1;
    public bool 是否招募十次 = false;
    public bool 是否招募所有 = false;
    public bool 重复挑战 = false;
    public float 关卡修炼速度加成 = 0;
    public float BGM音量 = 1;
    public float 音效音量 = 1;
    public Vector2 分辨率 = new Vector2(1920,1080);
    public bool 是否窗口 = true;
    public int 剩余传道次数 = 3;
    public int 坊市刷新次数 = 0;
    public List<坊市物品> 坊市物品列表 = new List<坊市物品>();
    public List<法器> 法器列表 = new List<法器>();
    public List<仙石> 仙石列表 = new List<仙石>();
    public int 炼丹等级 = 1;
    public float 炼丹经验 = 0;
    public int 剩余炼制数量;
    public float 当前炼制秒数;
    public List<法器打造Item> 打造List=new List<法器打造Item>();
    public List<丹药炼制Item> 丹药炼制List=new List<丹药炼制Item>();
    
    

    public bool 领主荒无暇提示 = true;
    public bool 领主洪无暇提示 = true;
    public bool 领主宙无暇提示 = true;
    public bool 领主宇无暇提示 = true;
    public bool 领主天无暇提示 = true;
    public bool 领主地无暇提示 = true;
    public bool 领主玄无暇提示 = true;

    public bool 灵兽分解性别所有 = false;
    public bool 灵兽分解性别公 = false;
    public bool 灵兽分解性别母 = false;
    
    public bool 灵兽分解元素所有 = false;
    public bool 灵兽分解元素火 = false;
    public bool 灵兽分解元素冰 = false;
    public bool 灵兽分解元素电 = false;
    public bool 灵兽分解元素物 = false;
    public bool 灵兽分解元素暗 = false;


    public bool 灵兽分解阶段所有 = false;
    public bool 灵兽分解阶段1 = false;
    public bool 灵兽分解阶段2 = false;
    public bool 灵兽分解阶段3 = false;
    public bool 灵兽分解阶段4 = false;
    public bool 灵兽分解阶段5 = false;
    public bool 灵兽分解阶段6 = false;
    public bool 灵兽分解阶段7 = false;
    public bool 灵兽分解阶段8 = false;
    
    public bool 灵兽分解品级所有 = false;
    public bool 灵兽分解品级1 = false;
    public bool 灵兽分解品级2 = false;
    public bool 灵兽分解品级3 = false;
    public bool 灵兽分解品级4 = false;
    public bool 灵兽分解品级5 = false;
    public bool 灵兽分解品级6 = false;
    public bool 灵兽分解品级7 = false;
    public bool 灵兽分解品级8 = false;
    
    
    public bool 灵兽分解血脉所有 = false;
    public bool 灵兽分解血脉1 = false;
    public bool 灵兽分解血脉2 = false;
    public bool 灵兽分解血脉3 = false;
    public bool 灵兽分解血脉4 = false;
    public bool 灵兽分解血脉5 = false;
    public bool 灵兽分解血脉6 = false;
    public bool 灵兽分解血脉7 = false;
    public bool 灵兽分解血脉8 = false;

    public Dictionary<int, 土地> 灵植土地列表 = new Dictionary<int, 土地>()
    {
        {1,new 土地(){index = 1,土地Type =土地Type.普通土地,灵植Type = 灵植Type.None,当前time=0,所需time = 9999999}},
        {2,new 土地(){index = 2,土地Type =土地Type.未解锁,灵植Type = 灵植Type.None,当前time=0,所需time = 9999999}},
        {3,new 土地(){index = 3,土地Type =土地Type.未解锁,灵植Type = 灵植Type.None,当前time=0,所需time = 9999999}},
        {4,new 土地(){index = 4,土地Type =土地Type.未解锁,灵植Type = 灵植Type.None,当前time=0,所需time = 9999999}},
        {5,new 土地(){index = 5,土地Type =土地Type.未解锁,灵植Type = 灵植Type.None,当前time=0,所需time = 9999999}},
        {6,new 土地(){index = 6,土地Type =土地Type.未解锁,灵植Type = 灵植Type.None,当前time=0,所需time = 9999999}},
        {7,new 土地(){index = 7,土地Type =土地Type.未解锁,灵植Type = 灵植Type.None,当前time=0,所需time = 9999999}},
        {8,new 土地(){index = 8,土地Type =土地Type.未解锁,灵植Type = 灵植Type.None,当前time=0,所需time = 9999999}},
        {9,new 土地(){index = 9,土地Type =土地Type.未解锁,灵植Type = 灵植Type.None,当前time=0,所需time = 9999999}},
        {10,new 土地(){index = 10,土地Type =土地Type.未解锁,灵植Type = 灵植Type.None,当前time=0,所需time = 9999999}},
        {11,new 土地(){index = 11,土地Type =土地Type.未解锁,灵植Type = 灵植Type.None,当前time=0,所需time = 9999999}},
        {12,new 土地(){index = 12,土地Type =土地Type.未解锁,灵植Type = 灵植Type.None,当前time=0,所需time = 9999999}},
        {13,new 土地(){index = 13,土地Type =土地Type.未解锁,灵植Type = 灵植Type.None,当前time=0,所需time = 9999999}},
        {14,new 土地(){index = 14,土地Type =土地Type.未解锁,灵植Type = 灵植Type.None,当前time=0,所需time = 9999999}},
        {15,new 土地(){index = 15,土地Type =土地Type.未解锁,灵植Type = 灵植Type.None,当前time=0,所需time = 9999999}},
        {16,new 土地(){index = 16,土地Type =土地Type.未解锁,灵植Type = 灵植Type.None,当前time=0,所需time = 9999999}},
        {17,new 土地(){index = 17,土地Type =土地Type.未解锁,灵植Type = 灵植Type.None,当前time=0,所需time = 9999999}},
        {18,new 土地(){index = 18,土地Type =土地Type.未解锁,灵植Type = 灵植Type.None,当前time=0,所需time = 9999999}},
        {19,new 土地(){index = 19,土地Type =土地Type.未解锁,灵植Type = 灵植Type.None,当前time=0,所需time = 9999999}},
        {20,new 土地(){index = 20,土地Type =土地Type.未解锁,灵植Type = 灵植Type.None,当前time=0,所需time = 9999999}},

    };
    public Dictionary<int, 孵化池> 孵化池列表 = new Dictionary<int, 孵化池>() {{1,new 孵化池(){index = 1}} };

    public Dictionary<建筑Type, int> 建筑等级Dic = new Dictionary<建筑Type, int>()
    {
        { 建筑Type.领主府, 0 },
        { 建筑Type.矿场, 0 },
        { 建筑Type.玄铁洞, 0 },
        { 建筑Type.地脉, 0 },
        { 建筑Type.功德碑, 0 },
        { 建筑Type.炼丹室, 0 },
        { 建筑Type.炼器室, 0 },
        { 建筑Type.聚贤阁, 0 },
        { 建筑Type.坊市, 0 },
        { 建筑Type.灵兽坊, 0 },
        { 建筑Type.仙女阁, 0 },
        { 建筑Type.灵植园, 0 },
    };

    public bool 自动拒绝凡品供奉=false;
    public bool 自动拒绝灵品供奉=false;
    public bool 自动拒绝仙品供奉=false;
    public bool 自动拒绝圣品供奉=false;

    public List<供奉> 当前供奉列表=new List<供奉>();
    public List<供奉> 供奉申请列表=new List<供奉>();
    public List<供奉> 供奉保留列表=new List<供奉>();
    
    public List<HeroType>神通配置List=new List<HeroType>()
    {
        HeroType.丹童
    };

    public Dictionary<法器Type, bool> 坊市自动购买法器配置 = new Dictionary<法器Type, bool>()
{
    { 法器Type.None, false },

    // ============== 1. 战士 ==============
    { 法器Type.战士武器, false },
    { 法器Type.战士头盔, false },
    { 法器Type.战士衣服, false },
    { 法器Type.战士鞋子, false },

    // ============== 2. 控制 ==============
    { 法器Type.控制武器, false },
    { 法器Type.控制头盔, false },
    { 法器Type.控制衣服, false },
    { 法器Type.控制鞋子, false },

    // ============== 3. 辅助 ==============
    { 法器Type.辅助武器, false },
    { 法器Type.辅助头盔, false },
    { 法器Type.辅助衣服, false },
    { 法器Type.辅助鞋子, false },

    // ============== 4. 射手 ==============
    { 法器Type.射手武器, false },
    { 法器Type.射手头盔, false },
    { 法器Type.射手衣服, false },
    { 法器Type.射手鞋子, false },

    // ============== 5. 法师 ==============
    { 法器Type.法师武器, false },
    { 法器Type.法师头盔, false },
    { 法器Type.法师衣服, false },
    { 法器Type.法师鞋子, false },
};
public Dictionary<string, bool> 坊市自动购买丹药配置 = new Dictionary<string, bool>()
{
    // 火焰伤害
    {"火焰伤害_黄品", false},
    {"火焰伤害_玄品", false},
    {"火焰伤害_地品", false},
    {"火焰伤害_天品", false},
    {"火焰伤害_宇品", false},
    {"火焰伤害_宙品", false},
    {"火焰伤害_洪品", false},
    {"火焰伤害_荒品", false},
    
    // 冰霜伤害
    {"冰霜伤害_黄品", false},
    {"冰霜伤害_玄品", false},
    {"冰霜伤害_地品", false},
    {"冰霜伤害_天品", false},
    {"冰霜伤害_宇品", false},
    {"冰霜伤害_宙品", false},
    {"冰霜伤害_洪品", false},
    {"冰霜伤害_荒品", false},
    
    // 雷电伤害
    {"雷电伤害_黄品", false},
    {"雷电伤害_玄品", false},
    {"雷电伤害_地品", false},
    {"雷电伤害_天品", false},
    {"雷电伤害_宇品", false},
    {"雷电伤害_宙品", false},
    {"雷电伤害_洪品", false},
    {"雷电伤害_荒品", false},
    
    // 黑暗伤害
    {"黑暗伤害_黄品", false},
    {"黑暗伤害_玄品", false},
    {"黑暗伤害_地品", false},
    {"黑暗伤害_天品", false},
    {"黑暗伤害_宇品", false},
    {"黑暗伤害_宙品", false},
    {"黑暗伤害_洪品", false},
    {"黑暗伤害_荒品", false},
    
    // 物理伤害
    {"物理伤害_黄品", false},
    {"物理伤害_玄品", false},
    {"物理伤害_地品", false},
    {"物理伤害_天品", false},
    {"物理伤害_宇品", false},
    {"物理伤害_宙品", false},
    {"物理伤害_洪品", false},
    {"物理伤害_荒品", false},
    
    // 战士伤害
    {"战士伤害_黄品", false},
    {"战士伤害_玄品", false},
    {"战士伤害_地品", false},
    {"战士伤害_天品", false},
    {"战士伤害_宇品", false},
    {"战士伤害_宙品", false},
    {"战士伤害_洪品", false},
    {"战士伤害_荒品", false},
    
    // 法师伤害
    {"法师伤害_黄品", false},
    {"法师伤害_玄品", false},
    {"法师伤害_地品", false},
    {"法师伤害_天品", false},
    {"法师伤害_宇品", false},
    {"法师伤害_宙品", false},
    {"法师伤害_洪品", false},
    {"法师伤害_荒品", false},
    
    // 射手伤害
    {"射手伤害_黄品", false},
    {"射手伤害_玄品", false},
    {"射手伤害_地品", false},
    {"射手伤害_天品", false},
    {"射手伤害_宇品", false},
    {"射手伤害_宙品", false},
    {"射手伤害_洪品", false},
    {"射手伤害_荒品", false},
    
    // 控制伤害
    {"控制伤害_黄品", false},
    {"控制伤害_玄品", false},
    {"控制伤害_地品", false},
    {"控制伤害_天品", false},
    {"控制伤害_宇品", false},
    {"控制伤害_宙品", false},
    {"控制伤害_洪品", false},
    {"控制伤害_荒品", false},
    
    // 辅助伤害
    {"辅助伤害_黄品", false},
    {"辅助伤害_玄品", false},
    {"辅助伤害_地品", false},
    {"辅助伤害_天品", false},
    {"辅助伤害_宇品", false},
    {"辅助伤害_宙品", false},
    {"辅助伤害_洪品", false},
    {"辅助伤害_荒品", false},
    
    // 最终伤害
    {"最终伤害_黄品", false},
    {"最终伤害_玄品", false},
    {"最终伤害_地品", false},
    {"最终伤害_天品", false},
    {"最终伤害_宇品", false},
    {"最终伤害_宙品", false},
    {"最终伤害_洪品", false},
    {"最终伤害_荒品", false},
    
    // 修炼速度
    {"修炼速度_黄品", false},
    {"修炼速度_玄品", false},
    {"修炼速度_地品", false},
    {"修炼速度_天品", false},
    {"修炼速度_宇品", false},
    {"修炼速度_宙品", false},
    {"修炼速度_洪品", false},
    {"修炼速度_荒品", false},
    
    // 掉宝率
    {"掉宝率_黄品", false},
    {"掉宝率_玄品", false},
    {"掉宝率_地品", false},
    {"掉宝率_天品", false},
    {"掉宝率_宇品", false},
    {"掉宝率_宙品", false},
    {"掉宝率_洪品", false},
    {"掉宝率_荒品", false},
    
    // 英雄暴击伤害
    {"英雄暴击伤害_黄品", false},
    {"英雄暴击伤害_玄品", false},
    {"英雄暴击伤害_地品", false},
    {"英雄暴击伤害_天品", false},
    {"英雄暴击伤害_宇品", false},
    {"英雄暴击伤害_宙品", false},
    {"英雄暴击伤害_洪品", false},
    {"英雄暴击伤害_荒品", false},
    
    // 加跟脚
    {"加跟脚_黄品", false},
    {"加跟脚_玄品", false},
    {"加跟脚_地品", false},
    {"加跟脚_天品", false},
    {"加跟脚_宇品", false},
    {"加跟脚_宙品", false},
    {"加跟脚_洪品", false},
    {"加跟脚_荒品", false},
    
    // 英雄火焰伤害
    {"英雄火焰伤害_黄品", false},
    {"英雄火焰伤害_玄品", false},
    {"英雄火焰伤害_地品", false},
    {"英雄火焰伤害_天品", false},
    {"英雄火焰伤害_宇品", false},
    {"英雄火焰伤害_宙品", false},
    {"英雄火焰伤害_洪品", false},
    {"英雄火焰伤害_荒品", false},
    
    // 英雄冰霜伤害
    {"英雄冰霜伤害_黄品", false},
    {"英雄冰霜伤害_玄品", false},
    {"英雄冰霜伤害_地品", false},
    {"英雄冰霜伤害_天品", false},
    {"英雄冰霜伤害_宇品", false},
    {"英雄冰霜伤害_宙品", false},
    {"英雄冰霜伤害_洪品", false},
    {"英雄冰霜伤害_荒品", false},
    
    // 英雄雷电伤害
    {"英雄雷电伤害_黄品", false},
    {"英雄雷电伤害_玄品", false},
    {"英雄雷电伤害_地品", false},
    {"英雄雷电伤害_天品", false},
    {"英雄雷电伤害_宇品", false},
    {"英雄雷电伤害_宙品", false},
    {"英雄雷电伤害_洪品", false},
    {"英雄雷电伤害_荒品", false},
    
    // 英雄黑暗伤害
    {"英雄黑暗伤害_黄品", false},
    {"英雄黑暗伤害_玄品", false},
    {"英雄黑暗伤害_地品", false},
    {"英雄黑暗伤害_天品", false},
    {"英雄黑暗伤害_宇品", false},
    {"英雄黑暗伤害_宙品", false},
    {"英雄黑暗伤害_洪品", false},
    {"英雄黑暗伤害_荒品", false},
    
    // 英雄物理伤害
    {"英雄物理伤害_黄品", false},
    {"英雄物理伤害_玄品", false},
    {"英雄物理伤害_地品", false},
    {"英雄物理伤害_天品", false},
    {"英雄物理伤害_宇品", false},
    {"英雄物理伤害_宙品", false},
    {"英雄物理伤害_洪品", false},
    {"英雄物理伤害_荒品", false},
    
    // 英雄战士伤害
    {"英雄战士伤害_黄品", false},
    {"英雄战士伤害_玄品", false},
    {"英雄战士伤害_地品", false},
    {"英雄战士伤害_天品", false},
    {"英雄战士伤害_宇品", false},
    {"英雄战士伤害_宙品", false},
    {"英雄战士伤害_洪品", false},
    {"英雄战士伤害_荒品", false},
    
    // 英雄法师伤害
    {"英雄法师伤害_黄品", false},
    {"英雄法师伤害_玄品", false},
    {"英雄法师伤害_地品", false},
    {"英雄法师伤害_天品", false},
    {"英雄法师伤害_宇品", false},
    {"英雄法师伤害_宙品", false},
    {"英雄法师伤害_洪品", false},
    {"英雄法师伤害_荒品", false},
    
    // 英雄射手伤害
    {"英雄射手伤害_黄品", false},
    {"英雄射手伤害_玄品", false},
    {"英雄射手伤害_地品", false},
    {"英雄射手伤害_天品", false},
    {"英雄射手伤害_宇品", false},
    {"英雄射手伤害_宙品", false},
    {"英雄射手伤害_洪品", false},
    {"英雄射手伤害_荒品", false},
    
    // 英雄控制伤害
    {"英雄控制伤害_黄品", false},
    {"英雄控制伤害_玄品", false},
    {"英雄控制伤害_地品", false},
    {"英雄控制伤害_天品", false},
    {"英雄控制伤害_宇品", false},
    {"英雄控制伤害_宙品", false},
    {"英雄控制伤害_洪品", false},
    {"英雄控制伤害_荒品", false},
    
    // 英雄辅助伤害
    {"英雄辅助伤害_黄品", false},
    {"英雄辅助伤害_玄品", false},
    {"英雄辅助伤害_地品", false},
    {"英雄辅助伤害_天品", false},
    {"英雄辅助伤害_宇品", false},
    {"英雄辅助伤害_宙品", false},
    {"英雄辅助伤害_洪品", false},
    {"英雄辅助伤害_荒品", false},
    
    // 英雄最终伤害
    {"英雄最终伤害_黄品", false},
    {"英雄最终伤害_玄品", false},
    {"英雄最终伤害_地品", false},
    {"英雄最终伤害_天品", false},
    {"英雄最终伤害_宇品", false},
    {"英雄最终伤害_宙品", false},
    {"英雄最终伤害_洪品", false},
    {"英雄最终伤害_荒品", false},
};

public Dictionary<string, bool> 坊市自动购买丹方配置 = new Dictionary<string, bool>()
{
    // 火焰伤害
    {"火焰伤害_黄品", false},
    {"火焰伤害_玄品", false},
    {"火焰伤害_地品", false},
    {"火焰伤害_天品", false},
    {"火焰伤害_宇品", false},
    {"火焰伤害_宙品", false},
    {"火焰伤害_洪品", false},
    {"火焰伤害_荒品", false},
    
    // 冰霜伤害
    {"冰霜伤害_黄品", false},
    {"冰霜伤害_玄品", false},
    {"冰霜伤害_地品", false},
    {"冰霜伤害_天品", false},
    {"冰霜伤害_宇品", false},
    {"冰霜伤害_宙品", false},
    {"冰霜伤害_洪品", false},
    {"冰霜伤害_荒品", false},
    
    // 雷电伤害
    {"雷电伤害_黄品", false},
    {"雷电伤害_玄品", false},
    {"雷电伤害_地品", false},
    {"雷电伤害_天品", false},
    {"雷电伤害_宇品", false},
    {"雷电伤害_宙品", false},
    {"雷电伤害_洪品", false},
    {"雷电伤害_荒品", false},
    
    // 黑暗伤害
    {"黑暗伤害_黄品", false},
    {"黑暗伤害_玄品", false},
    {"黑暗伤害_地品", false},
    {"黑暗伤害_天品", false},
    {"黑暗伤害_宇品", false},
    {"黑暗伤害_宙品", false},
    {"黑暗伤害_洪品", false},
    {"黑暗伤害_荒品", false},
    
    // 物理伤害
    {"物理伤害_黄品", false},
    {"物理伤害_玄品", false},
    {"物理伤害_地品", false},
    {"物理伤害_天品", false},
    {"物理伤害_宇品", false},
    {"物理伤害_宙品", false},
    {"物理伤害_洪品", false},
    {"物理伤害_荒品", false},
    
    // 战士伤害
    {"战士伤害_黄品", false},
    {"战士伤害_玄品", false},
    {"战士伤害_地品", false},
    {"战士伤害_天品", false},
    {"战士伤害_宇品", false},
    {"战士伤害_宙品", false},
    {"战士伤害_洪品", false},
    {"战士伤害_荒品", false},
    
    // 法师伤害
    {"法师伤害_黄品", false},
    {"法师伤害_玄品", false},
    {"法师伤害_地品", false},
    {"法师伤害_天品", false},
    {"法师伤害_宇品", false},
    {"法师伤害_宙品", false},
    {"法师伤害_洪品", false},
    {"法师伤害_荒品", false},
    
    // 射手伤害
    {"射手伤害_黄品", false},
    {"射手伤害_玄品", false},
    {"射手伤害_地品", false},
    {"射手伤害_天品", false},
    {"射手伤害_宇品", false},
    {"射手伤害_宙品", false},
    {"射手伤害_洪品", false},
    {"射手伤害_荒品", false},
    
    // 控制伤害
    {"控制伤害_黄品", false},
    {"控制伤害_玄品", false},
    {"控制伤害_地品", false},
    {"控制伤害_天品", false},
    {"控制伤害_宇品", false},
    {"控制伤害_宙品", false},
    {"控制伤害_洪品", false},
    {"控制伤害_荒品", false},
    
    // 辅助伤害
    {"辅助伤害_黄品", false},
    {"辅助伤害_玄品", false},
    {"辅助伤害_地品", false},
    {"辅助伤害_天品", false},
    {"辅助伤害_宇品", false},
    {"辅助伤害_宙品", false},
    {"辅助伤害_洪品", false},
    {"辅助伤害_荒品", false},
    
    // 最终伤害
    {"最终伤害_黄品", false},
    {"最终伤害_玄品", false},
    {"最终伤害_地品", false},
    {"最终伤害_天品", false},
    {"最终伤害_宇品", false},
    {"最终伤害_宙品", false},
    {"最终伤害_洪品", false},
    {"最终伤害_荒品", false},
    
    // 修炼速度
    {"修炼速度_黄品", false},
    {"修炼速度_玄品", false},
    {"修炼速度_地品", false},
    {"修炼速度_天品", false},
    {"修炼速度_宇品", false},
    {"修炼速度_宙品", false},
    {"修炼速度_洪品", false},
    {"修炼速度_荒品", false},
    
    // 掉宝率
    {"掉宝率_黄品", false},
    {"掉宝率_玄品", false},
    {"掉宝率_地品", false},
    {"掉宝率_天品", false},
    {"掉宝率_宇品", false},
    {"掉宝率_宙品", false},
    {"掉宝率_洪品", false},
    {"掉宝率_荒品", false},
    
    // 英雄暴击伤害
    {"英雄暴击伤害_黄品", false},
    {"英雄暴击伤害_玄品", false},
    {"英雄暴击伤害_地品", false},
    {"英雄暴击伤害_天品", false},
    {"英雄暴击伤害_宇品", false},
    {"英雄暴击伤害_宙品", false},
    {"英雄暴击伤害_洪品", false},
    {"英雄暴击伤害_荒品", false},
    
    // 加跟脚
    {"加跟脚_黄品", false},
    {"加跟脚_玄品", false},
    {"加跟脚_地品", false},
    {"加跟脚_天品", false},
    {"加跟脚_宇品", false},
    {"加跟脚_宙品", false},
    {"加跟脚_洪品", false},
    {"加跟脚_荒品", false},
    
    // 英雄火焰伤害
    {"英雄火焰伤害_黄品", false},
    {"英雄火焰伤害_玄品", false},
    {"英雄火焰伤害_地品", false},
    {"英雄火焰伤害_天品", false},
    {"英雄火焰伤害_宇品", false},
    {"英雄火焰伤害_宙品", false},
    {"英雄火焰伤害_洪品", false},
    {"英雄火焰伤害_荒品", false},
    
    // 英雄冰霜伤害
    {"英雄冰霜伤害_黄品", false},
    {"英雄冰霜伤害_玄品", false},
    {"英雄冰霜伤害_地品", false},
    {"英雄冰霜伤害_天品", false},
    {"英雄冰霜伤害_宇品", false},
    {"英雄冰霜伤害_宙品", false},
    {"英雄冰霜伤害_洪品", false},
    {"英雄冰霜伤害_荒品", false},
    
    // 英雄雷电伤害
    {"英雄雷电伤害_黄品", false},
    {"英雄雷电伤害_玄品", false},
    {"英雄雷电伤害_地品", false},
    {"英雄雷电伤害_天品", false},
    {"英雄雷电伤害_宇品", false},
    {"英雄雷电伤害_宙品", false},
    {"英雄雷电伤害_洪品", false},
    {"英雄雷电伤害_荒品", false},
    
    // 英雄黑暗伤害
    {"英雄黑暗伤害_黄品", false},
    {"英雄黑暗伤害_玄品", false},
    {"英雄黑暗伤害_地品", false},
    {"英雄黑暗伤害_天品", false},
    {"英雄黑暗伤害_宇品", false},
    {"英雄黑暗伤害_宙品", false},
    {"英雄黑暗伤害_洪品", false},
    {"英雄黑暗伤害_荒品", false},
    
    // 英雄物理伤害
    {"英雄物理伤害_黄品", false},
    {"英雄物理伤害_玄品", false},
    {"英雄物理伤害_地品", false},
    {"英雄物理伤害_天品", false},
    {"英雄物理伤害_宇品", false},
    {"英雄物理伤害_宙品", false},
    {"英雄物理伤害_洪品", false},
    {"英雄物理伤害_荒品", false},
    
    // 英雄战士伤害
    {"英雄战士伤害_黄品", false},
    {"英雄战士伤害_玄品", false},
    {"英雄战士伤害_地品", false},
    {"英雄战士伤害_天品", false},
    {"英雄战士伤害_宇品", false},
    {"英雄战士伤害_宙品", false},
    {"英雄战士伤害_洪品", false},
    {"英雄战士伤害_荒品", false},
    
    // 英雄法师伤害
    {"英雄法师伤害_黄品", false},
    {"英雄法师伤害_玄品", false},
    {"英雄法师伤害_地品", false},
    {"英雄法师伤害_天品", false},
    {"英雄法师伤害_宇品", false},
    {"英雄法师伤害_宙品", false},
    {"英雄法师伤害_洪品", false},
    {"英雄法师伤害_荒品", false},
    
    // 英雄射手伤害
    {"英雄射手伤害_黄品", false},
    {"英雄射手伤害_玄品", false},
    {"英雄射手伤害_地品", false},
    {"英雄射手伤害_天品", false},
    {"英雄射手伤害_宇品", false},
    {"英雄射手伤害_宙品", false},
    {"英雄射手伤害_洪品", false},
    {"英雄射手伤害_荒品", false},
    
    // 英雄控制伤害
    {"英雄控制伤害_黄品", false},
    {"英雄控制伤害_玄品", false},
    {"英雄控制伤害_地品", false},
    {"英雄控制伤害_天品", false},
    {"英雄控制伤害_宇品", false},
    {"英雄控制伤害_宙品", false},
    {"英雄控制伤害_洪品", false},
    {"英雄控制伤害_荒品", false},
    
    // 英雄辅助伤害
    {"英雄辅助伤害_黄品", false},
    {"英雄辅助伤害_玄品", false},
    {"英雄辅助伤害_地品", false},
    {"英雄辅助伤害_天品", false},
    {"英雄辅助伤害_宇品", false},
    {"英雄辅助伤害_宙品", false},
    {"英雄辅助伤害_洪品", false},
    {"英雄辅助伤害_荒品", false},
    
    // 英雄最终伤害
    {"英雄最终伤害_黄品", false},
    {"英雄最终伤害_玄品", false},
    {"英雄最终伤害_地品", false},
    {"英雄最终伤害_天品", false},
    {"英雄最终伤害_宇品", false},
    {"英雄最终伤害_宙品", false},
    {"英雄最终伤害_洪品", false},
    {"英雄最终伤害_荒品", false},
};

public Dictionary<string, bool> 坊市自动购买仙石配置 = new Dictionary<string, bool>()
{
    { "赤阳石_黄品", false },
    { "赤阳石_玄品", false },
    { "赤阳石_地品", false },
    { "赤阳石_天品", false },
    { "赤阳石_宇品", false },
    { "赤阳石_宙品", false },
    { "赤阳石_洪品", false },
    { "赤阳石_荒品", false },

    { "太虚石_黄品", false },
    { "太虚石_玄品", false },
    { "太虚石_地品", false },
    { "太虚石_天品", false },
    { "太虚石_宇品", false },
    { "太虚石_宙品", false },
    { "太虚石_洪品", false },
    { "太虚石_荒品", false },

    { "清心玉_黄品", false },
    { "清心玉_玄品", false },
    { "清心玉_地品", false },
    { "清心玉_天品", false },
    { "清心玉_宇品", false },
    { "清心玉_宙品", false },
    { "清心玉_洪品", false },
    { "清心玉_荒品", false },

    { "玄冥石_黄品", false },
    { "玄冥石_玄品", false },
    { "玄冥石_地品", false },
    { "玄冥石_天品", false },
    { "玄冥石_宇品", false },
    { "玄冥石_宙品", false },
    { "玄冥石_洪品", false },
    { "玄冥石_荒品", false },

    { "玄灵晶_黄品", false },
    { "玄灵晶_玄品", false },
    { "玄灵晶_地品", false },
    { "玄灵晶_天品", false },
    { "玄灵晶_宇品", false },
    { "玄灵晶_宙品", false },
    { "玄灵晶_洪品", false },
    { "玄灵晶_荒品", false },

    { "天罡石_黄品", false },
    { "天罡石_玄品", false },
    { "天罡石_地品", false },
    { "天罡石_天品", false },
    { "天罡石_宇品", false },
    { "天罡石_宙品", false },
    { "天罡石_洪品", false },
    { "天罡石_荒品", false },
};

    public Dictionary<HeroType, List<List<int>>> 英雄技能树Dic = new Dictionary<HeroType, List<List<int>>>()
{
    {
        HeroType.丹童,
        new List<List<int>>()
        {
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
        }
    },
    {
        HeroType.土地,
        new List<List<int>>()
        {
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
        }
    },
    {
        HeroType.河伯,
        new List<List<int>>()
        {
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
        }
    },
    {
        HeroType.瑶池仙女,
        new List<List<int>>()
        {
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
        }
    },
    {
        HeroType.石敢当,
        new List<List<int>>()
        {
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
        }
    },
    {
        HeroType.玄女,
        new List<List<int>>()
        {
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
        }
    },
    {
        HeroType.龟丞相,
        new List<List<int>>()
        {
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
        }
    },
    {
        HeroType.太白金星,
        new List<List<int>>()
        {
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
        }
    },
    {
        HeroType.多闻天王,
        new List<List<int>>()
        {
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
        }
    },
    {
        HeroType.广目天王,
        new List<List<int>>()
        {
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
        }
    },
    {
        HeroType.雷震子,
        new List<List<int>>()
        {
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
        }
    },
    {
        HeroType.月老,
        new List<List<int>>()
        {
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
        }
    },
    {
        HeroType.嫦娥,
        new List<List<int>>()
        {
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
        }
    },
    {
        HeroType.杨戬,
        new List<List<int>>()
        {
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
        }
    },
    {
        HeroType.妲己,
        new List<List<int>>()
        {
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
        }
    },
    {
        HeroType.牛魔王,
        new List<List<int>>()
        {
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
        }
    },
    {
        HeroType.哪吒,
        new List<List<int>>()
        {
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
        }
    },
    {
        HeroType.孙悟空,
        new List<List<int>>()
        {
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
        }
    },
    {
        HeroType.碧霄,
        new List<List<int>>()
        {
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
        }
    },
    {
        HeroType.琼霄,
        new List<List<int>>()
        {
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
        }
    },
    {
        HeroType.羲和,
        new List<List<int>>()
        {
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
        }
    },
    {
        HeroType.常羲,
        new List<List<int>>()
        {
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
        }
    },
    {
        HeroType.后羿,
        new List<List<int>>()
        {
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
        }
    },
    {
        HeroType.云霄,
        new List<List<int>>()
        {
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
        }
    },
    {
        HeroType.女娲,
        new List<List<int>>()
        {
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
        }
    },
    {
        HeroType.老子,
        new List<List<int>>()
        {
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
        }
    },
    {
        HeroType.通天,
        new List<List<int>>()
        {
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
        }
    },
    {
        HeroType.元始,
        new List<List<int>>()
        {
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
        }
    },
    {
        HeroType.鸿钧,
        new List<List<int>>()
        {
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
        }
    },
    {
        HeroType.盘古,
        new List<List<int>>()
        {
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 },
        }
    },
};
    public Dictionary<int, 丹药> 战斗选择丹药Dic = new Dictionary<int, 丹药>()
    {
        { 1, new 丹药() { 丹药Type = 丹药Type.None, QualityType = QualityType.None } },
        { 2, new 丹药() { 丹药Type = 丹药Type.None, QualityType = QualityType.None } },
        { 3, new 丹药() { 丹药Type = 丹药Type.None, QualityType = QualityType.None } },
    };

    public List<符文> 符文道文List = new List<符文>();
    public List<符文> 符文圣文List = new List<符文>();
    public List<符文> 符文帝文List = new List<符文>();
    public List<符文> 符文仙文List = new List<符文>();
    public List<符文> 符文灵文List = new List<符文>();

    
    // 按需写入的空字典：key 格式 {英雄}_{丹药Type}_{品质}_{N}阶，缺省即为未服用（0 次），
    // 不再全量预生成 英雄×类型×品质×阶段 的 0 值条目，节省存档体积
    public Dictionary<string, int> 英雄根基丹药服用Dic = new Dictionary<string, int>();

    public int Get英雄根基丹药服用(HeroType heroType,丹药Type  type,QualityType  qualityType,int 阶段 = 1)
    {
        string key = heroType + "_" + type+ "_" + qualityType + "_" + 阶段 + "阶";

        if (英雄根基丹药服用Dic.TryGetValue(key, out int count))
        {
            return count;
        }
        return 0;
    }

    public void Set英雄根基丹药服用(HeroType heroType,丹药Type  type,QualityType  qualityType,int count,int 阶段 = 1)
    {
        string key = heroType + "_" + type+ "_" + qualityType + "_" + 阶段 + "阶";

        英雄根基丹药服用Dic[key]= count;
    }
public List<QualityType>造化丹药List = new List<QualityType>();
// 与 造化丹药List 索引一一对应，记录每次服用的造化丹药阶段（旧档无记录时按 1 阶计）
public List<int> 造化丹药阶段List = new List<int>();
public QualityType 当前轮回造化丹药QualityType = QualityType.None;
// 按需写入的空字典：key 格式 {丹药Type}_{品质}_{N}阶，缺省即为无 buff（0 层）
    public Dictionary<string, int> 辅助丹药BuffDic = new Dictionary<string, int>(); 
    public Dictionary<QualityType, bool> 丹药灵药筛选Dic = new Dictionary<QualityType, bool>()
    {
        { QualityType.黄品 ,false},
        { QualityType.玄品 ,false},
        { QualityType.地品 ,false},
        { QualityType.天品 ,false},
        { QualityType.宇品 ,false},
        { QualityType.宙品 ,false},
        { QualityType.洪品 ,false},
        { QualityType.荒品 ,false},
    };

    public Dictionary<string, int> 丹方解锁Dic = new Dictionary<string, int>()
{
    // 火焰伤害
    {"火焰伤害_黄品", 1},
    {"火焰伤害_玄品", 0},
    {"火焰伤害_地品", 0},
    {"火焰伤害_天品", 0},
    {"火焰伤害_宇品", 0},
    {"火焰伤害_宙品", 0},
    {"火焰伤害_洪品", 0},
    {"火焰伤害_荒品", 0},
    
    // 冰霜伤害
    {"冰霜伤害_黄品", 0},
    {"冰霜伤害_玄品", 0},
    {"冰霜伤害_地品", 0},
    {"冰霜伤害_天品", 0},
    {"冰霜伤害_宇品", 0},
    {"冰霜伤害_宙品", 0},
    {"冰霜伤害_洪品", 0},
    {"冰霜伤害_荒品", 0},
    
    // 雷电伤害
    {"雷电伤害_黄品", 0},
    {"雷电伤害_玄品", 0},
    {"雷电伤害_地品", 0},
    {"雷电伤害_天品", 0},
    {"雷电伤害_宇品", 0},
    {"雷电伤害_宙品", 0},
    {"雷电伤害_洪品", 0},
    {"雷电伤害_荒品", 0},
    
    // 黑暗伤害
    {"黑暗伤害_黄品", 0},
    {"黑暗伤害_玄品", 0},
    {"黑暗伤害_地品", 0},
    {"黑暗伤害_天品", 0},
    {"黑暗伤害_宇品", 0},
    {"黑暗伤害_宙品", 0},
    {"黑暗伤害_洪品", 0},
    {"黑暗伤害_荒品", 0},
    
    // 物理伤害
    {"物理伤害_黄品", 0},
    {"物理伤害_玄品", 0},
    {"物理伤害_地品", 0},
    {"物理伤害_天品", 0},
    {"物理伤害_宇品", 0},
    {"物理伤害_宙品", 0},
    {"物理伤害_洪品", 0},
    {"物理伤害_荒品", 0},
    
    // 战士伤害
    {"战士伤害_黄品", 0},
    {"战士伤害_玄品", 0},
    {"战士伤害_地品", 0},
    {"战士伤害_天品", 0},
    {"战士伤害_宇品", 0},
    {"战士伤害_宙品", 0},
    {"战士伤害_洪品", 0},
    {"战士伤害_荒品", 0},
    
    // 法师伤害
    {"法师伤害_黄品", 0},
    {"法师伤害_玄品", 0},
    {"法师伤害_地品", 0},
    {"法师伤害_天品", 0},
    {"法师伤害_宇品", 0},
    {"法师伤害_宙品", 0},
    {"法师伤害_洪品", 0},
    {"法师伤害_荒品", 0},
    
    // 射手伤害
    {"射手伤害_黄品", 0},
    {"射手伤害_玄品", 0},
    {"射手伤害_地品", 0},
    {"射手伤害_天品", 0},
    {"射手伤害_宇品", 0},
    {"射手伤害_宙品", 0},
    {"射手伤害_洪品", 0},
    {"射手伤害_荒品", 0},
    
    // 控制伤害
    {"控制伤害_黄品", 0},
    {"控制伤害_玄品", 0},
    {"控制伤害_地品", 0},
    {"控制伤害_天品", 0},
    {"控制伤害_宇品", 0},
    {"控制伤害_宙品", 0},
    {"控制伤害_洪品", 0},
    {"控制伤害_荒品", 0},
    
    // 辅助伤害
    {"辅助伤害_黄品", 0},
    {"辅助伤害_玄品", 0},
    {"辅助伤害_地品", 0},
    {"辅助伤害_天品", 0},
    {"辅助伤害_宇品", 0},
    {"辅助伤害_宙品", 0},
    {"辅助伤害_洪品", 0},
    {"辅助伤害_荒品", 0},
    
    // 最终伤害
    {"最终伤害_黄品", 0},
    {"最终伤害_玄品", 0},
    {"最终伤害_地品", 0},
    {"最终伤害_天品", 0},
    {"最终伤害_宇品", 0},
    {"最终伤害_宙品", 0},
    {"最终伤害_洪品", 0},
    {"最终伤害_荒品", 0},
    
    // 修炼速度
    {"修炼速度_黄品", 0},
    {"修炼速度_玄品", 0},
    {"修炼速度_地品", 0},
    {"修炼速度_天品", 0},
    {"修炼速度_宇品", 0},
    {"修炼速度_宙品", 0},
    {"修炼速度_洪品", 0},
    {"修炼速度_荒品", 0},
    
    // 掉宝率
    {"掉宝率_黄品", 0},
    {"掉宝率_玄品", 0},
    {"掉宝率_地品", 0},
    {"掉宝率_天品", 0},
    {"掉宝率_宇品", 0},
    {"掉宝率_宙品", 0},
    {"掉宝率_洪品", 0},
    {"掉宝率_荒品", 0},
    
    // 英雄暴击伤害
    {"英雄暴击伤害_黄品", 0},
    {"英雄暴击伤害_玄品", 0},
    {"英雄暴击伤害_地品", 0},
    {"英雄暴击伤害_天品", 0},
    {"英雄暴击伤害_宇品", 0},
    {"英雄暴击伤害_宙品", 0},
    {"英雄暴击伤害_洪品", 0},
    {"英雄暴击伤害_荒品", 0},
    
    // 加跟脚
    {"加跟脚_黄品", 0},
    {"加跟脚_玄品", 0},
    {"加跟脚_地品", 0},
    {"加跟脚_天品", 0},
    {"加跟脚_宇品", 0},
    {"加跟脚_宙品", 0},
    {"加跟脚_洪品", 0},
    {"加跟脚_荒品", 0},
    
    // 英雄火焰伤害
    {"英雄火焰伤害_黄品", 0},
    {"英雄火焰伤害_玄品", 0},
    {"英雄火焰伤害_地品", 0},
    {"英雄火焰伤害_天品", 0},
    {"英雄火焰伤害_宇品", 0},
    {"英雄火焰伤害_宙品", 0},
    {"英雄火焰伤害_洪品", 0},
    {"英雄火焰伤害_荒品", 0},
    
    // 英雄冰霜伤害
    {"英雄冰霜伤害_黄品", 0},
    {"英雄冰霜伤害_玄品", 0},
    {"英雄冰霜伤害_地品", 0},
    {"英雄冰霜伤害_天品", 0},
    {"英雄冰霜伤害_宇品", 0},
    {"英雄冰霜伤害_宙品", 0},
    {"英雄冰霜伤害_洪品", 0},
    {"英雄冰霜伤害_荒品", 0},
    
    // 英雄雷电伤害
    {"英雄雷电伤害_黄品", 0},
    {"英雄雷电伤害_玄品", 0},
    {"英雄雷电伤害_地品", 0},
    {"英雄雷电伤害_天品", 0},
    {"英雄雷电伤害_宇品", 0},
    {"英雄雷电伤害_宙品", 0},
    {"英雄雷电伤害_洪品", 0},
    {"英雄雷电伤害_荒品", 0},
    
    // 英雄黑暗伤害
    {"英雄黑暗伤害_黄品", 0},
    {"英雄黑暗伤害_玄品", 0},
    {"英雄黑暗伤害_地品", 0},
    {"英雄黑暗伤害_天品", 0},
    {"英雄黑暗伤害_宇品", 0},
    {"英雄黑暗伤害_宙品", 0},
    {"英雄黑暗伤害_洪品", 0},
    {"英雄黑暗伤害_荒品", 0},
    
    // 英雄物理伤害
    {"英雄物理伤害_黄品", 0},
    {"英雄物理伤害_玄品", 0},
    {"英雄物理伤害_地品", 0},
    {"英雄物理伤害_天品", 0},
    {"英雄物理伤害_宇品", 0},
    {"英雄物理伤害_宙品", 0},
    {"英雄物理伤害_洪品", 0},
    {"英雄物理伤害_荒品", 0},
    
    // 英雄战士伤害
    {"英雄战士伤害_黄品", 0},
    {"英雄战士伤害_玄品", 0},
    {"英雄战士伤害_地品", 0},
    {"英雄战士伤害_天品", 0},
    {"英雄战士伤害_宇品", 0},
    {"英雄战士伤害_宙品", 0},
    {"英雄战士伤害_洪品", 0},
    {"英雄战士伤害_荒品", 0},
    
    // 英雄法师伤害
    {"英雄法师伤害_黄品", 0},
    {"英雄法师伤害_玄品", 0},
    {"英雄法师伤害_地品", 0},
    {"英雄法师伤害_天品", 0},
    {"英雄法师伤害_宇品", 0},
    {"英雄法师伤害_宙品", 0},
    {"英雄法师伤害_洪品", 0},
    {"英雄法师伤害_荒品", 0},
    
    // 英雄射手伤害
    {"英雄射手伤害_黄品", 0},
    {"英雄射手伤害_玄品", 0},
    {"英雄射手伤害_地品", 0},
    {"英雄射手伤害_天品", 0},
    {"英雄射手伤害_宇品", 0},
    {"英雄射手伤害_宙品", 0},
    {"英雄射手伤害_洪品", 0},
    {"英雄射手伤害_荒品", 0},
    
    // 英雄控制伤害
    {"英雄控制伤害_黄品", 0},
    {"英雄控制伤害_玄品", 0},
    {"英雄控制伤害_地品", 0},
    {"英雄控制伤害_天品", 0},
    {"英雄控制伤害_宇品", 0},
    {"英雄控制伤害_宙品", 0},
    {"英雄控制伤害_洪品", 0},
    {"英雄控制伤害_荒品", 0},
    
    // 英雄辅助伤害
    {"英雄辅助伤害_黄品", 0},
    {"英雄辅助伤害_玄品", 0},
    {"英雄辅助伤害_地品", 0},
    {"英雄辅助伤害_天品", 0},
    {"英雄辅助伤害_宇品", 0},
    {"英雄辅助伤害_宙品", 0},
    {"英雄辅助伤害_洪品", 0},
    {"英雄辅助伤害_荒品", 0},
    
    // 英雄最终伤害
    {"英雄最终伤害_黄品", 0},
    {"英雄最终伤害_玄品", 0},
    {"英雄最终伤害_地品", 0},
    {"英雄最终伤害_天品", 0},
    {"英雄最终伤害_宇品", 0},
    {"英雄最终伤害_宙品", 0},
    {"英雄最终伤害_洪品", 0},
    {"英雄最终伤害_荒品", 0},
};

    public Dictionary<灵植Type, int> 种子Dic = new Dictionary<灵植Type, int>()
    {
        { 灵植Type.紫云英, 0 },
        { 灵植Type.曜日葵, 0 },
        { 灵植Type.幻音铃, 0 },
        { 灵植Type.幻紫玫, 0 },
        { 灵植Type.九幽紫, 0 },
        { 灵植Type.赤焰百合, 0 },
        { 灵植Type.碧海螺, 0 },
        { 灵植Type.粉面佛莲, 0 },
        { 灵植Type.紫幽草, 0 },
        { 灵植Type.三生花, 0 },
        { 灵植Type.向阳花, 0 },
        { 灵植Type.白玉玲, 0 },
        { 灵植Type.赤阳花, 0 },
        { 灵植Type.寒星兰, 0 },
        { 灵植Type.赤霞花, 0 },
        { 灵植Type.惊雷子, 0 },
        { 灵植Type.幽兰铃, 0 },
        { 灵植Type.空谷幽兰, 0 },
        { 灵植Type.醉仙球, 0 },
        { 灵植Type.醉仙菌, 0 },
        { 灵植Type.太素花, 0 },
        { 灵植Type.灵犀铃, 0 },
        { 灵植Type.血菩提, 0 },
        { 灵植Type.紫晶铃, 0 },
        { 灵植Type.招财草, 0 },
        { 灵植Type.粉霞仙, 0 },
        { 灵植Type.黄龙掌, 0 },
        { 灵植Type.玄冰魄, 0 },
        { 灵植Type.修罗花, 0 },
        { 灵植Type.金乌葵, 0 },
        { 灵植Type.幻樱木, 0 },
        { 灵植Type.白玉莲, 0 },
    };
    public Dictionary<灵植Type, float> 普通收获Dic = new Dictionary<灵植Type, float>()
    {
        { 灵植Type.紫云英, 0 },
        { 灵植Type.曜日葵, 0 },
        { 灵植Type.幻音铃, 0 },
        { 灵植Type.幻紫玫, 0 },
        { 灵植Type.九幽紫, 0 },
        { 灵植Type.赤焰百合, 0 },
        { 灵植Type.碧海螺, 0 },
        { 灵植Type.粉面佛莲, 0 },
        { 灵植Type.紫幽草, 0 },
        { 灵植Type.三生花, 0 },
        { 灵植Type.向阳花, 0 },
        { 灵植Type.白玉玲, 0 },
        { 灵植Type.赤阳花, 0 },
        { 灵植Type.寒星兰, 0 },
        { 灵植Type.赤霞花, 0 },
        { 灵植Type.惊雷子, 0 },
        { 灵植Type.幽兰铃, 0 },
        { 灵植Type.空谷幽兰, 0 },
        { 灵植Type.醉仙球, 0 },
        { 灵植Type.醉仙菌, 0 },
        { 灵植Type.太素花, 0 },
        { 灵植Type.灵犀铃, 0 },
        { 灵植Type.血菩提, 0 },
        { 灵植Type.紫晶铃, 0 },
        { 灵植Type.招财草, 0 },
        { 灵植Type.粉霞仙, 0 },
        { 灵植Type.黄龙掌, 0 },
        { 灵植Type.玄冰魄, 0 },
        { 灵植Type.修罗花, 0 },
        { 灵植Type.金乌葵, 0 },
        { 灵植Type.幻樱木, 0 },
        { 灵植Type.白玉莲, 0 },
    };
    public Dictionary<灵植Type, float> 变异收获Dic = new Dictionary<灵植Type, float>()
    {
        { 灵植Type.紫云英, 0 },
        { 灵植Type.曜日葵, 0 },
        { 灵植Type.幻音铃, 0 },
        { 灵植Type.幻紫玫, 0 },
        { 灵植Type.九幽紫, 0 },
        { 灵植Type.赤焰百合, 0 },
        { 灵植Type.碧海螺, 0 },
        { 灵植Type.粉面佛莲, 0 },
        { 灵植Type.紫幽草, 0 },
        { 灵植Type.三生花, 0 },
        { 灵植Type.向阳花, 0 },
        { 灵植Type.白玉玲, 0 },
        { 灵植Type.赤阳花, 0 },
        { 灵植Type.寒星兰, 0 },
        { 灵植Type.赤霞花, 0 },
        { 灵植Type.惊雷子, 0 },
        { 灵植Type.幽兰铃, 0 },
        { 灵植Type.空谷幽兰, 0 },
        { 灵植Type.醉仙球, 0 },
        { 灵植Type.醉仙菌, 0 },
        { 灵植Type.太素花, 0 },
        { 灵植Type.灵犀铃, 0 },
        { 灵植Type.血菩提, 0 },
        { 灵植Type.紫晶铃, 0 },
        { 灵植Type.招财草, 0 },
        { 灵植Type.粉霞仙, 0 },
        { 灵植Type.黄龙掌, 0 },
        { 灵植Type.玄冰魄, 0 },
        { 灵植Type.修罗花, 0 },
        { 灵植Type.金乌葵, 0 },
        { 灵植Type.幻樱木, 0 },
        { 灵植Type.白玉莲, 0 },
    };

    public Dictionary<灵植Type, int> 普通服用次数Dic = 灵植园Config.创建服用次数Dic();
    public Dictionary<灵植Type, int> 变异服用次数Dic = 灵植园Config.创建服用次数Dic();

    public int 灵植园等级=1;
    public float 灵植园经验=0;
    public Dictionary<string, int> 肥料数量Dic = new Dictionary<string, int>()
    {
        { "提速_黄品", 0 },
        { "提速_玄品", 0 },
        { "提速_地品", 0 },
        { "提速_天品", 0 },
        { "提速_宇品", 0 },
        { "提速_宙品", 0 },
        { "提速_洪品", 0 },
        { "提速_荒品", 0 },
        
        { "增产_黄品", 0 },
        { "增产_玄品", 0 },
        { "增产_地品", 0 },
        { "增产_天品", 0 },
        { "增产_宇品", 0 },
        { "增产_宙品", 0 },
        { "增产_洪品", 0 },
        { "增产_荒品", 0 },
        
        { "延时_黄品", 0 },
        { "延时_玄品", 0 },
        { "延时_地品", 0 },
        { "延时_天品", 0 },
        { "延时_宇品", 0 },
        { "延时_宙品", 0 },
        { "延时_洪品", 0 },
        { "延时_荒品", 0 },
        
        { "异化_黄品", 0 },
        { "异化_玄品", 0 },
        { "异化_地品", 0 },
        { "异化_天品", 0 },
        { "异化_宇品", 0 },
        { "异化_宙品", 0 },
        { "异化_洪品", 0 },
        { "异化_荒品", 0 },
    };

    public float 青石 = 0;
    public Dictionary<string, int> 丹药Dic = 生成丹药Dic();

    /// <summary>
    /// 生成全量丹药库存字典：遍历 丹药Type × QualityType × 允许的阶段，数量均为 0。
    /// key 格式：{丹药Type}_{品质}_{阶段}阶，如「火焰伤害_黄品_1阶」。
    /// 坊市与炼丹产出的丹药默认都是 1 阶，各阶段库存独立计数。
    /// </summary>
    public static Dictionary<string, int> 生成丹药Dic()
    {
        var dic = new Dictionary<string, int>();
        foreach (丹药Type type in Enum.GetValues(typeof(丹药Type)))
        {
            if (type == 丹药Type.None) continue;
            foreach (QualityType quality in Enum.GetValues(typeof(QualityType)))
            {
                if (quality == QualityType.None) continue;
                for (int 阶段 = 1; 阶段 <= Get丹药最高阶段(quality); 阶段++)
                {
                    dic[type + "_" + quality + "_" + 阶段 + "阶"] = 0;
                }
            }
        }
        return dic;
    }

    /// <summary>
    /// 各品质丹药允许的最高阶段：黄品 1 阶、玄品 2 阶……洪品 7 阶，
    /// 与枚举值一一对应；荒品特殊，最高 9 阶。
    /// </summary>
    public static int Get丹药最高阶段(QualityType quality)
    {
        if (quality == QualityType.荒品) return 9;
        return (int)quality;
    }

    public 丹药Type Get丹药Type(string str)
    {
        if (string.IsNullOrEmpty(str))
            return 丹药Type.None;

        // 类型固定取第一段，兼容两种 key 格式：
        // "火焰伤害_黄品"（丹方）和 "火焰伤害_黄品_1阶"（丹药库存）
        string typeName = str.Split('_')[0];

        // 解析成枚举
        if (System.Enum.TryParse(typeName, out 丹药Type type))
            return type;

        return 丹药Type.None;
    }

    public  QualityType Get丹药品质(string str)
    {
        if (string.IsNullOrEmpty(str))
            return QualityType.None;

        // 品质固定为第二段，兼容 "火焰伤害_黄品" 与 "火焰伤害_黄品_1阶"
        var parts = str.Split('_');
        if (parts.Length < 2)
            return QualityType.None;

        // 解析成枚举
        if (Enum.TryParse(parts[1], out QualityType quality))
            return quality;

        return QualityType.None;
    }

    /// <summary>
    /// 解析丹药库存 key 的阶段数，例如 "火焰伤害_黄品_3阶" -> 3。
    /// 无阶段段的旧格式 key（如丹方的 "火焰伤害_黄品"）默认返回 1 阶。
    /// </summary>
    public int Get丹药阶段(string str)
    {
        if (string.IsNullOrEmpty(str))
            return 1;

        var parts = str.Split('_');
        if (parts.Length < 3)
            return 1;

        // 去掉「阶」字后缀后解析数字
        if (int.TryParse(parts[2].Replace("阶", ""), out int 阶段) && 阶段 >= 1 && 阶段 <= 9)
            return 阶段;

        return 1;
    }
    
     public Dictionary<string, int> 丹方Dic = new Dictionary<string, int>()
{
    // 火焰伤害
    {"火焰伤害_黄品", 0},
    {"火焰伤害_玄品", 0},
    {"火焰伤害_地品", 0},
    {"火焰伤害_天品", 0},
    {"火焰伤害_宇品", 0},
    {"火焰伤害_宙品", 0},
    {"火焰伤害_洪品", 0},
    {"火焰伤害_荒品", 0},
    
    // 冰霜伤害
    {"冰霜伤害_黄品", 0},
    {"冰霜伤害_玄品", 0},
    {"冰霜伤害_地品", 0},
    {"冰霜伤害_天品", 0},
    {"冰霜伤害_宇品", 0},
    {"冰霜伤害_宙品", 0},
    {"冰霜伤害_洪品", 0},
    {"冰霜伤害_荒品", 0},
    
    // 雷电伤害
    {"雷电伤害_黄品", 0},
    {"雷电伤害_玄品", 0},
    {"雷电伤害_地品", 0},
    {"雷电伤害_天品", 0},
    {"雷电伤害_宇品", 0},
    {"雷电伤害_宙品", 0},
    {"雷电伤害_洪品", 0},
    {"雷电伤害_荒品", 0},
    
    // 黑暗伤害
    {"黑暗伤害_黄品", 0},
    {"黑暗伤害_玄品", 0},
    {"黑暗伤害_地品", 0},
    {"黑暗伤害_天品", 0},
    {"黑暗伤害_宇品", 0},
    {"黑暗伤害_宙品", 0},
    {"黑暗伤害_洪品", 0},
    {"黑暗伤害_荒品", 0},
    
    // 物理伤害
    {"物理伤害_黄品", 0},
    {"物理伤害_玄品", 0},
    {"物理伤害_地品", 0},
    {"物理伤害_天品", 0},
    {"物理伤害_宇品", 0},
    {"物理伤害_宙品", 0},
    {"物理伤害_洪品", 0},
    {"物理伤害_荒品", 0},
    
    // 战士伤害
    {"战士伤害_黄品", 0},
    {"战士伤害_玄品", 0},
    {"战士伤害_地品", 0},
    {"战士伤害_天品", 0},
    {"战士伤害_宇品", 0},
    {"战士伤害_宙品", 0},
    {"战士伤害_洪品", 0},
    {"战士伤害_荒品", 0},
    
    // 法师伤害
    {"法师伤害_黄品", 0},
    {"法师伤害_玄品", 0},
    {"法师伤害_地品", 0},
    {"法师伤害_天品", 0},
    {"法师伤害_宇品", 0},
    {"法师伤害_宙品", 0},
    {"法师伤害_洪品", 0},
    {"法师伤害_荒品", 0},
    
    // 射手伤害
    {"射手伤害_黄品", 0},
    {"射手伤害_玄品", 0},
    {"射手伤害_地品", 0},
    {"射手伤害_天品", 0},
    {"射手伤害_宇品", 0},
    {"射手伤害_宙品", 0},
    {"射手伤害_洪品", 0},
    {"射手伤害_荒品", 0},
    
    // 控制伤害
    {"控制伤害_黄品", 0},
    {"控制伤害_玄品", 0},
    {"控制伤害_地品", 0},
    {"控制伤害_天品", 0},
    {"控制伤害_宇品", 0},
    {"控制伤害_宙品", 0},
    {"控制伤害_洪品", 0},
    {"控制伤害_荒品", 0},
    
    // 辅助伤害
    {"辅助伤害_黄品", 0},
    {"辅助伤害_玄品", 0},
    {"辅助伤害_地品", 0},
    {"辅助伤害_天品", 0},
    {"辅助伤害_宇品", 0},
    {"辅助伤害_宙品", 0},
    {"辅助伤害_洪品", 0},
    {"辅助伤害_荒品", 0},
    
    // 最终伤害
    {"最终伤害_黄品", 0},
    {"最终伤害_玄品", 0},
    {"最终伤害_地品", 0},
    {"最终伤害_天品", 0},
    {"最终伤害_宇品", 0},
    {"最终伤害_宙品", 0},
    {"最终伤害_洪品", 0},
    {"最终伤害_荒品", 0},
    
    // 修炼速度
    {"修炼速度_黄品", 0},
    {"修炼速度_玄品", 0},
    {"修炼速度_地品", 0},
    {"修炼速度_天品", 0},
    {"修炼速度_宇品", 0},
    {"修炼速度_宙品", 0},
    {"修炼速度_洪品", 0},
    {"修炼速度_荒品", 0},
    
    // 掉宝率
    {"掉宝率_黄品", 0},
    {"掉宝率_玄品", 0},
    {"掉宝率_地品", 0},
    {"掉宝率_天品", 0},
    {"掉宝率_宇品", 0},
    {"掉宝率_宙品", 0},
    {"掉宝率_洪品", 0},
    {"掉宝率_荒品", 0},
    
    // 英雄暴击伤害
    {"英雄暴击伤害_黄品", 0},
    {"英雄暴击伤害_玄品", 0},
    {"英雄暴击伤害_地品", 0},
    {"英雄暴击伤害_天品", 0},
    {"英雄暴击伤害_宇品", 0},
    {"英雄暴击伤害_宙品", 0},
    {"英雄暴击伤害_洪品", 0},
    {"英雄暴击伤害_荒品", 0},
    
    // 加跟脚
    {"加跟脚_黄品", 0},
    {"加跟脚_玄品", 0},
    {"加跟脚_地品", 0},
    {"加跟脚_天品", 0},
    {"加跟脚_宇品", 0},
    {"加跟脚_宙品", 0},
    {"加跟脚_洪品", 0},
    {"加跟脚_荒品", 0},
    
    // 英雄火焰伤害
    {"英雄火焰伤害_黄品", 0},
    {"英雄火焰伤害_玄品", 0},
    {"英雄火焰伤害_地品", 0},
    {"英雄火焰伤害_天品", 0},
    {"英雄火焰伤害_宇品", 0},
    {"英雄火焰伤害_宙品", 0},
    {"英雄火焰伤害_洪品", 0},
    {"英雄火焰伤害_荒品", 0},
    
    // 英雄冰霜伤害
    {"英雄冰霜伤害_黄品", 0},
    {"英雄冰霜伤害_玄品", 0},
    {"英雄冰霜伤害_地品", 0},
    {"英雄冰霜伤害_天品", 0},
    {"英雄冰霜伤害_宇品", 0},
    {"英雄冰霜伤害_宙品", 0},
    {"英雄冰霜伤害_洪品", 0},
    {"英雄冰霜伤害_荒品", 0},
    
    // 英雄雷电伤害
    {"英雄雷电伤害_黄品", 0},
    {"英雄雷电伤害_玄品", 0},
    {"英雄雷电伤害_地品", 0},
    {"英雄雷电伤害_天品", 0},
    {"英雄雷电伤害_宇品", 0},
    {"英雄雷电伤害_宙品", 0},
    {"英雄雷电伤害_洪品", 0},
    {"英雄雷电伤害_荒品", 0},
    
    // 英雄黑暗伤害
    {"英雄黑暗伤害_黄品", 0},
    {"英雄黑暗伤害_玄品", 0},
    {"英雄黑暗伤害_地品", 0},
    {"英雄黑暗伤害_天品", 0},
    {"英雄黑暗伤害_宇品", 0},
    {"英雄黑暗伤害_宙品", 0},
    {"英雄黑暗伤害_洪品", 0},
    {"英雄黑暗伤害_荒品", 0},
    
    // 英雄物理伤害
    {"英雄物理伤害_黄品", 0},
    {"英雄物理伤害_玄品", 0},
    {"英雄物理伤害_地品", 0},
    {"英雄物理伤害_天品", 0},
    {"英雄物理伤害_宇品", 0},
    {"英雄物理伤害_宙品", 0},
    {"英雄物理伤害_洪品", 0},
    {"英雄物理伤害_荒品", 0},
    
    // 英雄战士伤害
    {"英雄战士伤害_黄品", 0},
    {"英雄战士伤害_玄品", 0},
    {"英雄战士伤害_地品", 0},
    {"英雄战士伤害_天品", 0},
    {"英雄战士伤害_宇品", 0},
    {"英雄战士伤害_宙品", 0},
    {"英雄战士伤害_洪品", 0},
    {"英雄战士伤害_荒品", 0},
    
    // 英雄法师伤害
    {"英雄法师伤害_黄品", 0},
    {"英雄法师伤害_玄品", 0},
    {"英雄法师伤害_地品", 0},
    {"英雄法师伤害_天品", 0},
    {"英雄法师伤害_宇品", 0},
    {"英雄法师伤害_宙品", 0},
    {"英雄法师伤害_洪品", 0},
    {"英雄法师伤害_荒品", 0},
    
    // 英雄射手伤害
    {"英雄射手伤害_黄品", 0},
    {"英雄射手伤害_玄品", 0},
    {"英雄射手伤害_地品", 0},
    {"英雄射手伤害_天品", 0},
    {"英雄射手伤害_宇品", 0},
    {"英雄射手伤害_宙品", 0},
    {"英雄射手伤害_洪品", 0},
    {"英雄射手伤害_荒品", 0},
    
    // 英雄控制伤害
    {"英雄控制伤害_黄品", 0},
    {"英雄控制伤害_玄品", 0},
    {"英雄控制伤害_地品", 0},
    {"英雄控制伤害_天品", 0},
    {"英雄控制伤害_宇品", 0},
    {"英雄控制伤害_宙品", 0},
    {"英雄控制伤害_洪品", 0},
    {"英雄控制伤害_荒品", 0},
    
    // 英雄辅助伤害
    {"英雄辅助伤害_黄品", 0},
    {"英雄辅助伤害_玄品", 0},
    {"英雄辅助伤害_地品", 0},
    {"英雄辅助伤害_天品", 0},
    {"英雄辅助伤害_宇品", 0},
    {"英雄辅助伤害_宙品", 0},
    {"英雄辅助伤害_洪品", 0},
    {"英雄辅助伤害_荒品", 0},
    
    // 英雄最终伤害
    {"英雄最终伤害_黄品", 0},
    {"英雄最终伤害_玄品", 0},
    {"英雄最终伤害_地品", 0},
    {"英雄最终伤害_天品", 0},
    {"英雄最终伤害_宇品", 0},
    {"英雄最终伤害_宙品", 0},
    {"英雄最终伤害_洪品", 0},
    {"英雄最终伤害_荒品", 0},
};
    public Dictionary<神物Type, bool> 神物获得Dic = new Dictionary<神物Type, bool>()
    {
        { 神物Type.最终伤害, false },
        { 神物Type.冷却缩减, false },
        { 神物Type.全元素增伤, false },
        { 神物Type.元素人人为我, false },
        { 神物Type.元素我为人人, false },
        { 神物Type.全职业增伤, false },
        { 神物Type.职业我为人人, false },
        { 神物Type.职业人人为我, false },
        { 神物Type.暴击爆伤, false },
        { 神物Type.二次暴击, false },
        { 神物Type.轮回次数加伤, false },
        { 神物Type.轮回系数, false },
        { 神物Type.时间流速加快, false },
    };

    public int Get辅助丹药Buff(丹药Type type, QualityType qualityType, int 阶段 = 1)
    {
        string key = type.ToString() + "_" + qualityType.ToString() + "_" + 阶段 + "阶";
    
        if (辅助丹药BuffDic.TryGetValue(key, out int count))
        {
            return count;
        }
    
        return 0;
    }
    public bool Get丹方解锁(丹药Type type, QualityType qualityType)
    {
        string key = type.ToString() + "_" + qualityType.ToString();
    
        if (丹方解锁Dic.TryGetValue(key, out int count))
        {
            return count!=0;
        }
    
        return false;
    }
    public int Get丹药数量(丹药Type type, QualityType qualityType, int 阶段 = 1)
    {
        string key = type.ToString() + "_" + qualityType.ToString() + "_" + 阶段 + "阶";

        if (丹药Dic.TryGetValue(key, out int count))
        {
            return count;
        }

        return 0;
    }
    
    public int Get肥料数量(肥料Type type, QualityType qualityType)
    {
        string key = type.ToString() + "_" + qualityType.ToString();
    
        if (肥料数量Dic.TryGetValue(key, out int count))
        {
            return count;
        }
    
        return 0;
    }

    /// <summary>
    /// 服用一份灵植收获物。普通/变异分别计数，每种最多服用 灵植园Config.最大服用次数 次。
    /// 返回是否服用成功（扣除 1 个收获物 + 对应服用次数 +1）。
    /// </summary>
    public bool 服用灵植(灵植Type type, bool 变异)
    {
        var 次数Dic = 变异 ? 变异服用次数Dic : 普通服用次数Dic;
        var 收获Dic = 变异 ? 变异收获Dic : 普通收获Dic;
        if (次数Dic == null || 收获Dic == null)
        {
            ObserverModuleManager.S.SendEvent("SendUIToast", "数据异常");
            return false;
        }

        if (!次数Dic.TryGetValue(type, out int 已服用次数)) 已服用次数 = 0;
        if (已服用次数 >= 灵植园Config.最大服用次数)
        {
            ObserverModuleManager.S.SendEvent("SendUIToast", "已达最大服用次数");
            return false;
        }

        if (!收获Dic.TryGetValue(type, out float 数量) || 数量 <= 0)
        {
            ObserverModuleManager.S.SendEvent("SendUIToast", "数量不足");
            return false;
        }

        收获Dic[type] = 数量 - 1;
        次数Dic[type] = 已服用次数 + 1;
        return true;
    }
    
    public bool Get坊市丹药自动购买(丹药Type type, QualityType qualityType)
    {
        string key = type.ToString() + "_" + qualityType.ToString();
    
        if (坊市自动购买丹药配置.TryGetValue(key, out bool count))
        {
            return count;
        }
    
        return false;
    }
    
    public void Set坊市丹药自动购买(丹药Type type, QualityType qualityType, bool count)
    {
        // 索引器写入：老存档反序列化会整体替换字典，新增丹药（如掉宝率_寻龙丹）的
        // key 在旧存档里不存在，ContainsKey 旧写法会把数量静默吞掉
        string key = type.ToString() + "_" + qualityType.ToString();
        坊市自动购买丹药配置[key] = count;
    }
    
    public bool Get坊市丹方自动购买(丹药Type type, QualityType qualityType)
    {
        string key = type.ToString() + "_" + qualityType.ToString();
    
        if (坊市自动购买丹方配置.TryGetValue(key, out bool count))
        {
            return count;
        }
    
        return false;
    }
    
    
    
    public void Set坊市丹方自动购买(丹药Type type, QualityType qualityType, bool count)
    {
        // 索引器写入：老存档反序列化会整体替换字典，新增丹方（如掉宝率_寻龙丹）的
        // key 在旧存档里不存在，ContainsKey 旧写法会把数量静默吞掉
        string key = type.ToString() + "_" + qualityType.ToString();
        坊市自动购买丹方配置[key] = count;
    }
    
    
    public bool Get坊市法器自动购买(法器Type type)
    {
    
        if (坊市自动购买法器配置.TryGetValue(type, out bool count))
        {
            return count;
        }
    
        return false;
    }
    
    public void Set坊市法器自动购买(法器Type type, bool count)
    {
        // 索引器写入：老存档反序列化会整体替换字典，新增法器（如掉宝率_寻龙丹）的
        // key 在旧存档里不存在，ContainsKey 旧写法会把数量静默吞掉
        坊市自动购买法器配置[type] = count;
    }
    
    
    
    public bool Get坊市仙石自动购买(仙石Type type, QualityType qualityType)
    {
        string key = type.ToString() + "_" + qualityType.ToString();
    
        if (坊市自动购买仙石配置.TryGetValue(key, out bool count))
        {
            return count;
        }
    
        return false;
    }
    
    
    
    public void Set坊市仙石自动购买(仙石Type type, QualityType qualityType, bool count)
    {
        // 索引器写入：老存档反序列化会整体替换字典，新增仙石（如掉宝率_寻龙丹）的
        // key 在旧存档里不存在，ContainsKey 旧写法会把数量静默吞掉
        string key = type.ToString() + "_" + qualityType.ToString();
        坊市自动购买仙石配置[key] = count;
    }
    
    public int Get丹方数量(丹药Type type, QualityType qualityType)
    {
        string key = type.ToString() + "_" + qualityType.ToString();
    
        if (丹方Dic.TryGetValue(key, out int count))
        {
            return count;
        }
    
        return 0;
    }

    public void Set丹药数量(丹药Type type, QualityType qualityType, int count, int 阶段 = 1)
    {
        // 写入边界防线：None 一律拒收。战斗丹药槽默认就是 {None,None}，
        // 槽位空着时"取下/消耗"会把 "None_None" 写进字典，背包里出现 None 物品
        //（读档时虽被清理，但本次会话内一直显示）。正常购买/炼制/服用永远不会传 None
        if (type == 丹药Type.None || qualityType == QualityType.None)
        {
            return;
        }
        // 索引器写入：老存档反序列化会整体替换字典，新增丹药（如掉宝率_寻龙丹）的
        // key 在旧存档里不存在，ContainsKey 旧写法会把数量静默吞掉
        // 负数钳 0：服用弹窗数量滑条曾沿用过上次值，吃 1 颗按 60 颗扣成负数
        string key = type.ToString() + "_" + qualityType.ToString() + "_" + 阶段 + "阶";
        丹药Dic[key] = Math.Max(0, count);
    }
    
    public void Set肥料数量(肥料Type type, QualityType qualityType, int count)
    {
        // 写入边界防线：None 一律拒收。战斗丹药槽默认就是 {None,None}，
        // 槽位空着时"取下/消耗"会把 "None_None" 写进字典，背包里出现 None 物品
        //（读档时虽被清理，但本次会话内一直显示）。正常购买/炼制/服用永远不会传 None
        if (type == 肥料Type.None || qualityType == QualityType.None)
        {
            return;
        }
        // 索引器写入：老存档反序列化会整体替换字典，新增丹药（如掉宝率_寻龙丹）的
        // key 在旧存档里不存在，ContainsKey 旧写法会把数量静默吞掉
        // 负数钳 0：服用弹窗数量滑条曾沿用过上次值，吃 1 颗按 60 颗扣成负数
        string key = type.ToString() + "_" + qualityType.ToString();
        肥料数量Dic[key] = Math.Max(0, count);
    }

    public void Set辅助丹药Buff(丹药Type type, QualityType qualityType, int count, int 阶段 = 1)
    {
        if (type == 丹药Type.None || qualityType == QualityType.None)
        {
            return;
        }
        string key = type.ToString() + "_" + qualityType.ToString() + "_" + 阶段 + "阶";
        辅助丹药BuffDic[key] = count;
    }

    public void Set丹方解锁(丹药Type type, QualityType qualityType, bool count)
    {
        if (type == 丹药Type.None || qualityType == QualityType.None)
        {
            return;
        }
        string key = type.ToString() + "_" + qualityType.ToString();
        丹方解锁Dic[key] = count?1:0;
    }

    public void Set丹方数量(丹药Type type, QualityType qualityType, int count)
    {
        if (type == 丹药Type.None || qualityType == QualityType.None)
        {
            return;
        }
        string key = type.ToString() + "_" + qualityType.ToString();
        丹方Dic[key] = count;
    }
    
    
    public int Get灵物数量(JingJieType jingJieType, QualityType qualityType)
    {
        string value = JingJieConfig.JingJieNameDic[jingJieType]+"_"+PropConfig.QualityNameDic[qualityType];
        // 缺键返回0：老存档（新增境界/品质后反序列化的旧字典）或未初始化的境界不应抛异常中断结算
        return 突破灵物Dic.TryGetValue(value, out int count) ? count : 0;
    }

    public void Set灵物数量(JingJieType jingJieType, QualityType qualityType, int count)
    {
        string value = JingJieConfig.JingJieNameDic[jingJieType]+"_"+PropConfig.QualityNameDic[qualityType];
        突破灵物Dic[value]=count;
    }

    public Dictionary<string, int> 灵药Dic = new Dictionary<string, int>()
    {
        // 金银花蕊
        { "金银花蕊_黄品", 0 },
        { "金银花蕊_玄品", 0 },
        { "金银花蕊_地品", 0 },
        { "金银花蕊_天品", 0 },
        { "金银花蕊_宇品", 0 },
        { "金银花蕊_宙品", 0 },
        { "金银花蕊_洪品", 0 },
        { "金银花蕊_荒品", 0 },

        // 马兜铃果
        { "马兜铃果_黄品", 0 },
        { "马兜铃果_玄品", 0 },
        { "马兜铃果_地品", 0 },
        { "马兜铃果_天品", 0 },
        { "马兜铃果_宇品", 0 },
        { "马兜铃果_宙品", 0 },
        { "马兜铃果_洪品", 0 },
        { "马兜铃果_荒品", 0 },

        // 四叶参根
        { "四叶参根_黄品", 0 },
        { "四叶参根_玄品", 0 },
        { "四叶参根_地品", 0 },
        { "四叶参根_天品", 0 },
        { "四叶参根_宇品", 0 },
        { "四叶参根_宙品", 0 },
        { "四叶参根_洪品", 0 },
        { "四叶参根_荒品", 0 },

        // 千年雪莲
        { "千年雪莲_黄品", 0 },
        { "千年雪莲_玄品", 0 },
        { "千年雪莲_地品", 0 },
        { "千年雪莲_天品", 0 },
        { "千年雪莲_宇品", 0 },
        { "千年雪莲_宙品", 0 },
        { "千年雪莲_洪品", 0 },
        { "千年雪莲_荒品", 0 },

        // 回春草
        { "回春草_黄品", 0 },
        { "回春草_玄品", 0 },
        { "回春草_地品", 0 },
        { "回春草_天品", 0 },
        { "回春草_宇品", 0 },
        { "回春草_宙品", 0 },
        { "回春草_洪品", 0 },
        { "回春草_荒品", 0 },

        // 补血花
        { "补血花_黄品", 0 },
        { "补血花_玄品", 0 },
        { "补血花_地品", 0 },
        { "补血花_天品", 0 },
        { "补血花_宇品", 0 },
        { "补血花_宙品", 0 },
        { "补血花_洪品", 0 },
        { "补血花_荒品", 0 },

        // 龙纹草
        { "龙纹草_黄品", 0 },
        { "龙纹草_玄品", 0 },
        { "龙纹草_地品", 0 },
        { "龙纹草_天品", 0 },
        { "龙纹草_宇品", 0 },
        { "龙纹草_宙品", 0 },
        { "龙纹草_洪品", 0 },
        { "龙纹草_荒品", 0 },

        // 九曲黄泉草
        { "九曲黄泉草_黄品", 0 },
        { "九曲黄泉草_玄品", 0 },
        { "九曲黄泉草_地品", 0 },
        { "九曲黄泉草_天品", 0 },
        { "九曲黄泉草_宇品", 0 },
        { "九曲黄泉草_宙品", 0 },
        { "九曲黄泉草_洪品", 0 },
        { "九曲黄泉草_荒品", 0 },

        // 千幻蝶恋花
        { "千幻蝶恋花_黄品", 0 },
        { "千幻蝶恋花_玄品", 0 },
        { "千幻蝶恋花_地品", 0 },
        { "千幻蝶恋花_天品", 0 },
        { "千幻蝶恋花_宇品", 0 },
        { "千幻蝶恋花_宙品", 0 },
        { "千幻蝶恋花_洪品", 0 },
        { "千幻蝶恋花_荒品", 0 },

        // 聚灵凝神叶
        { "聚灵凝神叶_黄品", 0 },
        { "聚灵凝神叶_玄品", 0 },
        { "聚灵凝神叶_地品", 0 },
        { "聚灵凝神叶_天品", 0 },
        { "聚灵凝神叶_宇品", 0 },
        { "聚灵凝神叶_宙品", 0 },
        { "聚灵凝神叶_洪品", 0 },
        { "聚灵凝神叶_荒品", 0 },
    };

    public int Get灵药数量(灵药Type type, QualityType qualityType)
    {
        string key = $"{type}_{qualityType}";
        if (灵药Dic.ContainsKey(key))
            return 灵药Dic[key];
        return 0;
    }

    public void Set灵药数量(灵药Type type, QualityType qualityType, int count)
    {
        string key = $"{type}_{qualityType}";
        灵药Dic[key] = count;
    }


    public Dictionary<string, int> 突破灵物Dic = new Dictionary<string, int>()
{
    // 增加百分比攻击力
    { "练气_黄品", 0 },
    { "练气_玄品", 0 },
    { "练气_地品", 0 },
    { "练气_天品", 0 },
    { "练气_宇品", 0 },
    { "练气_宙品", 0 },
    { "练气_洪品", 0 },
    { "练气_荒品", 0 },

    { "筑基_黄品", 0 },
    { "筑基_玄品", 0 },
    { "筑基_地品", 0 },
    { "筑基_天品", 0 },
    { "筑基_宇品", 0 },
    { "筑基_宙品", 0 },
    { "筑基_洪品", 0 },
    { "筑基_荒品", 0 },

    { "金丹_黄品", 0 },
    { "金丹_玄品", 0 },
    { "金丹_地品", 0 },
    { "金丹_天品", 0 },
    { "金丹_宇品", 0 },
    { "金丹_宙品", 0 },
    { "金丹_洪品", 0 },
    { "金丹_荒品", 0 },

    { "元婴_黄品", 0 },
    { "元婴_玄品", 0 },
    { "元婴_地品", 0 },
    { "元婴_天品", 0 },
    { "元婴_宇品", 0 },
    { "元婴_宙品", 0 },
    { "元婴_洪品", 0 },
    { "元婴_荒品", 0 },

    { "化神_黄品", 0 },
    { "化神_玄品", 0 },
    { "化神_地品", 0 },
    { "化神_天品", 0 },
    { "化神_宇品", 0 },
    { "化神_宙品", 0 },
    { "化神_洪品", 0 },
    { "化神_荒品", 0 },

    { "合体_黄品", 0 },
    { "合体_玄品", 0 },
    { "合体_地品", 0 },
    { "合体_天品", 0 },
    { "合体_宇品", 0 },
    { "合体_宙品", 0 },
    { "合体_洪品", 0 },
    { "合体_荒品", 0 },

    { "大乘_黄品", 0 },
    { "大乘_玄品", 0 },
    { "大乘_地品", 0 },
    { "大乘_天品", 0 },
    { "大乘_宇品", 0 },
    { "大乘_宙品", 0 },
    { "大乘_洪品", 0 },
    { "大乘_荒品", 0 },

    { "天仙_黄品", 0 },
    { "天仙_玄品", 0 },
    { "天仙_地品", 0 },
    { "天仙_天品", 0 },
    { "天仙_宇品", 0 },
    { "天仙_宙品", 0 },
    { "天仙_洪品", 0 },
    { "天仙_荒品", 0 },

    { "玄仙_黄品", 0 },
    { "玄仙_玄品", 0 },
    { "玄仙_地品", 0 },
    { "玄仙_天品", 0 },
    { "玄仙_宇品", 0 },
    { "玄仙_宙品", 0 },
    { "玄仙_洪品", 0 },
    { "玄仙_荒品", 0 },

    { "金仙_黄品", 0 },
    { "金仙_玄品", 0 },
    { "金仙_地品", 0 },
    { "金仙_天品", 0 },
    { "金仙_宇品", 0 },
    { "金仙_宙品", 0 },
    { "金仙_洪品", 0 },
    { "金仙_荒品", 0 },

    { "太乙金仙_黄品", 0 },
    { "太乙金仙_玄品", 0 },
    { "太乙金仙_地品", 0 },
    { "太乙金仙_天品", 0 },
    { "太乙金仙_宇品", 0 },
    { "太乙金仙_宙品", 0 },
    { "太乙金仙_洪品", 0 },
    { "太乙金仙_荒品", 0 },

    { "大罗金仙_黄品", 0 },
    { "大罗金仙_玄品", 0 },
    { "大罗金仙_地品", 0 },
    { "大罗金仙_天品", 0 },
    { "大罗金仙_宇品", 0 },
    { "大罗金仙_宙品", 0 },
    { "大罗金仙_洪品", 0 },
    { "大罗金仙_荒品", 0 },

    { "准圣_黄品", 0 },
    { "准圣_玄品", 0 },
    { "准圣_地品", 0 },
    { "准圣_天品", 0 },
    { "准圣_宇品", 0 },
    { "准圣_宙品", 0 },
    { "准圣_洪品", 0 },
    { "准圣_荒品", 0 },

    { "圣人_黄品", 0 },
    { "圣人_玄品", 0 },
    { "圣人_地品", 0 },
    { "圣人_天品", 0 },
    { "圣人_宇品", 0 },
    { "圣人_宙品", 0 },
    { "圣人_洪品", 0 },
    { "圣人_荒品", 0 },

    { "天道圣人_黄品", 0 },
    { "天道圣人_玄品", 0 },
    { "天道圣人_地品", 0 },
    { "天道圣人_天品", 0 },
    { "天道圣人_宇品", 0 },
    { "天道圣人_宙品", 0 },
    { "天道圣人_洪品", 0 },
    { "天道圣人_荒品", 0 },

    { "大道圣人_黄品", 0 },
    { "大道圣人_玄品", 0 },
    { "大道圣人_地品", 0 },
    { "大道圣人_天品", 0 },
    { "大道圣人_宇品", 0 },
    { "大道圣人_宙品", 0 },
    { "大道圣人_洪品", 0 },
    { "大道圣人_荒品", 0 },

    { "混元圣人_黄品", 0 },
    { "混元圣人_玄品", 0 },
    { "混元圣人_地品", 0 },
    { "混元圣人_天品", 0 },
    { "混元圣人_宇品", 0 },
    { "混元圣人_宙品", 0 },
    { "混元圣人_洪品", 0 },
    { "混元圣人_荒品", 0 },

    { "鸿蒙_黄品", 0 },
    { "鸿蒙_玄品", 0 },
    { "鸿蒙_地品", 0 },
    { "鸿蒙_天品", 0 },
    { "鸿蒙_宇品", 0 },
    { "鸿蒙_宙品", 0 },
    { "鸿蒙_洪品", 0 },
    { "鸿蒙_荒品", 0 },
};
    
    public Dictionary<功法Type, int> 功法数量Dic = new Dictionary<功法Type, int>()
    {
        // 战士系列
        { 功法Type.战士白, 0 },
        { 功法Type.战士绿, 0 },
        { 功法Type.战士蓝, 0 },
        { 功法Type.战士紫, 0 },
        { 功法Type.战士粉, 0 },
        { 功法Type.战士红, 0 },
        { 功法Type.战士橙, 0 },
        { 功法Type.战士彩, 0 },

        // 射手系列
        { 功法Type.射手白, 0 },
        { 功法Type.射手绿, 0 },
        { 功法Type.射手蓝, 0 },
        { 功法Type.射手紫, 0 },
        { 功法Type.射手粉, 0 },
        { 功法Type.射手红, 0 },
        { 功法Type.射手橙, 0 },
        { 功法Type.射手彩, 0 },

        // 控制系列
        { 功法Type.控制白, 0 },
        { 功法Type.控制绿, 0 },
        { 功法Type.控制蓝, 0 },
        { 功法Type.控制紫, 0 },
        { 功法Type.控制粉, 0 },
        { 功法Type.控制红, 0 },
        { 功法Type.控制橙, 0 },
        { 功法Type.控制彩, 0 },

        // 辅助系列
        { 功法Type.辅助白, 0 },
        { 功法Type.辅助绿, 0 },
        { 功法Type.辅助蓝, 0 },
        { 功法Type.辅助紫, 0 },
        { 功法Type.辅助粉, 0 },
        { 功法Type.辅助红, 0 },
        { 功法Type.辅助橙, 0 },
        { 功法Type.辅助彩, 0 },

        // 法师系列
        { 功法Type.法师白, 0 },
        { 功法Type.法师绿, 0 },
        { 功法Type.法师蓝, 0 },
        { 功法Type.法师紫, 0 },
        { 功法Type.法师粉, 0 },
        { 功法Type.法师红, 0 },
        { 功法Type.法师橙, 0 },
        { 功法Type.法师彩, 0 },
    };
    public Dictionary<PropType, int> 获取不周山所有道具()
    {
        Dictionary<PropType, int> 类型数量映射 = new Dictionary<PropType, int>();
        foreach (var kvp in 不周山寻宝Dic)
        { 
            foreach (var 道具 in kvp.Value.list)
            {
                if (类型数量映射.ContainsKey(道具.法则Type))
                {
                    类型数量映射[道具.法则Type] += 道具.count;
                }
                else
                {
                    类型数量映射[道具.法则Type] = 道具.count;
                }
            }
        }
        return 类型数量映射;
    }

    public IEnumerator 收获不周山()
    {
        var list = 获取不周山所有道具();
        foreach (var item in 不周山寻宝Dic)
        {
            foreach (var i in item.Value.list)
            {
                PropListDic[i.法则Type]+=i.count;
            }
            item.Value.list.Clear();
        }
        foreach (var item in list)
        {
            ObserverModuleManager.S.SendEvent("SendUIToast",法则config.法则名Dic[法则config.法则英雄Dic[item.Key]],PropConfig.GetProp品质(item.Key),item.Value);
            ObserverModuleManager.S.SendEvent("播放音效",音效Type.成功);
            yield return new  WaitForSeconds(0.1f);
        }
    }

    public void 清除不周山无用派遣英雄()
    {
        foreach (var 寻宝Item in 不周山寻宝Dic)
        {
            if (!寻宝Item.Value.寻宝)
            {
                for (int i = 0; i < 不周山英雄派遣Dic[寻宝Item.Key].Count; i++)
                {
                    if (不周山英雄派遣Dic[寻宝Item.Key][i] != HeroType.None)
                    {
                        HeroDataDic[不周山英雄派遣Dic[寻宝Item.Key][i]].派遣 = false;
                        不周山英雄派遣Dic[寻宝Item.Key][i] = HeroType.None;
                    }
                }
            }
        }
    }
    public Dictionary<int, 不周山秘境寻宝Item> 不周山寻宝Dic = new Dictionary<int, 不周山秘境寻宝Item>()
    {
        {1,new 不周山秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝法则道具item>()}},
        {2,new 不周山秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝法则道具item>()}},
        {3,new 不周山秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝法则道具item>()}},
        {4,new 不周山秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝法则道具item>()}},
        {5,new 不周山秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝法则道具item>()}},
        {6,new 不周山秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝法则道具item>()}},
        {7,new 不周山秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝法则道具item>()}},
        {8,new 不周山秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝法则道具item>()}},
    };
    public Dictionary<int, List<HeroType>> 不周山英雄派遣Dic = new Dictionary<int, List<HeroType>>()
    {
        { 1, new List<HeroType>() { HeroType.None ,HeroType.None,HeroType.None}},
        { 2, new List<HeroType>() { HeroType.None ,HeroType.None,HeroType.None}},
        { 3, new List<HeroType>() { HeroType.None ,HeroType.None,HeroType.None,HeroType.None}},
        { 4, new List<HeroType>() { HeroType.None ,HeroType.None,HeroType.None,HeroType.None}},
        { 5, new List<HeroType>() { HeroType.None ,HeroType.None,HeroType.None,HeroType.None}},
        { 6, new List<HeroType>() { HeroType.None ,HeroType.None,HeroType.None,HeroType.None}},
        { 7, new List<HeroType>() { HeroType.None ,HeroType.None,HeroType.None,HeroType.None}},
        { 8, new List<HeroType>() { HeroType.None ,HeroType.None,HeroType.None,HeroType.None}},
    };
    public IEnumerator 收获血海()
    {
        var list = 获取血海所有道具();
        foreach (var item in 血海寻宝Dic)
        {
            foreach (var i in item.Value.list)
            {
                Set灵药数量(i.灵药.灵药Type,i.灵药.QualityType,i.count+Get灵药数量(i.灵药.灵药Type,i.灵药.QualityType));
            }
            item.Value.list.Clear();
        }
        foreach (var item in list)
        {
            ObserverModuleManager.S.SendEvent("SendUIToast",丹药Config.灵药名Dic[item.Key.灵药Type],item.Key.QualityType,item.Value);
            ObserverModuleManager.S.SendEvent("播放音效",音效Type.成功);
            yield return new  WaitForSeconds(0.1f);
        }
    }
    public Dictionary<灵药, int> 获取血海所有道具()
    {
        Dictionary<灵药, int> 类型数量映射 = new Dictionary<灵药, int>();
        foreach (var kvp in 血海寻宝Dic)
        { 
            foreach (var 道具 in kvp.Value.list)
            {
                if (类型数量映射.ContainsKey(道具.灵药))
                {
                    类型数量映射[道具.灵药] += 道具.count;
                }
                else
                {
                    类型数量映射[道具.灵药] = 道具.count;
                }
            }
        }
        return 类型数量映射;
    }
    
    

    public void 清除血海无用派遣英雄()
    {
        foreach (var 寻宝Item in 血海寻宝Dic)
        {
            if (!寻宝Item.Value.寻宝)
            {
                for (int i = 0; i < 血海英雄派遣Dic[寻宝Item.Key].Count; i++)
                {
                    if (血海英雄派遣Dic[寻宝Item.Key][i] != HeroType.None)
                    {
                        HeroDataDic[血海英雄派遣Dic[寻宝Item.Key][i]].派遣 = false;
                        血海英雄派遣Dic[寻宝Item.Key][i] = HeroType.None;
                    }
                }
            }
        }
    }
    
    public void 清除世界树无用派遣英雄()
    {
        foreach (var 寻宝Item in 世界树寻宝Dic)
        {
            if (!寻宝Item.Value.寻宝)
            {
                for (int i = 0; i < 世界树英雄派遣Dic[寻宝Item.Key].Count; i++)
                {
                    if (世界树英雄派遣Dic[寻宝Item.Key][i] != HeroType.None)
                    {
                        HeroDataDic[世界树英雄派遣Dic[寻宝Item.Key][i]].派遣 = false;
                        世界树英雄派遣Dic[寻宝Item.Key][i] = HeroType.None;
                    }
                }
            }
        }
    }
    public void 清除通天塔无用派遣英雄()
    {
        foreach (var 寻宝Item in 通天塔寻宝Dic)
        {
            if (!寻宝Item.Value.寻宝)
            {
                for (int i = 0; i < 通天塔英雄派遣Dic[寻宝Item.Key].Count; i++)
                {
                    if (通天塔英雄派遣Dic[寻宝Item.Key][i] != HeroType.None)
                    {
                        HeroDataDic[通天塔英雄派遣Dic[寻宝Item.Key][i]].派遣 = false;
                        通天塔英雄派遣Dic[寻宝Item.Key][i] = HeroType.None;
                    }
                }
            }
        }
    }
    
    public Dictionary<int, 血海秘境寻宝Item> 血海寻宝Dic = new Dictionary<int, 血海秘境寻宝Item>()
    {
        {1,new 血海秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝灵药道具item>()}},
        {2,new 血海秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝灵药道具item>()}},
        {3,new 血海秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝灵药道具item>()}},
        {4,new 血海秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝灵药道具item>()}},
        {5,new 血海秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝灵药道具item>()}},
        {6,new 血海秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝灵药道具item>()}},
        {7,new 血海秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝灵药道具item>()}},
        {8,new 血海秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝灵药道具item>()}},
        {9,new 血海秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝灵药道具item>()}},
    };
    public Dictionary<int, List<HeroType>> 血海英雄派遣Dic = new Dictionary<int, List<HeroType>>()
    {
        { 1, new List<HeroType>() { HeroType.None ,HeroType.None}},
        { 2, new List<HeroType>() { HeroType.None ,HeroType.None,HeroType.None}},
        { 3, new List<HeroType>() { HeroType.None ,HeroType.None,HeroType.None}},
        { 4, new List<HeroType>() { HeroType.None ,HeroType.None,HeroType.None,HeroType.None}},
        { 5, new List<HeroType>() { HeroType.None ,HeroType.None,HeroType.None,HeroType.None}},
        { 6, new List<HeroType>() { HeroType.None ,HeroType.None,HeroType.None,HeroType.None}},
        { 7, new List<HeroType>() { HeroType.None ,HeroType.None,HeroType.None,HeroType.None}},
        { 8, new List<HeroType>() { HeroType.None ,HeroType.None,HeroType.None,HeroType.None}},
        { 9, new List<HeroType>() { HeroType.None ,HeroType.None,HeroType.None,HeroType.None}},
    };
    public IEnumerator 收获世界树()
    {
        var list = 获取世界树所有道具();
        foreach (var item in 世界树寻宝Dic)
        {
            foreach (var i in item.Value.list)
            {
                道宝LevelDic[i.道宝Type] += i.count;
            }
            item.Value.list.Clear();
        }
        foreach (var item in list)
        {
            ObserverModuleManager.S.SendEvent("SendUIToast",道宝Config.道宝NameDic[item.Key],道宝Config.道宝QualityToQuality[道宝Config.道宝品质Dic[item.Key]],item.Value);
            ObserverModuleManager.S.SendEvent("播放音效",音效Type.成功);
            yield return new  WaitForSeconds(0.1f);
        }
    }
    public Dictionary<道宝Type, int> 获取世界树所有道具()
    {
        Dictionary<道宝Type, int> 类型数量映射 = new Dictionary<道宝Type, int>();
        foreach (var kvp in 世界树寻宝Dic)
        { 
            foreach (var 道具 in kvp.Value.list)
            {
                if (类型数量映射.ContainsKey(道具.道宝Type))
                {
                    类型数量映射[道具.道宝Type] += 道具.count;
                }
                else
                {
                    类型数量映射[道具.道宝Type] = 道具.count;
                }
            }
        }
        return 类型数量映射;
    }
    public Dictionary<int, 世界树秘境寻宝Item> 世界树寻宝Dic = new Dictionary<int, 世界树秘境寻宝Item>()
    {
        {1,new 世界树秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝道宝道具item>()}},
        {2,new 世界树秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝道宝道具item>()}},
        {3,new 世界树秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝道宝道具item>()}},
        {4,new 世界树秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝道宝道具item>()}},
        {5,new 世界树秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝道宝道具item>()}},
        {6,new 世界树秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝道宝道具item>()}},
        {7,new 世界树秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝道宝道具item>()}},
        {8,new 世界树秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝道宝道具item>()}},
        {9,new 世界树秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝道宝道具item>()}},
    };
    public Dictionary<int, List<HeroType>> 世界树英雄派遣Dic = new Dictionary<int, List<HeroType>>()
    {
        { 1, new List<HeroType>() { HeroType.None ,HeroType.None}},
        { 2, new List<HeroType>() { HeroType.None ,HeroType.None,HeroType.None}},
        { 3, new List<HeroType>() { HeroType.None ,HeroType.None,HeroType.None}},
        { 4, new List<HeroType>() { HeroType.None ,HeroType.None,HeroType.None,HeroType.None}},
        { 5, new List<HeroType>() { HeroType.None ,HeroType.None,HeroType.None,HeroType.None}},
        { 6, new List<HeroType>() { HeroType.None ,HeroType.None,HeroType.None,HeroType.None}},
        { 7, new List<HeroType>() { HeroType.None ,HeroType.None,HeroType.None,HeroType.None}},
        { 8, new List<HeroType>() { HeroType.None ,HeroType.None,HeroType.None,HeroType.None}},
        { 9, new List<HeroType>() { HeroType.None ,HeroType.None,HeroType.None,HeroType.None}},
    };
    
    public IEnumerator 收获通天塔()
    {
        var list = 获取通天塔所有道具();
        foreach (var item in 通天塔寻宝Dic)
        {
            foreach (var i in item.Value.list)
            {
                城墙道具等级Dic[i.城墙道具Type] += i.count;
            }
            item.Value.list.Clear();
        }
        foreach (var item in list)
        {
            ObserverModuleManager.S.SendEvent("SendUIToast",城墙Config.城墙道具名Dic[item.Key],城墙Config.城墙道具QualityDic[item.Key],item.Value);
            ObserverModuleManager.S.SendEvent("播放音效",音效Type.成功);
            yield return new  WaitForSeconds(0.1f);
        }
    }
    public Dictionary<城墙道具Type, int> 获取通天塔所有道具()
    {
        Dictionary<城墙道具Type, int> 类型数量映射 = new Dictionary<城墙道具Type, int>();
        foreach (var kvp in 通天塔寻宝Dic)
        { 
            foreach (var 道具 in kvp.Value.list)
            {
                if (类型数量映射.ContainsKey(道具.城墙道具Type))
                {
                    类型数量映射[道具.城墙道具Type] += 道具.count;
                }
                else
                {
                    类型数量映射[道具.城墙道具Type] = 道具.count;
                }
            }
        }
        return 类型数量映射;
    }
    public Dictionary<int, 秘境寻宝Item> 通天塔寻宝Dic = new Dictionary<int, 秘境寻宝Item>()
    {
        {1,new 秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝城墙道具item>()}},
        {2,new 秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝城墙道具item>()}},
        {3,new 秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝城墙道具item>()}},
        {4,new 秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝城墙道具item>()}},
        {5,new 秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝城墙道具item>()}},
        {6,new 秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝城墙道具item>()}},
        {7,new 秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝城墙道具item>()}},
        {8,new 秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝城墙道具item>()}},
        {9,new 秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝城墙道具item>()}},
        {10,new 秘境寻宝Item(){寻宝=false,time = 0,重复=false,list=new List<寻宝城墙道具item>()}},
    };
    public Dictionary<int, List<HeroType>> 通天塔英雄派遣Dic = new Dictionary<int, List<HeroType>>()
    {
        { 1, new List<HeroType>() { HeroType.None ,HeroType.None}},
        { 2, new List<HeroType>() { HeroType.None ,HeroType.None}},
        { 3, new List<HeroType>() { HeroType.None ,HeroType.None,HeroType.None}},
        { 4, new List<HeroType>() { HeroType.None ,HeroType.None,HeroType.None}},
        { 5, new List<HeroType>() { HeroType.None ,HeroType.None,HeroType.None,HeroType.None}},
        { 6, new List<HeroType>() { HeroType.None ,HeroType.None,HeroType.None,HeroType.None}},
        { 7, new List<HeroType>() { HeroType.None ,HeroType.None,HeroType.None,HeroType.None}},
        { 8, new List<HeroType>() { HeroType.None ,HeroType.None,HeroType.None,HeroType.None}},
        { 9, new List<HeroType>() { HeroType.None ,HeroType.None,HeroType.None,HeroType.None}},
        { 10, new List<HeroType>() { HeroType.None ,HeroType.None}},
    };
    public Dictionary<QualityType, 城墙道具Type> 当前装备城墙道具Dic = new Dictionary<QualityType, 城墙道具Type>()
    {
        { QualityType.黄品 ,城墙道具Type.None},
        { QualityType.玄品 ,城墙道具Type.None},
        { QualityType.地品 ,城墙道具Type.None},
        { QualityType.天品 ,城墙道具Type.None},
        { QualityType.宇品 ,城墙道具Type.None},
        { QualityType.宙品 ,城墙道具Type.None},
        { QualityType.洪品 ,城墙道具Type.None},
        { QualityType.荒品 ,城墙道具Type.None},
    };
    public Dictionary<城墙道具Type, int> 城墙道具等级Dic = new Dictionary<城墙道具Type, int>()
    {
        { 城墙道具Type.不动明王阵, 0 },
        { 城墙道具Type.不周山柱, 0 },
        { 城墙道具Type.不朽魂晶, 0 },
        { 城墙道具Type.不死木, 0 },
        { 城墙道具Type.不灭玄石, 0 },
        { 城墙道具Type.九曲黄河阵, 0 },
        { 城墙道具Type.初源露, 0 },
        { 城墙道具Type.厚土珠, 0 },
        { 城墙道具Type.不灭岩, 0 },
        { 城墙道具Type.周天星斗大阵, 0 },
        { 城墙道具Type.土灵珠, 0 },
        { 城墙道具Type.地髓晶, 0 },
        { 城墙道具Type.大道本源, 0 },
        { 城墙道具Type.天命罗盘, 0 },
        { 城墙道具Type.天机石, 0 },
        { 城墙道具Type.天罡石, 0 },
        { 城墙道具Type.山河阵盘, 0 },
        { 城墙道具Type.星辰沙, 0 },
        { 城墙道具Type.星辰铁, 0 },
        { 城墙道具Type.永恒之火, 0 },
        { 城墙道具Type.混沌磐石, 0 },
        { 城墙道具Type.灵兽骨粉, 0 },
        { 城墙道具Type.灵石尘, 0 },
        { 城墙道具Type.灵藤蔓, 0 },
        { 城墙道具Type.玄武石, 0 },
        { 城墙道具Type.玄黄之气, 0 },
        { 城墙道具Type.百年桃木, 0 },
        { 城墙道具Type.蛟龙骨, 0 },
        { 城墙道具Type.血琥珀, 0 },
        { 城墙道具Type.轮回印记, 0 },
        { 城墙道具Type.雷击木, 0 },
        { 城墙道具Type.鸿蒙灵根, 0 },
    };
    
    
    
    public Dictionary<道宝Type, int> 道宝LevelDic = new Dictionary<道宝Type, int>()
    {
        // ==================== 混沌至宝 ====================
        { 道宝Type.混沌青莲,   0 },
        { 道宝Type.造化玉碟,   0 },
        { 道宝Type.混沌珠,     0 },
        { 道宝Type.开天斧,     0 },

        // ==================== 先天至宝 ====================
        { 道宝Type.盘古幡,     0 },
        { 道宝Type.混沌钟,     0 },
        { 道宝Type.诛仙剑,     0 },
        { 道宝Type.戮仙剑,     0 },
        { 道宝Type.陷仙剑,     0 },
        { 道宝Type.绝仙剑,     0 },

        // ==================== 功德至宝 ====================
        { 道宝Type.玲珑塔,     0 },
        { 道宝Type.轩辕剑,     0 },
        { 道宝Type.女娲石,     0 },
        { 道宝Type.炼妖壶,     0 },
        { 道宝Type.玉净瓶,     0 },
        { 道宝Type.乾坤鼎,     0 },
        { 道宝Type.菩提妙树,   0 },
        { 道宝Type.风火轮,     0 },

        // ==================== 先天灵宝 ====================
        { 道宝Type.山河社稷图, 0 },
        { 道宝Type.七宝妙树,   0 },
        { 道宝Type.天书,       0 },
        { 道宝Type.地书,       0 },
        { 道宝Type.冥书,       0 },
        { 道宝Type.弑神枪,     0 },
        { 道宝Type.定海神珠,   0 },
        { 道宝Type.河图洛书,   0 },

        // ==================== 后天法宝 ====================
        { 道宝Type.翻天印,     0 },
        { 道宝Type.紫金葫芦,   0 },
        { 道宝Type.金蛟剪,     0 },
        { 道宝Type.斩仙飞刀,   0 },
        { 道宝Type.五色神光,   0 },
        { 道宝Type.宝莲灯,     0 },
        { 道宝Type.落宝金钱,   0 },
        { 道宝Type.先天五方旗, 0 },
        { 道宝Type.照妖镜,     0 },
        { 道宝Type.如意金箍棒, 0 },
    };
    public Dictionary<EquipType, List<道纹>> 装备道纹List = new Dictionary<EquipType, List<道纹>>()
    {
        { EquipType.头盔 ,new List<道纹>(){new 道纹(),new 道纹(),new 道纹(),new 道纹(),new 道纹()}},
        { EquipType.衣服 ,new List<道纹>(){new 道纹(),new 道纹(),new 道纹(),new 道纹(),new 道纹()}},
        { EquipType.戒指 ,new List<道纹>(){new 道纹(),new 道纹(),new 道纹(),new 道纹(),new 道纹()}},
        { EquipType.项链 ,new List<道纹>(){new 道纹(),new 道纹(),new 道纹(),new 道纹(),new 道纹()}},
        { EquipType.鞋子 ,new List<道纹>(){new 道纹(),new 道纹(),new 道纹(),new 道纹(),new 道纹()}},
        { EquipType.护手 ,new List<道纹>(){new 道纹(),new 道纹(),new 道纹(),new 道纹(),new 道纹()}},
    };
    public Dictionary<string, int> 道纹List = new Dictionary<string, int>()
{
    // 增加百分比攻击力
    {"增加百分比攻击力_天品", 0},
    {"增加百分比攻击力_宇品", 0},
    {"增加百分比攻击力_宙品", 0},
    {"增加百分比攻击力_洪品", 0},
    {"增加百分比攻击力_荒品", 0},

    // 增加战士伤害
    {"增加战士伤害_天品", 0},
    {"增加战士伤害_宇品", 0},
    {"增加战士伤害_宙品", 0},
    {"增加战士伤害_洪品", 0},
    {"增加战士伤害_荒品", 0},

    // 增加法师伤害
    {"增加法师伤害_天品", 0},
    {"增加法师伤害_宇品", 0},
    {"增加法师伤害_宙品", 0},
    {"增加法师伤害_洪品", 0},
    {"增加法师伤害_荒品", 0},

    // 增加控制伤害
    {"增加控制伤害_天品", 0},
    {"增加控制伤害_宇品", 0},
    {"增加控制伤害_宙品", 0},
    {"增加控制伤害_洪品", 0},
    {"增加控制伤害_荒品", 0},

    // 增加射手伤害
    {"增加射手伤害_天品", 0},
    {"增加射手伤害_宇品", 0},
    {"增加射手伤害_宙品", 0},
    {"增加射手伤害_洪品", 0},
    {"增加射手伤害_荒品", 0},

    // 增加小怪伤害
    {"增加小怪伤害_天品", 0},
    {"增加小怪伤害_宇品", 0},
    {"增加小怪伤害_宙品", 0},
    {"增加小怪伤害_洪品", 0},
    {"增加小怪伤害_荒品", 0},

    // 增加物理伤害
    {"增加物理伤害_天品", 0},
    {"增加物理伤害_宇品", 0},
    {"增加物理伤害_宙品", 0},
    {"增加物理伤害_洪品", 0},
    {"增加物理伤害_荒品", 0},

    // 增加雷电伤害
    {"增加雷电伤害_天品", 0},
    {"增加雷电伤害_宇品", 0},
    {"增加雷电伤害_宙品", 0},
    {"增加雷电伤害_洪品", 0},
    {"增加雷电伤害_荒品", 0},

    // 增加冰霜伤害
    {"增加冰霜伤害_天品", 0},
    {"增加冰霜伤害_宇品", 0},
    {"增加冰霜伤害_宙品", 0},
    {"增加冰霜伤害_洪品", 0},
    {"增加冰霜伤害_荒品", 0},

    // 增加黑暗伤害
    {"增加黑暗伤害_天品", 0},
    {"增加黑暗伤害_宇品", 0},
    {"增加黑暗伤害_宙品", 0},
    {"增加黑暗伤害_洪品", 0},
    {"增加黑暗伤害_荒品", 0},

    // 增加火焰伤害
    {"增加火焰伤害_天品", 0},
    {"增加火焰伤害_宇品", 0},
    {"增加火焰伤害_宙品", 0},
    {"增加火焰伤害_洪品", 0},
    {"增加火焰伤害_荒品", 0},

    // 增加精英怪和首领伤害
    {"增加精英怪和首领伤害_天品", 0},
    {"增加精英怪和首领伤害_宇品", 0},
    {"增加精英怪和首领伤害_宙品", 0},
    {"增加精英怪和首领伤害_洪品", 0},
    {"增加精英怪和首领伤害_荒品", 0},

    // 城墙低血增加伤害
    {"城墙低血增加伤害_天品", 0},
    {"城墙低血增加伤害_宇品", 0},
    {"城墙低血增加伤害_宙品", 0},
    {"城墙低血增加伤害_洪品", 0},
    {"城墙低血增加伤害_荒品", 0},

    // 击杀精英怪城墙回血
    {"击杀精英怪城墙回血_天品", 0},
    {"击杀精英怪城墙回血_宇品", 0},
    {"击杀精英怪城墙回血_宙品", 0},
    {"击杀精英怪城墙回血_洪品", 0},
    {"击杀精英怪城墙回血_荒品", 0},

    // 城墙血量百分比
    {"城墙血量百分比_天品", 0},
    {"城墙血量百分比_宇品", 0},
    {"城墙血量百分比_宙品", 0},
    {"城墙血量百分比_洪品", 0},
    {"城墙血量百分比_荒品", 0},

    // 城墙免疫伤害
    {"城墙免疫伤害_天品", 0},
    {"城墙免疫伤害_宇品", 0},
    {"城墙免疫伤害_宙品", 0},
    {"城墙免疫伤害_洪品", 0},
    {"城墙免疫伤害_荒品", 0},

    // 城墙满血时加伤害
    {"城墙满血时加伤害_天品", 0},
    {"城墙满血时加伤害_宇品", 0},
    {"城墙满血时加伤害_宙品", 0},
    {"城墙满血时加伤害_洪品", 0},
    {"城墙满血时加伤害_荒品", 0},

    // 英雄暴击率
    {"英雄暴击率_天品", 0},
    {"英雄暴击率_宇品", 0},
    {"英雄暴击率_宙品", 0},
    {"英雄暴击率_洪品", 0},
    {"英雄暴击率_荒品", 0},

    // 伤害在范围内浮动
    {"伤害在范围内浮动_天品", 0},
    {"伤害在范围内浮动_宇品", 0},
    {"伤害在范围内浮动_宙品", 0},
    {"伤害在范围内浮动_洪品", 0},
    {"伤害在范围内浮动_荒品", 0},

    // 无视抗性
    {"无视抗性_天品", 0},
    {"无视抗性_宇品", 0},
    {"无视抗性_宙品", 0},
    {"无视抗性_洪品", 0},
    {"无视抗性_荒品", 0},

    // 战士对靠近城墙敌人伤害增高
    {"战士对靠近城墙敌人伤害增高_天品", 0},
    {"战士对靠近城墙敌人伤害增高_宇品", 0},
    {"战士对靠近城墙敌人伤害增高_宙品", 0},
    {"战士对靠近城墙敌人伤害增高_洪品", 0},
    {"战士对靠近城墙敌人伤害增高_荒品", 0},

    // 射手连射概率
    {"射手连射概率_天品", 0},
    {"射手连射概率_宇品", 0},
    {"射手连射概率_宙品", 0},
    {"射手连射概率_洪品", 0},
    {"射手连射概率_荒品", 0},

    // 控制冷却缩减
    {"控制冷却缩减_天品", 0},
    {"控制冷却缩减_宇品", 0},
    {"控制冷却缩减_宙品", 0},
    {"控制冷却缩减_洪品", 0},
    {"控制冷却缩减_荒品", 0},

    // 法师暴击率
    {"法师暴击率_天品", 0},
    {"法师暴击率_宇品", 0},
    {"法师暴击率_宙品", 0},
    {"法师暴击率_洪品", 0},
    {"法师暴击率_荒品", 0},

    // 辅助被辅助英雄伤害增幅
    {"辅助被辅助英雄伤害增幅_天品", 0},
    {"辅助被辅助英雄伤害增幅_宇品", 0},
    {"辅助被辅助英雄伤害增幅_宙品", 0},
    {"辅助被辅助英雄伤害增幅_洪品", 0},
    {"辅助被辅助英雄伤害增幅_荒品", 0},

    // 三味真火无视抗性百分比
    {"三味真火无视抗性百分比_天品", 0},
    {"三味真火无视抗性百分比_宇品", 0},
    {"三味真火无视抗性百分比_宙品", 0},
    {"三味真火无视抗性百分比_洪品", 0},
    {"三味真火无视抗性百分比_荒品", 0},

    // 孙悟空每秒增加伤害
    {"孙悟空每秒增加伤害_天品", 0},
    {"孙悟空每秒增加伤害_宇品", 0},
    {"孙悟空每秒增加伤害_宙品", 0},
    {"孙悟空每秒增加伤害_洪品", 0},
    {"孙悟空每秒增加伤害_荒品", 0},

    // 碧霄冰龙有概率再次释放
    {"碧霄冰龙有概率再次释放_天品", 0},
    {"碧霄冰龙有概率再次释放_宇品", 0},
    {"碧霄冰龙有概率再次释放_宙品", 0},
    {"碧霄冰龙有概率再次释放_洪品", 0},
    {"碧霄冰龙有概率再次释放_荒品", 0},

    // 琼霄定身衰减效果减少
    {"琼霄定身衰减效果减少_天品", 0},
    {"琼霄定身衰减效果减少_宇品", 0},
    {"琼霄定身衰减效果减少_宙品", 0},
    {"琼霄定身衰减效果减少_洪品", 0},
    {"琼霄定身衰减效果减少_荒品", 0},

    // 云霄暴击率
    {"云霄暴击率_天品", 0},
    {"云霄暴击率_宇品", 0},
    {"云霄暴击率_宙品", 0},
    {"云霄暴击率_洪品", 0},
    {"云霄暴击率_荒品", 0},

    // 后羿距离越远伤害越高
    {"后羿距离越远伤害越高_天品", 0},
    {"后羿距离越远伤害越高_宇品", 0},
    {"后羿距离越远伤害越高_宙品", 0},
    {"后羿距离越远伤害越高_洪品", 0},
    {"后羿距离越远伤害越高_荒品", 0},

    // 羲和灼烧伤害
    {"羲和灼烧伤害_天品", 0},
    {"羲和灼烧伤害_宇品", 0},
    {"羲和灼烧伤害_宙品", 0},
    {"羲和灼烧伤害_洪品", 0},
    {"羲和灼烧伤害_荒品", 0},

    // 常曦有概率冻结敌人
    {"常曦有概率冻结敌人_天品", 0},
    {"常曦有概率冻结敌人_宇品", 0},
    {"常曦有概率冻结敌人_宙品", 0},
    {"常曦有概率冻结敌人_洪品", 0},
    {"常曦有概率冻结敌人_荒品", 0},

    // 女娲增加被辅助英雄暴击率
    {"女娲增加被辅助英雄暴击率_天品", 0},
    {"女娲增加被辅助英雄暴击率_宇品", 0},
    {"女娲增加被辅助英雄暴击率_宙品", 0},
    {"女娲增加被辅助英雄暴击率_洪品", 0},
    {"女娲增加被辅助英雄暴击率_荒品", 0},

    // 通天每次暴击增加伤害
    {"通天每次暴击增加伤害_天品", 0},
    {"通天每次暴击增加伤害_宇品", 0},
    {"通天每次暴击增加伤害_宙品", 0},
    {"通天每次暴击增加伤害_洪品", 0},
    {"通天每次暴击增加伤害_荒品", 0},

    // 老子旋风体积越大伤害越高
    {"老子旋风体积越大伤害越高_天品", 0},
    {"老子旋风体积越大伤害越高_宇品", 0},
    {"老子旋风体积越大伤害越高_宙品", 0},
    {"老子旋风体积越大伤害越高_洪品", 0},
    {"老子旋风体积越大伤害越高_荒品", 0},

    // 元始每次释放有概率增加火种数量
    {"元始每次释放有概率增加火种数量_天品", 0},
    {"元始每次释放有概率增加火种数量_宇品", 0},
    {"元始每次释放有概率增加火种数量_宙品", 0},
    {"元始每次释放有概率增加火种数量_洪品", 0},
    {"元始每次释放有概率增加火种数量_荒品", 0},

    // 鸿钧每释放陨石增加伤害
    {"鸿钧每释放陨石增加伤害_天品", 0},
    {"鸿钧每释放陨石增加伤害_宇品", 0},
    {"鸿钧每释放陨石增加伤害_宙品", 0},
    {"鸿钧每释放陨石增加伤害_洪品", 0},
    {"鸿钧每释放陨石增加伤害_荒品", 0},

    // 盘古每击杀敌人增加伤害
    {"盘古每击杀敌人增加伤害_天品", 0},
    {"盘古每击杀敌人增加伤害_宇品", 0},
    {"盘古每击杀敌人增加伤害_宙品", 0},
    {"盘古每击杀敌人增加伤害_洪品", 0},
    {"盘古每击杀敌人增加伤害_荒品", 0},
};
    
    public int Get道纹数量(道纹Type 类型, QualityType 品质)
    {
        string key = $"{类型}_{品质}";
        return 道纹List.TryGetValue(key, out int value) ? value : 0;
    }
    
    public void Set道纹数量(道纹Type 类型, QualityType 品质, int count)
    {
        string key = $"{类型}_{品质}";
        道纹List[key] = count;
    }
    
    
    public Dictionary<HeroType, int> 英雄法则等级Dic = new Dictionary<HeroType, int>()
    {
        { HeroType.哪吒 ,0},
        { HeroType.孙悟空 ,0},
        { HeroType.碧霄 ,0},
        { HeroType.琼霄 ,0},
        
        { HeroType.云霄 ,0},
        { HeroType.后羿 ,0},
        { HeroType.常羲 ,0},
        { HeroType.羲和 ,0},
        
        { HeroType.女娲 ,0},
        { HeroType.通天 ,0},
        { HeroType.元始 ,0},
        { HeroType.老子 ,0},
        
        { HeroType.盘古 ,0},
        { HeroType.鸿钧 ,0},
    };
    public Dictionary<JingJieType, QualityType> 当前轮回突破Dic = new Dictionary<JingJieType, QualityType>()
    {
        { JingJieType.练气 ,QualityType.None},
        { JingJieType.筑基 ,QualityType.None},
        { JingJieType.金丹 ,QualityType.None},
        { JingJieType.元婴 ,QualityType.None},
        { JingJieType.化神 ,QualityType.None},
        { JingJieType.合体 ,QualityType.None},
        { JingJieType.大乘 ,QualityType.None},
        { JingJieType.天仙 ,QualityType.None},
        { JingJieType.玄仙 ,QualityType.None},
        { JingJieType.金仙 ,QualityType.None},
        { JingJieType.太乙金仙 ,QualityType.None},
        { JingJieType.大罗金仙 ,QualityType.None},
        { JingJieType.准圣 ,QualityType.None},
        { JingJieType.圣人 ,QualityType.None},
        { JingJieType.天道圣人 ,QualityType.None},
        { JingJieType.大道圣人 ,QualityType.None},
        { JingJieType.混元圣人 ,QualityType.None},
    };

    public Dictionary<EquipType, List<附加属性>> 装备附加属性Dic = new Dictionary<EquipType, List<附加属性>>()
    {
        {
            EquipType.头盔,
            new List<附加属性>()
            {
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
            }
        },
        {
            EquipType.护手,
            new List<附加属性>()
            {
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
            }
        },
        {
            EquipType.衣服,
            new List<附加属性>()
            {
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
            }
        },
        {
            EquipType.鞋子,
            new List<附加属性>()
            {
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
            }
        },
        {
            EquipType.项链,
            new List<附加属性>()
            {
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
            }
        },
        {
            EquipType.戒指,
            new List<附加属性>()
            {
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,count = 0,IsSuo = false,无暇 = false},
            }
        },
    };
    public Dictionary<EquipType, int> EquipLevelDic = new Dictionary<EquipType, int>()
    {
        { EquipType.头盔 ,1},
        { EquipType.护手 ,1},
        { EquipType.鞋子 ,1},
        { EquipType.戒指 ,1},
        { EquipType.项链 ,1},
        { EquipType.衣服 ,1},
    };
    public Dictionary<int, List<HeroType>> 出战英雄List = new Dictionary<int, List<HeroType>>()
    {
        { 0, new List<HeroType>() { HeroType.丹童 ,HeroType.None,HeroType.None,HeroType.None,HeroType.None}},
        { 1, new List<HeroType>(){ HeroType.None ,HeroType.None,HeroType.None,HeroType.None,HeroType.None}},
        { 2, new List<HeroType>(){ HeroType.None ,HeroType.None,HeroType.None,HeroType.None,HeroType.None}},
        { 3, new List<HeroType>(){ HeroType.None ,HeroType.None,HeroType.None,HeroType.None,HeroType.None}},
    };

    public Dictionary<int, string> 编队名List = new Dictionary<int, string>()
    {
        { 0, "" },
        { 1, "" },
        { 2, "" },
        { 3, "" },
    };

    //level=0表示未解锁，level=1是星级为0，level=2是星级=1
    public Dictionary<HeroType, HeroData> HeroDataDic = new Dictionary<HeroType, HeroData>()
    {
        { HeroType.丹童, new HeroData() { Level = 1, 元神 = 0 } },
        { HeroType.土地, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.河伯, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.瑶池仙女, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.石敢当, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.玄女, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.龟丞相, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.太白金星, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.多闻天王, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.广目天王, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.雷震子, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.月老, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.嫦娥, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.杨戬, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.妲己, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.牛魔王, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.哪吒, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.孙悟空, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.碧霄, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.琼霄, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.羲和, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.常羲, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.后羿, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.云霄, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.女娲, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.老子, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.通天, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.元始, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.盘古, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.鸿钧, new HeroData() { Level = 0, 元神 = 0 } },

    };

    public Dictionary<PropType, float> PropListDic = new Dictionary<PropType, float>()
    {
        { PropType.全职业经验值, 0 },
        { PropType.功德, 0 },
        { PropType.头盔锻造石, 0 },
        { PropType.射手经验值, 0 },
        { PropType.戒指锻造石, 0 },
        { PropType.战士经验值, 0 },
        { PropType.护手锻造石, 0 },
        { PropType.招募卷, 0 },
        { PropType.控制经验值, 0 },
        { PropType.法师经验值, 0 },
        { PropType.洗练石, 0 },
        { PropType.灵魂, 0 },
        { PropType.衣服锻造石, 0 },
        { PropType.辅助经验值, 0 },
        { PropType.鞋子锻造石, 0 },
        { PropType.项链锻造石, 0 },
        { PropType.高级招募卷, 0 },
        
        { PropType.火之法则 ,0},
        { PropType.剑之法则 ,0},
        { PropType.冰之法则 ,0},
        { PropType.力之法则 ,0},
        { PropType.原始法则 ,0},
        { PropType.斗之法则 ,0},
        { PropType.日之法则 ,0},
        { PropType.月之法则 ,0},
        { PropType.禁之法则 ,0},
        { PropType.箭之法则 ,0},
        { PropType.诛仙法则 ,0},
        { PropType.造化法则 ,0},
        { PropType.道之法则 ,0},
        { PropType.鸿蒙法则 ,0},
        { PropType.功法经验 ,0},
        { PropType.仙石精华 ,0},
        { PropType.法器粉尘 ,0},
        
        { PropType.矿石 ,0},
        { PropType.玄铁 ,0},
        { PropType.玉髓 ,0},
        
        { PropType.石1, 0 },
        { PropType.石2, 0 },
        { PropType.石3, 0 },
        { PropType.石4, 0 },
        { PropType.石5, 0 },
        { PropType.石6, 0 },
        { PropType.石7, 0 },
        { PropType.石8, 0 },
        { PropType.石9, 0 },
        { PropType.石10, 0 },
        { PropType.石11, 0 },
        { PropType.石12, 0 },
        { PropType.石13, 0 },
        { PropType.石14, 0 },
        { PropType.石15, 0 },
        { PropType.石16, 0 },

        { PropType.铁1, 0 },
        { PropType.铁2, 0 },
        { PropType.铁3, 0 },
        { PropType.铁4, 0 },
        { PropType.铁5, 0 },
        { PropType.铁6, 0 },
        { PropType.铁7, 0 },
        { PropType.铁8, 0 },
        { PropType.铁9, 0 },
        { PropType.铁10, 0 },
        { PropType.铁11, 0 },
        { PropType.铁12, 0 },
        { PropType.铁13, 0 },
        { PropType.铁14, 0 },
        { PropType.铁15, 0 },
        { PropType.铁16, 0 },

        { PropType.羽1, 0 },
        { PropType.羽2, 0 },
        { PropType.羽3, 0 },
        { PropType.羽4, 0 },
        { PropType.羽5, 0 },
        { PropType.羽6, 0 },
        { PropType.羽7, 0 },
        { PropType.羽8, 0 },
        { PropType.羽9, 0 },
        { PropType.羽10, 0 },
        { PropType.羽11, 0 },
        { PropType.羽12, 0 },
        { PropType.羽13, 0 },
        { PropType.羽14, 0 },
        { PropType.羽15, 0 },
        { PropType.羽16, 0 },

        { PropType.砂1, 0 },
        { PropType.砂2, 0 },
        { PropType.砂3, 0 },
        { PropType.砂4, 0 },
        { PropType.砂5, 0 },
        { PropType.砂6, 0 },
        { PropType.砂7, 0 },
        { PropType.砂8, 0 },
        { PropType.砂9, 0 },
        { PropType.砂10, 0 },
        { PropType.砂11, 0 },
        { PropType.砂12, 0 },
        { PropType.砂13, 0 },
        { PropType.砂14, 0 },
        { PropType.砂15, 0 },
        { PropType.砂16, 0 },
        { PropType.轮回石, 0 },
        { PropType.血晶, 0 },
    };

   

    

    public Dictionary<主线关卡Type, bool> LevelSmallJieSuoDic = new Dictionary<主线关卡Type, bool>()
    {
        { 主线关卡Type.花果山, true },
        { 主线关卡Type.水帘洞, false },
        { 主线关卡Type.傲来国, false },
        { 主线关卡Type.东海龙宫, false },
        { 主线关卡Type.蓬莱仙岛, false },
        { 主线关卡Type.五行山, false },
        { 主线关卡Type.高老庄, false },
        { 主线关卡Type.平顶山, false },
        { 主线关卡Type.女儿国, false },
        { 主线关卡Type.火焰山, false },
        { 主线关卡Type.狮驼岭, false },
        { 主线关卡Type.小雷音寺, false },
        { 主线关卡Type.流沙河, false },
        { 主线关卡Type.芭蕉洞, false },
        { 主线关卡Type.冥府, false },

    };
    
    
    
    
    // 大数单位表：严格万进（每级 ×10^4），从 10^4 一路铺到 10^3000，共 750 级
    // 10^4~10^68 沿用《孙子算经》传统命名；10^72 起为自创命名，
    // 意境随数量级攀升：天光星汉 → 溟海沧澜 → 山岳巍峨 → 长亘绵邈 →
    // 微尘劫世 → 道体玄妙 → 混沌浑归 → 洪蒙初辟 → 造化万象 → 万法圆融；
    // 10^1004 以上再由风雷云水、光华器用、百物生灵、人伦邦国一路铺陈，至 10^3000 返璞归真
    private static readonly string[] 大数名 = new[]
    {
        // —— 传统万进：10^4 ~ 10^68 ——
        "万", "亿", "兆", "京", "垓", "秭", "穰", "沟", "涧", "正", "载", "极",
        "恒", "祇", "由", "议", "量",
        // —— 天光星汉：10^72 ~ 10^100 ——
        "曜", "曦", "辰", "宿", "垣", "汉", "潢", "鸿",
        // —— 溟海沧澜：10^104 ~ 10^136 ——
        "溟", "瀛", "渊", "淼", "瀚", "灏", "沧", "澜", "泱",
        // —— 山岳巍峨：10^140 ~ 10^164 ——
        "岳", "崙", "峤", "岱", "嵩", "巅", "嶂",
        // —— 长亘绵邈：10^168 ~ 10^196 ——
        "长", "亘", "永", "遐", "旷", "绵", "悠", "邈",
        // —— 微尘劫世：10^200 ~ 10^228 ——
        "尘", "刹", "念", "劫", "世", "梵", "涅", "槃",
        // —— 道体玄妙：10^232 ~ 10^276 ——
        "炁", "玄", "元", "真", "虚", "寥", "枢", "泰", "道", "妙", "羲", "衡",
        // —— 混沌浑归：10^280 ~ 10^304 ——
        "寂", "冥", "幽", "混", "沌", "浑", "归",
        // —— 洪蒙初辟：10^308 ~ 10^352 ——
        "洪", "荒", "蒙", "未", "彰", "胚", "胎", "孕", "磐", "基", "始", "源",
        // —— 阴阳造化：10^356 ~ 10^396 ——
        "阴", "阳", "乾", "坤", "离", "坎", "巽", "震", "艮", "兑", "炉",
        // —— 星汉灿烂：10^400 ~ 10^440 ——
        "星", "河", "云", "霄", "穹", "昊", "空", "芒", "辉", "灿", "烬",
        // —— 灵魂神识：10^444 ~ 10^480 ——
        "灵", "韵", "髓", "魂", "魄", "神", "志", "意", "识", "芯",
        // —— 天道法则：10^484 ~ 10^524 ——
        "天", "命", "数", "理", "法", "则", "律", "纲", "纪", "章", "诏",
        // —— 时光朝暮：10^528 ~ 10^568 ——
        "时", "岁", "春", "秋", "朝", "夕", "昼", "昕", "晌", "瞬", "昙",
        // —— 山海江湖：10^572 ~ 10^612 ——
        "山", "海", "江", "湖", "泽", "川", "峰", "崖", "岛", "屿", "洲",
        // —— 草木荣枯：10^616 ~ 10^656 ——
        "草", "木", "花", "叶", "果", "苗", "荣", "枯", "森", "樵", "藤",
        // —— 琼楼玉宇：10^660 ~ 10^704 ——
        "琼", "楼", "玉", "宫", "阙", "殿", "亭", "台", "阁", "榭", "廊", "坊",
        // —— 法宝仙兵：10^708 ~ 10^752 ——
        "鼎", "钟", "剑", "镜", "铃", "塔", "印", "符", "幡", "伞", "盘", "珠",
        // —— 丹道煅炼：10^756 ~ 10^800 ——
        "丹", "膏", "散", "丸", "露", "泉", "引", "焰", "煅", "炼", "凝", "化",
        // —— 神兽瑞祥：10^804 ~ 10^848 ——
        "龙", "凤", "麟", "龟", "鹤", "雀", "蛟", "螭", "貔", "狻", "猊", "狸",
        // —— 仙圣帝君：10^852 ~ 10^900 ——
        "仙", "圣", "贤", "尊", "帝", "皇", "君", "侯", "卿", "士", "儒", "侠", "隐",
        // —— 无垠际涯：10^904 ~ 10^952 ——
        "无", "疆", "垠", "际", "涯", "尽", "头", "末", "端", "终", "穷", "断", "绝",
        // —— 万法圆融：10^956 ~ 10^1000 ——
        "宗", "禅", "悟", "觉", "明", "澈", "澄", "圆", "满", "盈", "溢", "融",
        // —— 雷部霆威：10^1004 ~ 10^1048 ——
        "雷", "霆", "霹", "雳", "电", "霖", "霈", "霁", "霏", "霞", "霭", "霂",
        // —— 玄冰凛霜：10^1052 ~ 10^1096 ——
        "冰", "凌", "霜", "雪", "冷", "冽", "凛", "冻", "凉", "雹", "冱", "凄",
        // —— 长风飘飒：10^1100 ~ 10^1144 ——
        "风", "飙", "飒", "飔", "飓", "飘", "飏", "飖", "颲", "飕", "飂", "飗",
        // —— 甘霖渥润：10^1148 ~ 10^1192 ——
        "雨", "澍", "淅", "沥", "潇", "漫", "涟", "漪", "淞", "濡", "渥", "渝",
        // —— 日升月恒：10^1196 ~ 10^1240 ——
        "日", "月", "旭", "昉", "晟", "晗", "昀", "昪", "昶", "昱", "晔", "曙",
        // —— 光华璀璨：10^1244 ~ 10^1288 ——
        "光", "华", "璀", "璨", "琰", "玥", "珊", "瑚", "珀", "玫", "瑰", "瑀",
        // —— 金石铿锵：10^1292 ~ 10^1336 ——
        "金", "银", "铜", "铁", "锡", "钰", "铭", "铮", "铎", "钊", "铿", "锵",
        // —— 云锦织文：10^1340 ~ 10^1384 ——
        "锦", "绣", "绮", "绫", "罗", "绸", "缎", "绢", "纨", "缟", "绡", "纻",
        // —— 琴笙雅奏：10^1388 ~ 10^1432 ——
        "琴", "棋", "书", "画", "诗", "词", "歌", "赋", "曲", "笙", "弦", "簧",
        // —— 冠裳佩珂：10^1436 ~ 10^1480 ——
        "礼", "衣", "冠", "裳", "衮", "黻", "冕", "笏", "绅", "佩", "珂", "璎",
        // —— 翰墨缥缃：10^1484 ~ 10^1528 ——
        "翰", "墨", "笔", "砚", "纸", "简", "牍", "编", "卷", "帙", "笺", "篆",
        // —— 茶酒清欢：10^1532 ~ 10^1576 ——
        "茶", "香", "酒", "醇", "酿", "醑", "酾", "茗", "荈", "醅", "醪", "酩",
        // —— 珍馐美馔：10^1580 ~ 10^1624 ——
        "珍", "馐", "肴", "馔", "脍", "脯", "羹", "糜", "粥", "糕", "粽", "酥",
        // —— 桑麻丰稔：10^1628 ~ 10^1672 ——
        "桑", "麻", "稼", "穑", "禾", "稻", "麦", "黍", "稷", "粱", "菽", "荞",
        // —— 园圃清蔬：10^1676 ~ 10^1720 ——
        "园", "圃", "蔬", "瓜", "藕", "茭", "芰", "菰", "芹", "韭", "葵", "藿",
        // —— 岁寒三友：10^1724 ~ 10^1768 ——
        "松", "柏", "竹", "梅", "兰", "菊", "莲", "荷", "桂", "桐", "柳", "桃",
        // —— 羽族凌云：10^1772 ~ 10^1816 ——
        "鹰", "鹏", "雁", "鸢", "鹭", "鸥", "鸠", "鹊", "鸽", "鹑", "鹄", "雉",
        // —— 百兽骏奔：10^1820 ~ 10^1864 ——
        "虎", "豹", "熊", "鹿", "狮", "象", "犀", "狼", "狐", "貂", "麝", "麋",
        // —— 鳞介跃渊：10^1868 ~ 10^1912 ——
        "鱼", "鲤", "鲲", "鲸", "鳌", "鳖", "蟹", "虾", "蚌", "蛤", "鳅", "鳝",
        // —— 虫豸翾飞：10^1916 ~ 10^1960 ——
        "蜂", "蝶", "蝉", "萤", "蚁", "蚊", "蝇", "蛾", "蜘", "蛛", "螳", "蟋",
        // —— 丹青五色：10^1964 ~ 10^2008 ——
        "赤", "朱", "赭", "彤", "赪", "绯", "绛", "缃", "缥", "黛", "黝", "黔",
        // —— 五味调和：10^2012 ~ 10^2056 ——
        "酸", "甜", "苦", "辣", "咸", "甘", "涩", "淡", "鲜", "腥", "膻", "酽",
        // —— 雅乐正音：10^2060 ~ 10^2104 ——
        "韶", "商", "角", "徵", "羽", "吕", "讴", "谣", "诵", "啸", "吟", "咏",
        // —— 方位四正：10^2108 ~ 10^2152 ——
        "其", "前", "群", "清", "中", "央", "德", "度", "先", "行", "选", "徐",
        // —— 数一至千：10^2156 ~ 10^2200 ——
        "吖", "时", "比", "杠", "经", "安", "偶", "派", "平", "盘", "楼", "里",
        // —— 天干灵爻：10^2204 ~ 10^2248 ——
        "并", "包", "补", "车", "戊", "但", "若", "任", "壬", "癸", "卦", "爻",
        // —— 遁甲八门：10^2252 ~ 10^2296 ——
        "休", "生", "伤", "杜", "景", "死", "惊", "开", "奇", "遁", "韬", "仪",
        // —— 苍龙七宿：10^2300 ~ 10^2344 ——
        "亢", "氐", "房", "心", "尾", "箕", "斗", "牛", "女", "危", "室", "壁",
        // —— 白虎七宿：10^2348 ~ 10^2392 ——
        "奎", "娄", "胃", "昴", "毕", "觜", "参", "井", "鬼", "张", "翼", "轸",
        // —— 酆都幽狱：10^2396 ~ 10^2440 ——
        "酆", "都", "狱", "囚", "梏", "桎", "锁", "缧", "魑", "魅", "魍", "魉",
        // —— 蓬阆仙寰：10^2444 ~ 10^2488 ——
        "蓬", "莱", "方", "丈", "壶", "阆", "苑", "寰", "瑶", "璇", "玑", "璆",
        // —— 仙娥姽婳：10^2492 ~ 10^2536 ——
        "娥", "娟", "嫦", "娜", "婉", "婺", "姬", "妃", "嫔", "嫱", "嫣", "姣",
        // —— 耄耋耆寿：10^2540 ~ 10^2584 ——
        "翁", "叟", "童", "婴", "孩", "孺", "妪", "媪", "姥", "耄", "耋", "耆",
        // —— 宗族胤裔：10^2588 ~ 10^2632 ——
        "祖", "父", "母", "兄", "弟", "姐", "妹", "儿", "孙", "侄", "裔", "胤",
        // —— 邦国疆鄙：10^2636 ~ 10^2680 ——
        "邦", "国", "城", "郭", "池", "隍", "垒", "塞", "关", "隘", "境", "鄙",
        // —— 戈矛铩刃：10^2684 ~ 10^2728 ——
        "戈", "矛", "戟", "弩", "弓", "箭", "矢", "胄", "盾", "盔", "刃", "铩",
        // —— 旌旗鏖战：10^2732 ~ 10^2776 ——
        "旌", "旗", "麾", "纛", "铠", "鼓", "鼙", "钲", "骠", "骑", "阵", "鏖",
        // —— 舟车帆辙：10^2780 ~ 10^2824 ——
        "舟", "船", "舰", "艇", "舶", "航", "帆", "桨", "橹", "车", "辕", "辙",
        // —— 阡陌衢径：10^2828 ~ 10^2872 ——
        "阡", "陌", "衢", "巷", "街", "途", "径", "歧", "驿", "程", "邃", "迤",
        // —— 门牖楹础：10^2876 ~ 10^2920 ——
        "门", "户", "窗", "牖", "扉", "闳", "闱", "闺", "槛", "檐", "楹", "础",
        // —— 榱题栌拱：10^2924 ~ 10^2968 ——
        "墙", "墉", "瓦", "砖", "甓", "檩", "柱", "栋", "榱", "桷", "拱", "栌",
        // —— 返璞归真：10^2972 ~ 10^3000 ——
        "璞", "朴", "拙", "讷", "愚", "鲁", "淳", "素",
    };

    public int Get数字阶数(BigDouble num)
    {
        // 0 或负数没有阶数
        if (num <= 0)
        {
            return 0;
        }

        // 与 格式化数字 完全相同的定位公式（达到下一单位100倍才进位）：
        // 单位"万"覆盖 100万~100亿、"亿"覆盖 100亿~100兆……保证阶数和显示单位永远一致
        double e = BigDouble.Log10(num);
        int k = (int)Math.Floor((e - 2) / 4);

        if (k < 1)
        {
            return 0;   // 小于100万：显示纯整数，没有单位
        }

        // 上限钳制：阶数拿去索引 大数名[k-1] 时不会越界（表铺到 10^3000，最大阶 750）
        if (k > 大数名.Length)
        {
            k = 大数名.Length;
        }
        return k;
    }
    public string 格式化数字(double num)
    {
        // 处理负数
        if (num < 0)
        {
            return "-" + 格式化数字(Math.Abs(num));
        }

        // 小于1万直接显示整数
        if (num < 1000000)
        {
            return Math.Floor(num).ToString();
        }

        // O(1) 寻位（与 BigDouble 版同一套逻辑）：
        // e = Log10 指数；与大数名[k-1]（10^(4k)）匹配需要商 >= 100，
        // 即 e - 4k >= 2，取 k = (e-2)/4 向下取整，一步定位单位，替代线性扫描
        double e = Math.Log10(num);
        int k = (int)Math.Floor((e - 2) / 4);
        if (k < 1)
        {
            k = 1; // 100万 ~ 1亿：万
        }
        if (k > 大数名.Length)
        {
            // 超出单位表：降级科学计数法
            return num.ToString("E1");
        }

        // 相邻单位严格 ×10^4，v 必在 [100, 100万) 内：取整保证无小数、无科学计数法
        double unitValue = Math.Pow(10, k * 4);
        long v = (long)Math.Floor(num / unitValue);
        return v + 大数名[k - 1];
    }

    /// <summary>
    /// BigDouble 版格式化数字：单位与大数名共用同一张万进表，
    /// 但不再用 Math.Pow 单位表比较（10^308 就爆 double），
    /// 而是取 Log10 指数直接定位单位，全域可用
    /// </summary>
    public string 格式化数字(BigDouble num)
    {
        if (num < 0)
        {
            return "-" + 格式化数字(BigDouble.Abs(num));
        }

        // 小于100万直接显示整数（这个量级 double 完全装得下）
        if (num < 1000000)
        {
            return Math.Floor((double)num).ToString();
        }

        // e = 位数-1；与大数名[j]（10^(4(j+1))）匹配需要商 >= 100，
        // 即 e - 4k >= 2（k = 单位指数/4），取 k = (e-2)/4 向下取整
        double e = BigDouble.Log10(num);
        int k = (int)Math.Floor((e - 2) / 4);
        if (k < 1)
        {
            k = 1; // 100万 ~ 1亿：万
        }
        if (k > 大数名.Length)
        {
            // 超出单位表（> 10^3000）：降级科学计数法
            return num.ToString();
        }

        BigDouble unit = BigDouble.Pow10(4 * k);
        double v = Math.Floor((double)(num / unit));
        return v + 大数名[k - 1];
    }

}

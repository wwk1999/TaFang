using System.Collections.Generic;

public enum 人物Type
{
    None,
    我,
    仙子,
}

public enum 引导maskType
{
    None,
    英雄按钮,
    英雄上阵,
}
public class 对话
{
    public 人物Type 人物Type;
    public string text;
    public int index;
    public int next;
}
public class 新手引导剧情Config
{
    public static List<对话> 对话 = new List<对话>()
    {
        new 对话() { index = 1,next = 2,人物Type = 人物Type.我, text = "我靠，我不是在帮宿舍那三个逆子带饭的路上，被大运帝君送走了么？校园里冲出来一辆大运也是神了，这司机怕不是喝了假酒了吧！我外卖还没送到呢，三个儿子怕是要饿成三道杠了。" },
        new 对话() { index = 2,next = 3,人物Type = 人物Type.我, text = "等等……这是给我干哪来了？" },
        new 对话() { index = 3,next = 4,人物Type = 人物Type.None, text = "（环顾四周，仙鹤盘旋，灵气逼人，远处还有一座金光闪闪的牌坊，上书四个大字：洪荒仙界）" },
        new 对话() { index = 4,next = 5,人物Type = 人物Type.None, text = "这时，云雾自中间裂开，一道清冷仙光垂落。一名白衣仙子踏光而出，眸若寒星，眉目如霜，周身道韵凝而不散。" },
        new 对话() { index = 5,next = 6,人物Type = 人物Type.仙子, text = "你终于来了……" },
        new 对话() { index = 6,next = 7,人物Type = 人物Type.我, text = "啊？仙子姐姐您认识我？咱俩没见过吧" },
        new 对话() { index = 7,next = 8,人物Type = 人物Type.仙子, text = "本座在此界等你，已有一万五千四百七十八会元。" },
        
        new 对话() { index = 8,next = 9,人物Type = 人物Type.我, text = "你脑子里飞速换算：一会元十二万九千六百年，一万五千四百七十八会元……。" },
        new 对话() { index = 9,next = 10,人物Type = 人物Type.我, text = "我靠，二十亿年？！仙子姐姐您在这儿干等了我二十亿年？您这耐心，比我那三个儿子等我带饭的耐心强了二十亿倍啊！" },
        new 对话() { index = 10,next = 11,人物Type = 人物Type.我, text = "仙子姐姐，您到底是谁呀，听你意思，好像早就知道我会来一样，还有，我要怎么回去原来的世界呢。" },
        new 对话() { index = 11,next = 12,人物Type = 人物Type.仙子, text = "你可以叫我洛瑶，至于回去，等你证得大罗道果，自然随时都可以回去。" },
        new 对话() { index = 12,next = 13,人物Type = 人物Type.仙子, text = "你现在实力太低，知道太多对你并没有好处。" },
        new 对话() { index = 13,next = 14,人物Type = 人物Type.我, text = "啊，那我要怎么修炼呢，我现在啥也不会啊。" },
        new 对话() { index = 14,next = 15,人物Type = 人物Type.仙子, text = "这点你不用担心，随后洛瑶摇身一变，化为一点灵光没入你眉心。" },
        new 对话() { index = 15,next = 16,人物Type = 人物Type.None, text = "【叮！洪荒之刷宝成圣系统绑定成功。本系统由鸿蒙本源演化，旨在辅助宿主变强、逍遥长生、证道大罗！】" },
        
        new 对话() { index = 16,next = 17,人物Type = 人物Type.我, text = "我靠，系统，番茄诚不欺我！" },
        new 对话() { index = 17,next = 18,人物Type = 人物Type.仙子, text = "天道演化，万象归一。你心中所想，便是系统所现。本座只是借你熟悉之形，行辅助之实。" },
        new 对话() { index = 18,next = -1,人物Type = 人物Type.仙子, text = "以后，你心中所念，系统便会演化而出，现在，先在英雄界面上阵一名英雄吧" },
        
        new 对话() { index = 20,next = 21,人物Type = 人物Type.仙子, text = "我收集了洪荒里诸多英雄的元神，可以协助你战斗。" },
        new 对话() { index = 21,next = 22,人物Type = 人物Type.我, text = "哇，三清，女娲还有盘古，这些大神帮我战斗我不是要无敌了！" },
        new 对话() { index = 22,next = 23,人物Type = 人物Type.仙子, text = "你现在的实力还很低微，只能用最低的等级的英雄，后面你可以在</color>领地</color>的</color>聚贤阁</color>里招募更强力的英雄，聚贤阁等级越高，越有可能招募到强力英雄" },
        new 对话() { index = 23,next = -2,人物Type = 人物Type.仙子, text = "现在你试着上场一名英雄吧，</color>长按1S</color>英雄卡片然后拖拽到平台上即可完成英雄上阵。" },

       
    };
}

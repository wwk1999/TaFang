using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesConfig : MonoBehaviour
{
   //人物图片
   //白
   public static Sprite DanTong;
   public static Sprite QingTong;
   public static Sprite TuDi;
   public static Sprite HeBo;
   public static Sprite YaoChiXianNv;
   public static Sprite JingWei;
   
   //绿
   public static Sprite ShiGanDang;
   public static Sprite YueLao;
   public static Sprite XuanNv;
   public static Sprite GuiChengXiang;
   public static Sprite TaiBaiJinXing;
   public static Sprite MengPo;
   public static Sprite BaiSuZhen;


   
   //蓝
   public static Sprite DuoWenTianWang;
   public static Sprite ZengZhangTianWang;
   public static Sprite GuangMuTianMu;
   public static Sprite ChiGuoTianWang;
   public static Sprite LeiZhengZi;
   public static Sprite ChangE;
   public static Sprite HeXianGu;


   
   //紫
   public static Sprite NeZha;
   public static Sprite SunWuKong;
   public static Sprite YangJian;
   public static Sprite DanJi;
   public static Sprite NiuMoWang;
   public static Sprite JingLingShengMu;

   //橙
   public static Sprite HouYi;
   public static Sprite XingTian;
   public static Sprite YunXiao;
   public static Sprite BiXiao;
   public static Sprite QiongXiao;
   public static Sprite XiHe;
   public static Sprite ChangXi;

   //红
   public static Sprite NvWa;
   public static Sprite JieYing;
   public static Sprite ZhunTi;
   public static Sprite TongTian;
   public static Sprite YuanShi;
   public static Sprite LaoZi;


   public static void Init()
   {
   DanTong=Resources.LoadAll<Sprite>("Sprite/RenWu/白")[3];
   QingTong=Resources.LoadAll<Sprite>("Sprite/RenWu/白")[2];
   TuDi=Resources.LoadAll<Sprite>("Sprite/RenWu/白")[0];
   HeBo=Resources.LoadAll<Sprite>("Sprite/RenWu/白")[1];
   YaoChiXianNv=Resources.LoadAll<Sprite>("Sprite/RenWu/白")[5];
   JingWei=Resources.LoadAll<Sprite>("Sprite/RenWu/女1")[6];
   
   //绿
   ShiGanDang=Resources.LoadAll<Sprite>("Sprite/RenWu/白")[4];
   YueLao=Resources.LoadAll<Sprite>("Sprite/RenWu/绿")[0];
   XuanNv=Resources.LoadAll<Sprite>("Sprite/RenWu/绿")[3];
   GuiChengXiang=Resources.LoadAll<Sprite>("Sprite/RenWu/绿")[4];
   TaiBaiJinXing=Resources.LoadAll<Sprite>("Sprite/RenWu/绿")[2];
   MengPo=Resources.LoadAll<Sprite>("Sprite/RenWu/女1")[2];
   BaiSuZhen=Resources.LoadAll<Sprite>("Sprite/RenWu/女1")[3];


   
   //蓝
   DuoWenTianWang=Resources.LoadAll<Sprite>("Sprite/RenWu/蓝")[0];
   ZengZhangTianWang=Resources.LoadAll<Sprite>("Sprite/RenWu/蓝")[2];
   GuangMuTianMu=Resources.LoadAll<Sprite>("Sprite/RenWu/绿")[6];
   ChiGuoTianWang=Resources.LoadAll<Sprite>("Sprite/RenWu/蓝")[1];
   LeiZhengZi=Resources.LoadAll<Sprite>("Sprite/RenWu/蓝")[7];
   ChangE=Resources.LoadAll<Sprite>("Sprite/RenWu/蓝")[1];
   HeXianGu=Resources.LoadAll<Sprite>("Sprite/RenWu/女2")[5];


   
   //紫
   NeZha=Resources.LoadAll<Sprite>("Sprite/RenWu/蓝")[8];
   SunWuKong=Resources.LoadAll<Sprite>("Sprite/RenWu/紫")[3];
   YangJian=Resources.LoadAll<Sprite>("Sprite/RenWu/紫")[0];
   DanJi=Resources.LoadAll<Sprite>("Sprite/RenWu/紫")[2];
   NiuMoWang=Resources.LoadAll<Sprite>("Sprite/RenWu/紫")[4];
   JingLingShengMu=Resources.LoadAll<Sprite>("Sprite/RenWu/女1")[0];
   XingTian=Resources.LoadAll<Sprite>("Sprite/RenWu/橙")[4];
   
   //橙
   HouYi=Resources.LoadAll<Sprite>("Sprite/RenWu/橙")[1];
   YunXiao=Resources.LoadAll<Sprite>("Sprite/RenWu/女2")[2];
   BiXiao=Resources.LoadAll<Sprite>("Sprite/RenWu/女2")[4];
   QiongXiao=Resources.LoadAll<Sprite>("Sprite/RenWu/女2")[3];
   XiHe=Resources.LoadAll<Sprite>("Sprite/RenWu/女2")[0];
   ChangXi=Resources.LoadAll<Sprite>("Sprite/RenWu/女2")[1];

   //红
   NvWa=Resources.LoadAll<Sprite>("Sprite/RenWu/红")[0];
   JieYing=Resources.LoadAll<Sprite>("Sprite/RenWu/橙")[3];
   ZhunTi=Resources.LoadAll<Sprite>("Sprite/RenWu/橙")[4];
   TongTian=Resources.LoadAll<Sprite>("Sprite/RenWu/红")[3];
   YuanShi=Resources.LoadAll<Sprite>("Sprite/RenWu/红")[4];
   LaoZi=Resources.LoadAll<Sprite>("Sprite/RenWu/橙")[5];
   }
}

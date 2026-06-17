using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 怪物触发器 : MonoBehaviour
{
    public int 编号;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            switch (编号)
            {
                case 1:
                    FightController.S.Monster分区Dic[1].Add(FightController.S.MonsterColliderDic[other]);
                    break;
                case 2:
                    FightController.S.Monster分区Dic[2].Add(FightController.S.MonsterColliderDic[other]);
                    break;
                case 3:
                    FightController.S.Monster分区Dic[3].Add(FightController.S.MonsterColliderDic[other]);
                    break;
                case 4:
                    FightController.S.Monster分区Dic[4].Add(FightController.S.MonsterColliderDic[other]);
                    break;
                case 5:
                    FightController.S.Monster分区Dic[5].Add(FightController.S.MonsterColliderDic[other]);
                    break;
                case 6:
                    FightController.S.Monster分区Dic[6].Add(FightController.S.MonsterColliderDic[other]);
                    break;
                case 7:
                    FightController.S.Monster分区Dic[7].Add(FightController.S.MonsterColliderDic[other]);
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            switch (编号)
            {
                case 2:
                    if (FightController.S.Monster分区Dic[2].Contains(FightController.S.MonsterColliderDic[other]))
                    {
                        FightController.S.Monster分区Dic[2].Remove(FightController.S.MonsterColliderDic[other]);
                    }
                    break;
                case 3:
                    if (FightController.S.Monster分区Dic[3].Contains(FightController.S.MonsterColliderDic[other]))
                    {
                        FightController.S.Monster分区Dic[3].Remove(FightController.S.MonsterColliderDic[other]);
                    }
                    break;
                case 4:
                    if (FightController.S.Monster分区Dic[4].Contains(FightController.S.MonsterColliderDic[other]))
                    {
                        FightController.S.Monster分区Dic[4].Remove(FightController.S.MonsterColliderDic[other]);
                    }
                    break;
                case 5:
                    if (FightController.S.Monster分区Dic[5].Contains(FightController.S.MonsterColliderDic[other]))
                    {
                        FightController.S.Monster分区Dic[5].Remove(FightController.S.MonsterColliderDic[other]);
                    }
                    break;
                case 6:
                    if (FightController.S.Monster分区Dic[6].Contains(FightController.S.MonsterColliderDic[other]))
                    {
                        FightController.S.Monster分区Dic[6].Remove(FightController.S.MonsterColliderDic[other]);
                    }
                    break;
                case 7:
                    if (FightController.S.Monster分区Dic[7].Contains(FightController.S.MonsterColliderDic[other]))
                    {
                        FightController.S.Monster分区Dic[7].Remove(FightController.S.MonsterColliderDic[other]);
                    }
                    break;
            }
        }
    }
}

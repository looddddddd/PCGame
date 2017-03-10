using UnityEngine;
using System.Collections;
/// <summary>
/// 战斗管理器
/// </summary>
public class FightMgr : Singleton<FightMgr> {
    /// <summary>
    /// 1对1
    /// </summary>
    /// <param name="json">数据类</param>
    public static void VSOne(HeroJson hero)
    {
        //bool isUse = ItemsMgr.UseItem();
        //if (!isUse) return;
        //int userAtt = ItemsMgr.currentItem.att;
        int userAtt = 4;
        hero.hp -= userAtt;
        if (hero.hp > 0) 
        {
            hero.view.Fresh(FreshType.Hp);
            return; 
        }
        //死亡
        hero.hp = 0;
        hero.view.Fresh(FreshType.Hp);
        hero.view.Fresh(FreshType.Die);
    }
}

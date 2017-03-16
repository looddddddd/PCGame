using UnityEngine;
using System.Collections;
/// <summary>
/// 战斗管理器
/// 敌人攻击间隔（按一定的时间进行攻击）
/// 玩家攻击无间隔（体力增长消耗）
/// 攻击区域可增加
/// </summary>
public class GameMgr : Singleton<GameMgr> {
    /// <summary>
    /// 1对1
    /// </summary>
    /// <param name="json">数据类</param>
    public static void VSOne(HeroJson hero)
    {
        int userAtt = 10;
        hero.hp -= userAtt;
        //刷文本
        hero.view.preHPChangeValue = -userAtt;
        NotiCenter.DispatchEvent(KCEvent.KCHeroHPChange,(object)hero.view);

        if (hero.hp > 0) 
        {
            hero.view.Fresh(FreshType.Hp);
            return; 
        }
        //死亡
        hero.hp = 0;
        hero.view.Fresh(FreshType.Hp);
        hero.view.Fresh(FreshType.Die);
        ItemsModel.AddItems(hero.items);
    }
}

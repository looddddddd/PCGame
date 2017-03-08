using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 英雄对象数据
/// </summary>

public class HerosModel : Singleton<HerosModel> {
    /// <summary>
    /// 当前地块存在的地方英雄
    /// </summary>
    static Dictionary<int, HeroJson> heroMap = new Dictionary<int, HeroJson>();
    /// <summary>
    /// 初始化英雄模型
    /// </summary>
    public static void InitHerosModel()
    {
        HeroJson hero1 = new HeroJson();
        hero1.id = 1;
        hero1.traitId = 1;
        hero1.type = (int)HeroType.Boss;
        hero1.name = "boss";
        hero1.hp = 50;

        HeroJson hero2 = new HeroJson();
        hero2.id = 2;
        hero2.traitId = 2;
        hero2.type = (int)HeroType.Dogface;
        hero2.name = "小兵";
        hero2.hp = 10;

        heroMap.Add(hero1.id, hero1);
        heroMap.Add(hero2.id, hero2);
    }
    /// <summary>
    /// 取得英雄数据
    /// </summary>
    /// <returns></returns>
    public static Dictionary<int, HeroJson> GetHeroMap()
    {
        return heroMap;
    }
    /// <summary>
    /// 根据英雄id取得数据
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static HeroJson GetHeroJsonById(int id)
    {
        return heroMap[id];
    }
}

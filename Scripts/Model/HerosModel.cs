using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
/// <summary>
/// 英雄对象数据
/// </summary>
public class HerosModel : BaseModel {
    /// <summary>
    /// 当前地块存在的地方英雄
    /// </summary>
    static Dictionary<int, HeroJson> heroMap = new Dictionary<int, HeroJson>();
    /// <summary>
    /// 刷新当前英雄集
    /// </summary>    
    public static void FreshHeroMap()
    {
        heroMap.Clear();
        int[] heros = TileModel.currentTile.heros;
        for(int i = 0; i < heros.Length;i++)
        {
            AddHeroJson(heros[i].ToString());
        }
    }
    /// <summary>
    /// 添加英雄
    /// </summary>       
    static void AddHeroJson(string id)
    {
        JsonData heroList = Get("HeroList");
        HeroJson hero = JsonMapper.ToObject<HeroJson>(heroList[id].ToJson());
        hero.heroId = heroMap.Count;
        heroMap.Add(heroMap.Count,hero);
    }
    /// <summary>
    /// 取得当前地块所有的英雄数据
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
    public static HeroJson GetHeroJsonById(int heroId)
    {
        return heroMap[heroId];
    }
}

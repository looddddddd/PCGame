using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
/// <summary>
/// 英雄对象数据
/// </summary>
public class HerosModel : BaseModel {
    /// <summary>
    /// 系统英雄集
    /// </summary>    
    static Dictionary<int,HeroJson> heroMap = new Dictionary<int, HeroJson>();
    /// <summary>
    /// 当前地块存在的地方英雄
    /// </summary>
    static Dictionary<int, HeroJson> userHeroMap = new Dictionary<int, HeroJson>();
    /// <summary>
    /// 刷新当前英雄集
    /// </summary>    
    public static void FreshHeroMap()
    {
        userHeroMap.Clear();
        int[] heros = TileModel.currentTile.heros;
        for(int i = 0; i < heros.Length;i++)
        {
            AddUserHeroJson(heros[i].ToString());
        }
    }
    /// <summary>
    /// 添加英雄
    /// </summary>
    static void AddUserHeroJson(string id)
    {
        JsonData heroList = Get("HeroList");
        HeroJson hero = JsonMapper.ToObject<HeroJson>(heroList[id].ToJson());
        hero.heroId = userHeroMap.Count;
        userHeroMap.Add(userHeroMap.Count,hero);
    }
    /// <summary>
    /// 取得当前地块所有的英雄数据
    /// </summary>
    /// <returns></returns>
    public static Dictionary<int, HeroJson> GetHeroMap()
    {
        return userHeroMap;
    }
    /// <summary>
    /// 根据英雄heroId取得数据
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static HeroJson GetHeroJsonByHeroId(int heroId)
    {
        return userHeroMap[heroId];
    }
    /// <summary>
    /// 添加系统英雄
    /// </summary>          
    static void AddHeroMap(string id)
    {
        JsonData heroList = Get("HeroList");
        HeroJson hero = JsonMapper.ToObject<HeroJson>(heroList[id].ToJson());
        heroMap.Add(hero.id,hero);
    }
    /// <summary>
    /// 根据英雄id取得系统配置数据
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static HeroJson GetHeroJsonById(int id)
    {
        if(heroMap.ContainsKey(id)) AddHeroMap(id.ToString());
        return heroMap[id];
    }    
}

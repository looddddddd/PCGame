using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 主视图
/// </summary>
public class MainView : BaseView
{
    #region 层级分类
    /// <summary>
    /// 对象池节点
    /// </summary>
    public GameObject pooler;
    /// <summary>
    /// 背景层
    /// </summary>
    public GameObject backgroundLayer;
    /// <summary>
    /// 装饰层
    /// </summary>
    public GameObject decorateLayer;
    /// <summary>
    /// 传送层
    /// </summary>
    public GameObject doorLayer;
    /// <summary>
    /// 道具层
    /// </summary>
    public GameObject itemLayer;
    /// <summary>
    /// 英雄层
    /// </summary>
    public GameObject heroLayer;
    /// <summary>
    /// 英雄状态层(眩晕等)
    /// </summary>
    public GameObject stateLayer;
    /// <summary>
    /// 特效层(技能等)
    /// </summary>
    public GameObject effectLayer;
    /// <summary>
    /// 数值展示层(伤害显示，经验增加等)
    /// </summary>
    public GameObject numericalLayer;
    /// <summary>
    /// 点击事件穿透层
    /// </summary>
    public GameObject passEventLayer;
    /// <summary>
    /// 事件层(剧情,对话等)
    /// </summary>
    public GameObject eventLayer;
    /// <summary>
    /// 弹窗层(选择框等)
    /// </summary>
    public GameObject popLayer;
    #endregion

    #region 预设引用
    /// <summary>
    /// 英雄预设
    /// </summary>
    public GameObject heroPrefab;
    /// <summary>
    /// 传送预设
    /// </summary>
    public GameObject doorPrefab;
    #endregion

    #region 地图设置
    /// <summary>
    /// 地图名字
    /// </summary>
    public GameObject tileNameGo;
    #endregion

    protected override void AddEventListener()
    {
        base.AddEventListener();
        NotiCenter.AddEventListener(KCEvent.KCTileChange, delegate(object data)
        {
            Fresh();
        });
    }

    protected override void OnStart()
    {
        base.OnStart();
        Pooler.SetPooler(pooler);
        Fresh();
    }
    /// <summary>
    /// 刷新
    /// </summary>
    void Fresh()
    {
        FreshTileName();
        FreshDoors();
        FreshHeros();
    }
    /// <summary>
    /// 刷新地块名字
    /// </summary>
    void FreshTileName()
    {
        tileNameGo.GetComponent<Text>().text = TileModel.currentTile.name;
    }
    /// <summary>
    /// 刷新英雄
    /// </summary>
    void FreshHeros()
    { 
        string name = "HeroPool";
        if (Pooler.PoolsContainsKey(name)) ReUseHeros();
        else GreateHeros();
    }
    /// <summary>
    /// 创建对象池,创建英雄卡牌
    /// </summary>
    void GreateHeros()
    {
        string name = "HeroPool";
        Dictionary<int,HeroJson> heroMap = HerosModel.GetHeroMap();
        Pooler.CreatePool(name, heroPrefab, heroMap.Count);
        foreach(var pair in heroMap)
        {
            GameObject heroGo = Pooler.GetPoolObj(name);
            heroGo.transform.SetParent(heroLayer.transform);
            heroGo.GetComponent<HeroView>().InitData(pair.Value.heroId);
        }
    }
    /// <summary>
    /// 重复使用英雄
    /// </summary>
    void ReUseHeros()
    {
        string name = "HeroPool";
        //回收
        int count = heroLayer.transform.childCount;
        for (int i = 0; i < count; i++)
        {
            GameObject childGo = heroLayer.transform.GetChild(0).gameObject;
            Pooler.PutPoolObj(name,childGo);
        }
        //再利用
        Dictionary<int, HeroJson> heroMap = HerosModel.GetHeroMap();
        foreach (var pair in heroMap)
        {
            GameObject heroGo = Pooler.GetPoolObj(name);
            heroGo.transform.SetParent(heroLayer.transform);
            heroGo.GetComponent<HeroView>().InitData(pair.Value.heroId);
        }
    }
    /// <summary>
    /// 刷新传送点
    /// </summary>
    void FreshDoors()
    {
        string name = "DoorPool";
        if (Pooler.PoolsContainsKey(name)) ReUseDoors();
        else GreateDoor();
    }
    /// <summary>
    /// 创建对象池,创建传送点
    /// </summary>
    void GreateDoor()
    {
        string name = "DoorPool";
        Vector2[] doors = TileModel.currentTile.doors;
        Pooler.CreatePool(name, doorPrefab, doors.Length);
        for (int i = 0; i < doors.Length; i++) 
        {
            GameObject doorGo = Pooler.GetPoolObj(name);
            doorGo.transform.SetParent(doorLayer.transform);
            doorGo.GetComponent<DoorView>().InitData(doors[i],i);
        }
    }
    /// <summary>
    /// 重复使用传送点
    /// </summary>
    void ReUseDoors()
    {
        string name = "DoorPool";
        //回收
        int count = doorLayer.transform.childCount;
        for (int i = 0; i < count; i++)
        {
            GameObject childGo = doorLayer.transform.GetChild(0).gameObject;
            Pooler.PutPoolObj(name, childGo);
        }
        //再利用
        Vector2[] doors = TileModel.currentTile.doors;
        for (int i = 0; i < doors.Length; i++)
        {
            GameObject doorGo = Pooler.GetPoolObj(name);
            doorGo.transform.SetParent(doorLayer.transform);
            doorGo.GetComponent<DoorView>().InitData(doors[i], i);
        }
    }
}

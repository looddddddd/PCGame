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
    /// 触摸层
    /// </summary>
    public GameObject touchLayer;
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
    /// <summary>
    /// 文本展示
    /// </summary>
    public GameObject textPrefab;
    #endregion

    #region 地图设置
    /// <summary>
    /// 地图名字
    /// </summary>
    public GameObject tileNameGo;
    /// <summary>
    /// 触摸展示对象
    /// </summary>
    public RectTransform touchRtf;
    #endregion

    bool isObserveModel = false;

    protected override void AddEventListener()
    {
        base.AddEventListener();
        NotiCenter.AddEventListener(KCEvent.KCTileChange, delegate(object data)
        {
            Fresh();
        });
        NotiCenter.AddEventListener(KCEvent.KCItemsChange,delegate(object data)
        {
            ShowAddItemsAni((int[])data);
        });
        NotiCenter.AddEventListener(KCEvent.KCHeroHPChange, delegate(object data)
        {
            FreshText(data);
        });
    }
    protected override void OnAwake()
    {
        base.OnAwake();
        GM.Init();
    }
    protected override void OnStart()
    {
        base.OnStart();
        PoolerInit();
        Fresh();
    }
    protected override void OnUpdate()
    {
        base.OnUpdate();
        if (Input.GetMouseButton(0))
        {
            touchRtf.gameObject.SetActive(true);
            touchRtf.anchoredPosition = Input.mousePosition;
            return;
        }
        touchRtf.gameObject.SetActive(false);
    }
    /// <summary>
    /// 初始化对象池
    /// </summary>
    void PoolerInit()
    {
        Pooler.SetPooler(pooler);
        Pooler.CreatePool(PoolType.HeroPool.ToString(), heroPrefab);
        Pooler.CreatePool(PoolType.DoorPool.ToString(), doorPrefab);
        Pooler.CreatePool(PoolType.TextPool.ToString(), textPrefab);
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
        //回收
        int count = heroLayer.transform.childCount;
        for (int i = 0; i < count; i++)
        {
            GameObject childGo = heroLayer.transform.GetChild(0).gameObject;
            Pooler.PutPoolObj(PoolType.HeroPool.ToString(), childGo);
        }
        //再利用
        Dictionary<int, HeroJson> heroMap = HerosModel.GetHeroMap();
        foreach (var pair in heroMap)
        {
            GameObject heroGo = Pooler.GetPoolObj(PoolType.HeroPool.ToString());
            heroGo.transform.SetParent(heroLayer.transform);
            heroGo.GetComponent<HeroView>().InitData(pair.Value.heroId);
            heroGo.name = pair.Value.heroId.ToString();
        }
    }
    /// <summary>
    /// 刷新传送点
    /// </summary>
    void FreshDoors()
    {
        //回收
        int count = doorLayer.transform.childCount;
        for (int i = 0; i < count; i++)
        {
            GameObject childGo = doorLayer.transform.GetChild(0).gameObject;
            Pooler.PutPoolObj(PoolType.DoorPool.ToString(), childGo);
        }
        //再利用
        Vector2[] doors = TileModel.currentTile.doors;
        for (int i = 0; i < doors.Length; i++)
        {
            GameObject doorGo = Pooler.GetPoolObj(PoolType.DoorPool.ToString());
            doorGo.transform.SetParent(doorLayer.transform);
            doorGo.GetComponent<DoorView>().InitData(doors[i], i);
        }
    }
    /// <summary>
    /// 刷新文本展示
    /// </summary>
    void FreshText(object data)
    {
        GameObject textGo = Pooler.GetPoolObj(PoolType.TextPool.ToString());
        textGo.transform.SetParent(numericalLayer.transform);
        textGo.GetComponent<TextView>().Fresh(data);
    }
    /// <summary>
    /// 展示添加道具动画
    /// </summary>    
    void ShowAddItemsAni(int[] items)
    {
        for (int i = 0; i < items.Length; i++)
        {
            Debug.Log(items[i]);
        }
    }
    /// <summary>
    /// 观察模式
    /// </summary>
    void ObserveModel()
    {
        passEventLayer.SetActive(true);
        touchLayer.SetActive(false);
    }
    /// <summary>
    /// 攻击模式
    /// </summary>
    void AttModel()
    {
        passEventLayer.SetActive(false);
        touchLayer.SetActive(true);        
    }
}

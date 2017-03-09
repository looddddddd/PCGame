using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainView : BaseView {
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
    /// 事件穿透层
    /// </summary>
    public GameObject passEventLayer;
}

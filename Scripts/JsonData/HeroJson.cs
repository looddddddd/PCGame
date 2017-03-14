using UnityEngine;
using System.Collections;
/// <summary>
/// 英雄数据模型
/// </summary>
public class HeroJson
{
    /// <summary>
    /// 系统id
    /// </summary>
    public int id;
    /// <summary>
    /// 特性id
    /// </summary>
    public int traitId;
    public int type;
    public string name;
    public int hp;
    public int att;
    public int[] items;
    public HeroView view;
    /// <summary>
    /// 临时的数量id
    /// </summary>    
    public int heroId;
}

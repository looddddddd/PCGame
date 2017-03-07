using UnityEngine;
using System.Collections;
/// <summary>
/// 英雄数据模型
/// </summary>
public class HeroJson
{
    public int id;
    /// <summary>
    /// 特性id
    /// </summary>
    public int traitId;
    public int type;
    public string name;
    public int hp;
    public HeroView view;
}

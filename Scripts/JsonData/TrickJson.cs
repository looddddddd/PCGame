using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 绝招数据模型--最多携带5个技能--系统技能待定
/// </summary>
public class TrickJson 
{
    public int id;
    public int orderId;
    public int type;
    public string name;
    public int level;
    public int maxLevel;
    public string picUrl;
    public int att;
    public int exp;
    public int nextExp;
    // public TrickView view;
}

using UnityEngine;
using System.Collections;
/// <summary>
/// 传送门数据模型
/// </summary>
public class DoorJson 
{
    public int id;
    public int type;
    public string name;
    public int useTimes;
    public int maxUseTimes;
    public int[] doorkeepers;
    public DoorView view;
}

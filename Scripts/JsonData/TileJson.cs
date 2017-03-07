using UnityEngine;
using System.Collections;
/// <summary>
/// 地块数据模型
/// </summary>
public class TileJson 
{
    public int id;
    public int type;
    public string name;
    public Vector2 coordinate;
    public int[] doors;
    public int[] heros;
    public string bgPicUrl;
}

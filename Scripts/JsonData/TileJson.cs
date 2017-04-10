using UnityEngine;
using System.Collections;
/// <summary>
/// 地块数据模型
/// </summary>
public class TileJson 
{
    private int _id;
    public int id 
    {
        get 
        { 
            return _id;
        }
        set 
        {
            _id = value;
            coordinate = TileModel.GetCoordinateById(_id);
            name = string.Format("[{0},{1}]", coordinate[0], coordinate[1]);
            doors = DoorsModel.GetDoors(_id);
        }
    }
    public int type;
    public string name;
    public Vector2 coordinate;
    public Vector2[] doors;
    public int[] heros = new int[] {1,2};//展示地图上的英雄id
    public string picUrl;

}

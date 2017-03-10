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
        get { return _id; }
        set 
        {
            _id = value;
            coordinate = TileModel.GetCoordinateById(_id);
            doors = DoorsModel.GetDoors(_id);
        }
    }
    public int type;
    public string name;
    public Vector2 coordinate;
    public Vector2[] doors;
    public int[] heros;
    public string bgPicUrl;

}

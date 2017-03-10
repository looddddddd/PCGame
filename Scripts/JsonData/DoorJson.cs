using UnityEngine;
using System.Collections;
/// <summary>
/// 传送门数据模型
/// </summary>
public class DoorJson 
{
    private int _id;
    public int id
    {
        get { return _id; }
        set
        {
            _id = value;
            coordinate = TileModel.GetCoordinateById(_id);
        }
    }
    public int type;
    public string name;
    public int useTimes;
    public int maxUseTimes;
    public int[] doorkeepers;
    public Vector2 coordinate;
    public DoorView view;
}

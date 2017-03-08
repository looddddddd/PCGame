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
            coordinate = new Vector2((float)_id, (float)_id);
            doors = new int[] { _id };
        }
    }
    public int type;
    public string name;
    public Vector2 coordinate;
    public int[] doors;
    public int[] heros;
    public string bgPicUrl;

}

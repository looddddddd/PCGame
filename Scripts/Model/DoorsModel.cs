using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsModel : Singleton<DoorsModel> 
{
    /// <summary>
    /// 根据地块id取得传送门坐标数组
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static Vector2[] GetDoors(int id)
    {
        Vector2 size = TileModel.size;
        Vector2 coordinate = TileModel.GetCoordinateById(id);
        //上
        Vector2 coordinateUp = new Vector2(coordinate.x, coordinate.y + 1);
        coordinateUp.y = coordinateUp.y > size.y - 1 ? coordinateUp.y - size.y : coordinateUp.y;
        //下
        Vector2 coordinateDown = new Vector2(coordinate.x, coordinate.y - 1);
        coordinateDown.y = coordinateDown.y < 0 ? coordinateDown.y + size.y : coordinateDown.y;
        //左
        Vector2 coordinateLeft = new Vector2(coordinate.x - 1, coordinate.y);
        coordinateLeft.x = coordinateLeft.x < 0 ? coordinateLeft.x + size.x : coordinateLeft.x;
        //右
        Vector2 coordinateRight = new Vector2(coordinate.x + 1, coordinate.y);
        coordinateRight.x = coordinateRight.x > size.x - 1 ? coordinateRight.x - size.x : coordinateRight.x;

        return new Vector2[4] { coordinateUp, coordinateDown, coordinateLeft, coordinateRight };
    }
    /// <summary>
    /// 根据id取得传送数据
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static DoorJson GetDoorJsonById(int id)
    {
        return new DoorJson();
    }
}

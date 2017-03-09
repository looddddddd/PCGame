using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 地块对象数据
/// </summary>
public class TileModel : Singleton<TileModel> {
    public static Vector2 size = new Vector2(5, 5);
    static Dictionary<int, TileJson> tileMap = new Dictionary<int, TileJson>();
    /// <summary>
    /// 初始化地块数据
    /// </summary>
    public static void InitTileModel()
    {
        int _x = (int)size.x;
        int _y = (int)size.y;
        for (int y = 0; y < _y; y++)
        {
            for (int x = 0; x < _x; x++)
            {
                TileJson tile = new TileJson();
                int id = x + y * (int)size.x +1;
                Debug.Log(id);
                tile.id = id;
                tile.type = 1;
                tile.name = string.Format("[{0},{1}]", tile.coordinate[0], tile.coordinate[1]);
                tile.doors = new int[] { 1, 2 };//--转DoorsMgr
                tile.heros = null;//--转HerosMgr
                tile.bgPicUrl = id.ToString();
                tileMap.Add(tile.id, tile);
            }
        }
        TileMgr.currentTile = tileMap[1];
    }
    /// <summary>
    /// 根据id取得地块信息
    /// </summary>
    /// <param name="id"></param>
    public static TileJson GetTileById(int id)
    {
        return tileMap[id];
    }
    public static Vector2 GetCoordinateById(int id)
    {
        int x = (id - 1) / (int)size.y;
        int y = (id - 1) % (int)size.y;
        return new Vector2(x,y);
    }
}

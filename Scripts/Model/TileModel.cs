using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 地块对象数据
/// </summary>
public class TileModel : Singleton<TileModel> {
    private static TileJson _currentTile;
    /// <summary>
    /// 当前的地块
    /// </summary>
    public static TileJson currentTile
    {
        get { return _currentTile; }
        set { _currentTile = value; }
    }
    /// <summary>
    /// 地图尺寸
    /// </summary>
    public static Vector2 size = new Vector2(10, 4);
    /// <summary>
    /// 地块信息map
    /// </summary>
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
                int id = x + y * (int)size.x + 1;
                tile.id = id;
                tile.type = 1;
                tile.name = string.Format("[{0},{1}]", tile.coordinate[0], tile.coordinate[1]);
                tile.heros = null;//--转HerosMgr
                tile.bgPicUrl = id.ToString();
                tileMap.Add(tile.id, tile);
            }
        }
        currentTile = tileMap[1];
    }
    /// <summary>
    /// 切换地块
    /// </summary>
    /// <param name="coordinate"></param>
    public static void SwitchTile(Vector2 coordinate)
    {
        currentTile = tileMap[GetTileIdByCoordinate(coordinate)];
        NotiCenter.DispatchEvent(KCEvent.KCTileChange);
    }
    /// <summary>
    /// 根据id取得地块信息
    /// </summary>
    /// <param name="id"></param>
    public static TileJson GetTileById(int id)
    {
        return tileMap[id];
    }
    /// <summary>
    /// 根据id取得坐标
    /// </summary>
    /// <param name="id">地块id</param>
    /// <returns>坐标Vector2</returns>
    public static Vector2 GetCoordinateById(int id)
    {
        int x = (id - 1) / (int)size.y;
        int y = (id - 1) % (int)size.y;
        return new Vector2(x,y);
    }
    /// <summary>
    /// 根据坐标取得id
    /// </summary>
    /// <param name="coordinate"></param>
    /// <returns></returns>
    public static int GetTileIdByCoordinate(Vector2 coordinate)
    {
        float id = coordinate.x + coordinate.y * size.y + 1;
        Debug.Log(coordinate);
        Debug.Log(id);
        return (int)id;
    }
}

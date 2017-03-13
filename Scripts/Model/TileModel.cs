using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
/// <summary>
/// 地块对象数据
/// </summary>
public class TileModel : BaseModel {
    private static TileJson _currentTile;
    /// <summary>
    /// 当前的地块
    /// </summary>
    public static TileJson currentTile
    {
        get { return _currentTile; }
        set { _currentTile = value; }
    }

    const float _size = 3f;
    /// <summary>
    /// 地图尺寸
    /// </summary>
    public static Vector2 size = new Vector2(_size, _size);
    /// <summary>
    /// 地块信息map
    /// </summary>
    static Dictionary<int, TileJson> tileMap = new Dictionary<int, TileJson>();
    /// <summary>
    /// 初始化
    /// </summary>
    public static void Init()
    {
        JsonData userInfo = Get("UserInfo");
        currentTile = AddTileJson(userInfo["tileId"].ToString());
        FreshData();
    }
    /// <summary>
    /// 切换地块
    /// </summary>
    /// <param name="coordinate"></param>
    public static void SwitchTile(Vector2 coordinate)
    {
        int key = GetTileIdByCoordinate(coordinate);
        if(tileMap.ContainsKey(key)) currentTile = tileMap[key];
        else currentTile = AddTileJson(key.ToString()); 
        FreshData();
        NotiCenter.DispatchEvent(KCEvent.KCTileChange);
    }
    /// <summary>
    /// 刷新数据
    /// </summary>    
    static void FreshData()
    {
        HerosModel.FreshHeroMap();
        System.GC.Collect();
    }
    /// <summary>
    /// 添加地块
    /// </summary>
    /// <param name="id"></param>    
    static TileJson AddTileJson(string id)
    {
        JsonData tileList = Get("TileList");
        TileJson tile = JsonMapper.ToObject<TileJson>(tileList[id].ToJson());
        tileMap.Add(tile.id, tile);
        return tile;
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
        int x = (id - 1) / (int)size.x;
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
        return (int)id;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 地块对象数据
/// </summary>
public class TileModel : Singleton<TileModel> {
    static Dictionary<int, TileJson> tileMap = new Dictionary<int, TileJson>();
    /// <summary>
    /// 初始化地块数据
    /// </summary>
    public static void InitTileModel()
    {
        TileJson tile = new TileJson();
        tile.id = 1;
        tile.type = 1;
        tile.name = string.Format("[{0},{1}]",tile.coordinate[0],tile.coordinate[1]);
        tile.doors = new int[] { 1, 2 };//--转DoorsMgr
        tile.heros = null;//--转HerosMgr
        tile.bgPicUrl = "111";

        TileJson tile2 = new TileJson();
        tile2.id = 2;
        tile2.type = 2;
        tile2.name = string.Format("[{0},{1}]", tile2.coordinate[0], tile2.coordinate[1]); ;
        tile2.doors = new int[] { 1, 2 };//--转DoorsMgr
        tile2.heros = null;//--转HerosMgr
        tile2.bgPicUrl = "222";

        tileMap.Add(tile.id, tile);
        tileMap.Add(tile2.id, tile);
    }
    /// <summary>
    /// 根据id取得地块信息
    /// </summary>
    /// <param name="id"></param>
    public static TileJson GetTileById(int id)
    {
        return tileMap[id];
    }
}

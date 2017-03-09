using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 地块管理器
/// </summary>
public class TileMgr : Singleton<TileMgr> {

    private static TileJson _currentTile;
    /// <summary>
    /// 当前处于的地块
    /// </summary>
    public static TileJson currentTile 
    {
        get { return _currentTile; }
        set { _currentTile = value; }
    }
    /// <summary>
    /// 切换地块
    /// </summary>
    public static TileJson SwitchTile(int id)
    {
        currentTile = TileModel.GetTileById(id);
        return currentTile;
    }

}

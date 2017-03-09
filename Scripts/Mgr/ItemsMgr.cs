using UnityEngine;
using System.Collections;
/// <summary>
/// 道具对象管理器
/// </summary>
public class ItemsMgr : Singleton<ItemsMgr>
{
    static ItemJson _currentItem;
    /// <summary>
    /// 当前持有的道具
    /// </summary>
    public static ItemJson currentItem
    {
        get { return _currentItem; }
        set
        {
            if (_currentItem == value) return;
            _currentItem = value;
            //NotiCenter.DispatchEvent(KCEvent.KCItemChange, null);
        }
    }
    /// <summary>
    /// 增加道具
    /// </summary>
    /// <param name="item">道具类</param>
    public static void AddItem(ItemJson item) 
    {
        ItemsModel.AddItem(item);
    }
    /// <summary>
    /// 使用道具
    /// </summary>
    public static bool UseItem() 
    {
        bool isUse = ItemsModel.UseItem();
        if (!isUse) return isUse;
        if(currentItem.view) currentItem.view.Fresh(FreshType.Dur);
        return isUse;
    }
}

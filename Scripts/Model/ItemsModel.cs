using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 道具对象数据
/// </summary>
public  class ItemsModel : BaseModel
{
    /// <summary>
    /// 玩家所有的道具
    /// </summary>
    static Dictionary<int, ItemJson> itemMap = new Dictionary<int, ItemJson>();
    /// <summary>
    /// 目前还可使用的道具
    /// </summary>
    static Dictionary<int, ItemJson> useItemMap = new Dictionary<int, ItemJson>();

    public static void InitItemsModel()
    {
        ItemJson item1 = new ItemJson();
        item1.id = 1;
        item1.orderId = 1;
        item1.type = (int)ItemType.Broken;
        item1.name = "小刀";
        item1.durable = 10;
        item1.maxDurable = 10;
        item1.att = 2;

        ItemJson item2 = new ItemJson();
        item2.id = 2;
        item2.orderId = 2;
        item2.type = (int)ItemType.Unbroken;
        item2.name = "神器";
        item2.durable = 100;
        item2.maxDurable = 100;
        item2.att = 5;

        itemMap.Add(item1.id, item1);
        itemMap.Add(item2.id, item2);

        useItemMap.Add(item1.id, item1);
        useItemMap.Add(item2.id, item2);

        ItemsMgr.currentItem = item1;
    }
    /// <summary>
    /// 添加道具
    /// 1.该道具未曾添加过
    /// 2.已添加过 - 1.未达添加上限 - 1.未达添加上限
    ///                                              2.可余出部分
    ///                                              3.刚刚好
    ///                    2.已达添加上限
    /// </summary>
    /// <param name="newItem"></param>
    public static void AddItem(ItemJson newItem)
    {
        if (!itemMap.ContainsKey(newItem.id)) 
        {
            itemMap.Add(newItem.id, newItem);
            useItemMap.Add(newItem.id, newItem);
            return;
        }

        ItemJson oldItem = itemMap[newItem.id];
        if (oldItem.type == (int)ItemType.Unbroken) return;//数据出错，出现2个唯一性装备
        if (oldItem.durable == 0) useItemMap.Add(newItem.id, newItem);//继续使用
        oldItem.durable += newItem.durable;
        if (oldItem.durable >= oldItem.maxDurable) oldItem.durable = oldItem.maxDurable;//达到上限值
    }
    /// <summary>
    /// 使用道具
    /// 1.可损坏
    /// 2.不可损坏
    /// </summary>
    public static bool UseItem()
    {
        ItemJson item = ItemsMgr.currentItem;
        if (item.type == (int)ItemType.Unbroken) return true;
        if (item.durable == 0) return false;
        int lossValue = 1;//当损耗值大于当前耐久值，存在逻辑bug
        item.durable -= lossValue;
        if (item.durable <= 0) item.durable = 0;
        if (item.durable == 0) useItemMap.Remove(item.id);//已损坏为0
        return true;
    }
    /// <summary>
    /// 取得目前还可使用的道具
    /// </summary>
    /// <returns></returns>
    public static Dictionary<int, ItemJson> GetUseItemMap()
    {
        return useItemMap;
    }
    /// <summary>
    /// 根据道具id取得道具
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static ItemJson GetItemById(int id)
    {
        return itemMap[id];
    }
}

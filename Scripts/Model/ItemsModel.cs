using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
/// <summary>
/// 道具对象数据
/// </summary>
public  class ItemsModel : BaseModel
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
            // if (_currentItem == value) return;
            _currentItem = value;
        }
    }
    /// <summary>
    /// 系统配置道具
    /// </summary>
    static Dictionary<int, ItemJson> itemMap = new Dictionary<int, ItemJson>();
    /// <summary>
    /// 玩家拥有的道具
    /// </summary>
    static Dictionary<int, ItemJson> userItemMap = new Dictionary<int, ItemJson>();    
    /// <summary>
    /// 向用户数据中添加道具
    /// </summary>
    public static void AddItems(int[] items)
    {
        for(int i = 0;i<items.Length;i++)
        {
            ItemJson newItem = itemMap.ContainsKey(items[i]) ? itemMap[items[i]] : AddItemJson(items[i].ToString());
            if(userItemMap.ContainsKey(items[i])) //已经有道具了
            {
                //1.替换
                userItemMap[items[i]] = newItem;
                //2叠加耐久
                userItemMap[items[i]].durable += newItem.durable;
                //3.舍弃
            }
            else 
            {
                userItemMap.Add(items[i],newItem); //还没有道具
            }
        }
        NotiCenter.DispatchEvent(KCEvent.KCItemsChange,(object)items);
    }
    /// <summary>
    /// 添加系统道具
    /// </summary>
    static ItemJson AddItemJson(string id)
    {
        JsonData itemList = Get("ItemList");
        ItemJson item = JsonMapper.ToObject<ItemJson>(itemList[id].ToJson());
        itemMap.Add(item.id,item);
        return item;
    }
    /// <summary>
    /// 取得用户拥有的道具列表--（背包展示）
    /// </summary>
    /// <returns></returns>
    public static Dictionary<int, ItemJson> GetUserItemMap()
    {
        return userItemMap;
    }
    /// <summary>
    /// 根据道具id取得系统道具
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static ItemJson GetItemById(int id)
    {
        if(!itemMap.ContainsKey(id)) AddItemJson(id.ToString());
        return itemMap[id];
    }
}

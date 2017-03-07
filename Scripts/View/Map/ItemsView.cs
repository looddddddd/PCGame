using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using LitJson;
public class ItemsView : BaseView
{
    public GameObject showCurrentItem;
    public ScrollRect itemsScrollView;
    protected override void AddEventListener()
    {
        base.AddEventListener();
    }
    protected override void OnStart()
    {
        base.OnStart();
        ItemsModel.InitItemsModel();
        InitItemsGo();
    }
    void InitItemsGo()
    {
        Dictionary<int, ItemJson> useItemMap = ItemsModel.GetUseItemMap();
        foreach(KeyValuePair<int,ItemJson> pair in useItemMap)
        {
            ItemJson item = useItemMap[pair.Key];

            GameObject go = Instantiate(showCurrentItem);
            go.SetActive(true);
            go.transform.SetParent(itemsScrollView.content);
            RectTransform rtf = go.GetComponent<RectTransform>();
            rtf.localScale = Vector3.one;
            ItemView itemView = go.GetComponent<ItemView>();
            itemView.InitData(item.id);
        }
    }
}

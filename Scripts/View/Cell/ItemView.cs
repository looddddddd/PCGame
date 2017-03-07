using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// 单个道具展示视图
/// </summary>
public class ItemView : BaseView 
{
    public Text name;
    public Text durable;
    public Text maxDurable;
    public Text att;
    ItemJson item;
    protected override void OnTogChanged(string togName, bool isChanged)
    {
        ItemsMgr.currentItem = item;
    }
    public void InitData(int id)
    {
        item = ItemsModel.GetItemById(id);
        SetToggle();
        item.view = this;
        FreshView();
    }
    void SetToggle()
    {
        if (item.id == ItemsMgr.currentItem.id) GetComponent<Toggle>().isOn = true;
    }
    void FreshView()
    {
        name.text = item.name;
        durable.text = item.durable.ToString();
        maxDurable.text = "/" + item.maxDurable.ToString();
        att.text = item.att.ToString();
    }
    public void Fresh(FreshType type)
    {
        switch (type)
        {
            case FreshType.Dur:
                durable.text = item.durable.ToString();
                maxDurable.text = "/" + item.maxDurable.ToString();
                break;
            case FreshType.Att:

                break;
        }
    }
}

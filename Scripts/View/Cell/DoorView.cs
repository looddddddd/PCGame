using UnityEngine;
using System.Collections;

public class DoorView : BaseView 
{
    DoorJson door;
    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="coordinate">坐标</param>
    /// <param name="index">传送类型</param>
    public void InitData(Vector2 coordinate,int index)
    {
        int id = TileModel.GetTileIdByCoordinate(coordinate);
        door = DoorsModel.GetDoorJsonById(id);
        door.id = id;
        door.view = this;

        SetDoorTypeAndPosition(index);
    }
    /// <summary>
    /// 设置传送类型
    /// </summary>
    void SetDoorTypeAndPosition(int index)
    {
        float ud = 200;
        float lr = 300;
        RectTransform rtf = GetComponent<RectTransform>();
        door.type = index;
        switch (index)
        {
            case (int)DoorType.Up:
                rtf.anchoredPosition = new Vector2(0, ud);
                break;
            case (int)DoorType.Down:
                rtf.anchoredPosition = new Vector2(0, -ud);
                break;
            case (int)DoorType.Left:
                rtf.anchoredPosition = new Vector2(-lr, 0);
                break;
            case (int)DoorType.Right:
                rtf.anchoredPosition = new Vector2(lr, 0);
                break;
            default:
                rtf.anchoredPosition = new Vector2(0, 0);
                break;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="btnName"></param>
    protected override void OnBtnClick(string btnName)
    {
        base.OnBtnClick(btnName);
        TileModel.SwitchTile(door.coordinate);
    }
}

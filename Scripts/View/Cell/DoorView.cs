using UnityEngine;
using System.Collections;

public class DoorView : BaseView 
{
    protected override void OnBtnClick(string btnName)
    {
        base.OnBtnClick(btnName);
        Debug.Log(1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class MaskView : BaseView
{
    Image img;
    Tweener tw;
    protected override void OnStart()
    {
        base.OnStart();
        img = GetComponent<Image>();
        ShowMask();
    }

    protected override void AddEventListener()
    {
        base.AddEventListener();
        NotiCenter.AddEventListener(KCEvent.KCTileChange, delegate(object data)
        {
            ShowMask();
        });
    }

    void ShowMask()
    {
        gameObject.SetActive(true);
        tw = img.DOFade(0, 1f).OnComplete(delegate()
        {
            HideMask();
        });
    }

    void HideMask()
    {
        gameObject.SetActive(false);
        img.color = new Color(45f/255f,45f/255f,45f/255f,255f/255f);
    }
}

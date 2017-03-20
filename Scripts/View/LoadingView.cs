using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class LoadingView : BaseView {

    protected override void OnAwake()
    {
        base.OnAwake();
        GM.Init();
        StartCoroutine(Utils.DelayDo(GM.StartGame, 0.5f));
    }
}

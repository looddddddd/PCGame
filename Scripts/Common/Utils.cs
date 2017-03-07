using UnityEngine;
using System.Collections;
using System;
public class Utils : MonoBehaviour {
    /// <summary>
    /// 延迟加载
    /// </summary>
    /// <param name="action">事件</param>
    /// <param name="delaySeconds">延迟的时间</param>
    /// <returns></returns>
    public IEnumerator DelayDo(Action action ,float delaySeconds)
    {
        yield return  new WaitForSeconds(delaySeconds);
        action();
    }
}

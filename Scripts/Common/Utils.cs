using UnityEngine;
using System.Collections;
using System;
public class Utils : Singleton<Utils>
{
    /// <summary>
    /// 延迟加载
    /// </summary>
    /// <param name="action">事件</param>
    /// <param name="delaySeconds">延迟的时间</param>
    /// <returns></returns>
    public static IEnumerator DelayDo(Action action, float delaySeconds = 0f)
    {
        yield return  new WaitForSeconds(delaySeconds);
        if(action != null)action();
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 消息回调
/// </summary>
/// <param name="vo"></param>
public delegate void CallBack(object data);
/// <summary>
/// 全局派发事件中心
/// </summary>
public class NotiCenter
{
    /// <summary>
    /// 事件存储数组(数据派发)
    /// </summary>
    private static Dictionary<string, CallBack> eventListerners = new Dictionary<string, CallBack>();
    /// <summary>
    /// 添加事件监听器
    /// </summary>
    /// <param name="eventName">监听器名称</param>
    /// <param name="cb">回调方法</param>
    public static void AddEventListener(KCEvent type, CallBack cb)
    {
        string eventName = type.ToString();
        if (!eventListerners.ContainsKey(eventName))
            eventListerners[eventName] = null; //表示首次监听,
        eventListerners[eventName] += cb;
    }
    /// <summary>
    /// 移除某个事件中的某个回调
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="cb"></param>
    public static void RemoveEventListener(KCEvent type, CallBack cb)
    {
        string eventName = type.ToString();
        if (eventListerners.ContainsKey(eventName))
            eventListerners[eventName] -= cb;
    }
    /// <summary>
    /// 移除某个事件监听器
    /// </summary>
    /// <param name="evenName">监听器名称</param>
    public static void RemoveEventListener(KCEvent type)
    {
        string eventName = type.ToString();
        if (eventListerners.ContainsKey(eventName))
            eventListerners.Remove(eventName);
    }
    /// <summary>
    /// 移除所有事件监听器
    /// </summary>
    public static void RemoveAllEventListener()
    {
        eventListerners.Clear();
    }
    /// <summary>
    /// 派发事件
    /// </summary>
    /// <param name="eventName">事件监听器名称</param>
    /// <param name="data">数据</param>
    public static void DispatchEvent(KCEvent type, object data = null)
    {
        string eventName = type.ToString();
        if (!eventListerners.ContainsKey(eventName))
            return;
        eventListerners[eventName](data);
    }
}

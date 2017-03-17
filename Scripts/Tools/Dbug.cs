using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Dbug
{
    static bool isDebug = true;
    static bool isLog = true;
    static bool isLogError = true;
    static bool isLogWarning = true;
    /// <summary>
    /// 打印输出
    /// </summary>
    /// <param name="log"></param>
    public static void Log(object message, Object context = null)
    {
        if (!isDebug) return;
        if (!isLog) return;
        if (context == null) Debug.Log(message);
        else Debug.Log(message, context);
    }
    /// <summary>
    /// 打印错误
    /// </summary>
    /// <param name="message"></param>
    /// <param name="context"></param>
    public static void LogError(object message, Object context = null)
    {
        if (!isDebug) return;
        if (!isLogError) return;
        if (context == null) Debug.LogError(message);
        else Debug.LogError(message, context);
    }
    /// <summary>
    /// 打印警告
    /// </summary>
    /// <param name="message"></param>
    /// <param name="context"></param>
    public static void LogWarning(object message, Object context = null)
    {
        if (!isDebug) return;
        if (!isLogWarning) return;
        Debug.LogWarning(message);
    }
}

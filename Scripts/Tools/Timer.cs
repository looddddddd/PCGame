using UnityEngine;
using System.Collections;
using System;
/// <summary>
/// 完成时的事件
/// </summary>
public delegate void CompleteEvent();
/// <summary>
/// 更新事件
/// </summary>
/// <param name="t"></param>
public delegate void UpdateEvent(float t);
/// <summary>
/// 计时器基类
/// </summary>
public class Timer : MonoBehaviour
{
    /// <summary>
    /// 是否打印输出
    /// </summary>
    bool isLog = true;
    /// <summary>
    /// 更新事件
    /// </summary>
    UpdateEvent updateEvent;
    /// <summary>
    /// 完成进度事件
    /// </summary>
    CompleteEvent onCompleted;
    /// <summary>
    /// 计时时间
    /// </summary>
    float timeTarget;
    /// <summary>
    /// 开始计时时间
    /// </summary>
    float timeStart;
    /// <summary>
    /// 现在时间
    /// </summary>
    float timeNow;
    /// <summary>
    /// 计时偏差
    /// </summary>
    float offsetTime;
    /// <summary>
    /// 是否开始计时
    /// </summary>
    bool isTimer;
    /// <summary>
    /// 计时结束后是否销毁
    /// </summary>
    bool isDestory = true;
    /// <summary>
    /// 计时是否结束
    /// </summary>
    bool isEnd;
    /// <summary>
    /// 是否忽略时间速率
    /// </summary>
    bool isIgnoreTimeScale = true;
    /// <summary>
    /// 是否重新开始(当计时结束后)
    /// </summary>
    bool isRepeate;
    /// <summary>
    /// 获取游戏已运行的时间
    /// </summary>
    float Time_
    {
        get { return isIgnoreTimeScale ? Time.realtimeSinceStartup : Time.time; }
    }
    /// <summary>
    /// now = 现在时间 - 开始计时时间;
    /// </summary>
    float now;
    /// <summary>
    /// Update
    /// </summary>
    void Update()
    {
        if (isTimer)
        {
            timeNow = Time_ - offsetTime;
            now = timeNow - timeStart;
            if (updateEvent != null)
                updateEvent(Mathf.Clamp01(now / timeTarget));
            if (now > timeTarget)
            {
                if (onCompleted != null)
                    onCompleted();
                if (!isRepeate)
                    Destory();
                else
                    ReStartTimer();
            }
        }
    }
    /// <summary>
    /// 退回到桌面时触发
    /// </summary>
    /// <param name="isPause_"></param>
    void OnApplicationPause(bool isPause_)
    {
        if (isPause_)
        {
            Debug.Log("游戏暂停"); //缩到桌面的时候触发
            PauseTimer();
        }
        else
        {
            Debug.Log("游戏继续"); //回到游戏的时候触发 最晚
            ConnitueTimer();
        }
    }
    /// <summary>  
    /// 1.创建计时器:名字  
    /// </summary>  
    public static Timer CreateTimer(string gobjName = "Timer")
    {
        GameObject g = new GameObject(gobjName);
        Timer timer = g.AddComponent<Timer>();
        return timer;
    }

    /// <summary>
    /// 2.开始计时
    /// </summary>
    /// <param name="time_">计时总时长</param>
    /// <param name="onCompleted_">计时结束回调</param>
    /// <param name="update">计时更新</param>
    /// <param name="isIgnoreTimeScale_">是否忽略时间速率</param>
    /// <param name="isRepeate_">是否重新开始</param>
    /// <param name="isDestory_">计时结束后是否销毁</param>
    public void StartTiming(float time_, CompleteEvent onCompleted_, UpdateEvent update = null, bool isIgnoreTimeScale_ = true, bool isRepeate_ = false, bool isDestory_ = true)
    {
        timeTarget = time_;
        if (onCompleted_ != null)
            onCompleted = onCompleted_;
        if (update != null)
            updateEvent = update;
        isDestory = isDestory_;
        isIgnoreTimeScale = isIgnoreTimeScale_;
        isRepeate = isRepeate_;

        timeStart = Time_;
        offsetTime = 0;
        isEnd = false;
        isTimer = true;
    }
    /// <summary>
    /// 暂停时的时间
    /// </summary>
    float _pauseTime;
    /// <summary>  
    /// 3.暂停计时  
    /// </summary>  
    public void PauseTimer()
    {
        if (isEnd)
        {
            if (isLog) Debug.LogWarning("计时已经结束！");
        }
        else
        {
            if (isTimer)
            {
                isTimer = false;
                _pauseTime = Time_;
            }
        }
    }
    /// <summary>  
    /// 4.继续计时  
    /// </summary>  
    public void ConnitueTimer()
    {
        if (isEnd)
        {
            if (isLog) Debug.LogWarning("计时已经结束！请从新计时！");
        }
        else
        {
            if (!isTimer)
            {
                offsetTime += (Time_ - _pauseTime);
                isTimer = true;
            }
        }
    }
    /// <summary>
    /// 5.1在原有的基础上增加或减少计时总的时间
    /// </summary>
    /// <param name="time_"></param>
    public void ChangeTargetTime(float time_)
    {
        timeTarget += time_;
    }
    /// <summary>
    /// 5.2在原有的基础上增加或减少当前的时间
    /// </summary>
    /// <param name="time_"></param>
    public void ChangeOffsetTime(float time_)
    {
        offsetTime += time_;
    }
    /// <summary>  
    /// 6.计时结束  
    /// </summary>  
    public void Destory()
    {
        isTimer = false;
        isEnd = true;
        if (isDestory)
            Destroy(gameObject);
    }
    /// <summary>
    /// 7.重新开始计时
    /// </summary>
    public void ReStartTimer()
    {
        timeStart = Time_;
        offsetTime = 0;
    }
    /// <summary>
    /// 8.获取当前计时器的剩余时间
    /// </summary>
    /// <returns></returns>
    public float GetLeftTime()
    {
        return Mathf.Clamp(timeTarget - now, 0, timeTarget);
    }
}
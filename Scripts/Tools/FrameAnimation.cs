using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 序列帧动画组建
/// </summary>
public class FrameAnimation : MonoBehaviour {
    /// <summary>
    /// 对象状态
    /// </summary>
    Dictionary<string, string> states = new Dictionary<string, string>();
    /// <summary>
    /// 当前状态
    /// </summary>
    string curState;
    /// <summary>
    /// 时间过去
    /// </summary>
    float timeElasped = 0f;
    /// <summary>
    /// 当前帧
    /// </summary>
    int curFrame = 0;
    /// <summary>
    /// 帧/秒 
    /// </summary>
    float fps;
    /// <summary>
    /// 播放帧精灵数组
    /// </summary>
    Sprite[] sprites;
    /// <summary>
    /// Image
    /// </summary>
    Image img;
    /// <summary>
    /// FrameAnimation
    /// </summary>
    /// <param name="fps">帧/秒</param>
    /// <param name="sprites">播放帧精灵数组</param>
    /// <param name="curFrame">默认从第一帧开始播放</param>
    public FrameAnimation(float fps, Sprite[] sprites, int curFrame = 0)
    {
        img = GetComponent<Image>();
        this.fps = fps;
        this.sprites = sprites;
    }
    /// <summary>
    /// 添加状态
    /// </summary>
    /// <param name="name"></param>
    public void AddState(string name)
    {
        if (states.ContainsKey(name)) return;
        states.Add(name, name);
    }
    void Update()
    {
        timeElasped += Time.deltaTime;
        if(timeElasped >= 1.0 / fps)
        {
            timeElasped = 0;
            curFrame++;
            if (curFrame > sprites.Length)
            {
                curFrame = 0;
            }
            img.sprite = sprites[curFrame];
        }
    }
}
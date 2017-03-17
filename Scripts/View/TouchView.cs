using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 触摸视图模块
    ///触发信息检测：
    ///1.MonoBehaviour.OnTriggerEnter( Collider other )当进入触发器
    ///2.MonoBehaviour.OnTriggerExit( Collider other )当退出触发器
    ///3.MonoBehaviour.OnTriggerStay( Collider other )当逗留触发器
    ///碰撞信息检测：
    ///1.MonoBehaviour.OnCollisionEnter( Collision collisionInfo ) 当进入碰撞器
    ///2.MonoBehaviour.OnCollisionExit( Collision collisionInfo ) 当退出碰撞器
    ///3.MonoBehaviour.OnCollisionStay( Collision collisionInfo )  当逗留碰撞器
/// </summary>
public class TouchView : BaseView
{
    /// <summary>
    /// 存储当前攻击对象
    /// </summary>
    Dictionary<string, GameObject> curAttList = new Dictionary<string, GameObject>();
    Image img;
    protected override void OnAwake()
    {
        base.OnAwake();
        img = GetComponent<Image>();
    }
    /// <summary>
    /// 添加攻击对象
    /// </summary>
    /// <param name="other"></param>
    void AddAttHeroView(GameObject heroGo)
    {
        if (curAttList.ContainsKey(heroGo.name)) return;
        curAttList.Add(heroGo.name, heroGo);
    }
    /// <summary>
    /// 移除攻击对象
    /// </summary>
    /// <param name="other"></param>
    void RemoveAttHeroView(GameObject heroGo)
    {
        if (!curAttList.ContainsKey(heroGo.name)) return;
        curAttList.Remove(heroGo.name);
    }
    /// <summary>
    /// 移除所有攻击对象
    /// </summary>
    void RemoveAllAttHeroView()
    {
        foreach (var pair in curAttList)
        {
            SetLock(pair.Value, false);
        }
        curAttList.Clear();
    }
    /// <summary>
    /// 设置对象锁定
    /// </summary>
    /// <returns></returns>
    void SetLock(GameObject heroGo ,bool isLock)
    {
        Image img = heroGo.GetComponent<Image>();
        if (isLock) 
        {
            img.color = Color.green;
            return;
        }
        img.color = Color.white;
    }
    /// <summary>
    /// 触发进入
    /// </summary>
    /// <param name="other">进入的对象</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Hero")
        {
            SetLock(other.gameObject,true);
            AddAttHeroView(other.gameObject);
        }
    }
    /// <summary>
    /// 触发逗留
    /// </summary>
    /// <param name="other">逗留的对象</param>
    //void OnTriggerStay2D(Collider2D other)
    //{
    //    Dbug.Log(other.name);
    //}
    /// <summary>
    /// 触发离开
    /// </summary>
    /// <param name="other">离开的对象</param>
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Hero")
        {
            SetLock(other.gameObject, false);
            RemoveAttHeroView(other.gameObject);
        }
    }
    void OnDisable()
    {
        RemoveAllAttHeroView();
    }
}

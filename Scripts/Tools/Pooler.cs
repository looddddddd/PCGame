using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pooler : Singleton<Pooler>
{
    /// <summary>
    /// 对象池脚本挂载对象
    /// </summary>
    static GameObject pooler;
    /// <summary>
    /// 对象池存放
    /// </summary>
    static Dictionary<string, GameObject> pools = new Dictionary<string, GameObject>();
    /// <summary>
    /// 预设引用
    /// </summary>
    static Dictionary<string, GameObject> prefabMap = new Dictionary<string, GameObject>();
    /// <summary>
    /// 设置对象池存放节点
    /// </summary>
    /// <param name="poolerGo"></param>
    public static void SetPooler(GameObject poolerGo)
    {
        pooler = poolerGo;
    }
    /// <summary>
    /// 创建对象池
    /// </summary>
    /// <param name="name">对象池名称</param>
    /// <param name="prefab">实例化对象</param>
    /// <param name="num">实例化对象数量</param>
    public static void CreatePool(string name, GameObject prefab, int num = 1)
    {
        if (pools.ContainsKey(name)) 
        {
            Debug.Log( string.Format("已经创建了 {0} 对象池",name));
            return;
        }
        GameObject poolGo = new GameObject(name);
        poolGo.transform.SetParent(pooler.transform);
        pools.Add(name, poolGo);
        prefabMap.Add(name,prefab);
        for (int i = 0; i < num; i++)
        {
            GameObject go = MonoBehaviour.Instantiate(prefab);
            go.transform.SetParent(pools[name].transform);
            go.SetActive(false);
        }
    }
    /// <summary>
    /// 清理某个对象池
    /// </summary>
    /// <param name="name"></param>
    public static void ClearPool(string name)
    {
        if (!pools.ContainsKey(name)) return;
        int length = pools[name].transform.childCount;
        for (int i = 0; i < length; i++) 
        {
            MonoBehaviour.Destroy(pools[name].transform.GetChild(i));
            prefabMap.Remove(name);
        }
        pools.Remove(name);
    }
    /// <summary>
    /// 清理所有对象池
    /// </summary>
    public static void ClearPools()
    {
        foreach (var pair in pools)
        {
            ClearPool(pair.Key);
        }
    }
    /// <summary>
    /// 取得对象
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static GameObject GetPoolObj(string name)
    {
        if (!pools.ContainsKey(name))
        {
            Debug.Log(string.Format("{0}:对象池未创建",name));
            return null;
        }
        GameObject go = pools[name].transform.childCount <= 0 ? MonoBehaviour.Instantiate(prefabMap[name]) : pools[name].transform.GetChild(0).gameObject;
        go.SetActive(true);
        return go;
    }
    /// <summary>
    /// 对象放入对象池
    /// </summary>
    /// <param name="name"></param>
    public static void PutPoolObj(string name, GameObject go)
    {
        if (!pools.ContainsKey(name))
        {
            Debug.Log(string.Format("{0}:对象池未创建", name));
            return;
        }
        go.transform.SetParent(pools[name].transform);
        go.SetActive(false);
    }
    /// <summary>
    /// 对象池是否存在
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static bool PoolsContainsKey(string name)
    {
        return pools.ContainsKey(name);
    }
}

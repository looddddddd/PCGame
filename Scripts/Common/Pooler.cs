using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pooler : MonoBehaviour
{
    #region 实现单例
    private static Pooler instance;
    public static Pooler getInstance
    {
        get { return instance ? instance : new Pooler();}
    }
    #endregion

    /// <summary>
    /// 对象池脚本挂载对象
    /// </summary>
    public GameObject pooler;
    /// <summary>
    /// 对象池存放
    /// </summary>
    Dictionary<string, GameObject> pools = new Dictionary<string, GameObject>();
    /// <summary>
    /// 创建对象池
    /// </summary>
    /// <param name="name">对象池名称</param>
    /// <param name="prefab">实例化对象</param>
    /// <param name="num">实例化对象数量</param>
    public void CreatePool(string name,GameObject prefab,int num = 1)
    {
        if (pools.ContainsKey(name)) 
        {
            Debug.Log( string.Format("已经创建了 {0} 对象池",name));
            return;
        }
        GameObject poolGo = new GameObject(name);
        poolGo.transform.SetParent(pooler.transform);
        pools.Add(name, poolGo);
        for (int i = 0; i < num; i++)
        {
            GameObject go = Instantiate(prefab);
            go.transform.SetParent(pools[name].transform);
            go.SetActive(false);
        }
    }
    /// <summary>
    /// 清理某个对象池
    /// </summary>
    /// <param name="name"></param>
    public void ClearPool(string name)
    { 
        
    }
    /// <summary>
    /// 清理所有对象池
    /// </summary>
    public void ClearPools()
    { 
        
    }
    /// <summary>
    /// 取得对象
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public GameObject GetPoolObj(string name)
    {
        return null;
    }
    /// <summary>
    /// 对象放入对象池
    /// </summary>
    /// <param name="name"></param>
    public void PutPoolObj(string name,GameObject go)
    { 
        
    }
    //    createPool:function(params){
    //    cc.assert(params.prefab, "没有传入对像池的prefab")
    //    if (this.pools[params.name]) return;
    //    cc.log("createPool",params.name,"start");
    //    var mediator = params.mediator || "";
    //    var pool = new cc.NodePool(mediator);
    //    var initCount = params.initCount || 1;
    //    var num = 0;
    //    for (let i = 0; i < initCount; ++i) {
    //        let node = cc.instantiate(params.prefab); // 创建节点
    //        pool.put(node); // 通过 putInPool 接口放入对象池
    //    }
    //    params['pool'] = pool;
    //    this.pools[params['name']] = params;
    //    // cc.log("createPool",params.name,"done")
    //},

    //clearPool:function(name){
    //    cc.log("clearPool", name)
    //    cc.assert(this.pools[name], "该对像池不存在:"+name)
    //    this.pools[name].pool.clear();
    //    delete this.pools[name];
    //},

    /**
     * 从对像池里取出一个对像
     * @param  {[type]} name [description]
     * @return {[type]}      [description]
     */
    //getPoolObj:function(name, params){
    //    cc.assert(this.pools[name], "该对像池不存在:"+name)
    //    if (this.pools[name].pool.size() == 0) { // 通过 size 接口判断对象池中是否有空闲的对象
    //        var obj = cc.instantiate(this.pools[name].prefab);
    //        this.pools[name].pool.put(obj);
    //    }
    //    return this.pools[name].pool.get(params);//参数会传递到指定mediator的reuse事件
    //},

    ///**
    // * 将对像放入对像池
    // * @param  {[type]} name [description]
    // * @param  {[type]} obj  [description]
    // * @return {[type]}      [description]
    // */
    //putPoolObj:function(name, obj){
    //    cc.assert(this.pools[name], "该对像池不存在:"+name)
    //    this.pools[name].pool.put(obj);
    //},
}

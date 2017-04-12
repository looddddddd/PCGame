using UnityEngine;
using System.Collections;
/// <summary>
///  单例模式及常见写法分析
/// http://blog.csdn.net/jiankunking/article/details/50867050
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> where T:new()
{
    private static T instance;
    public static T getInstance
    {
        get
        {
            if(instance == null) instance = new T();
            return instance;
        }
    }
}


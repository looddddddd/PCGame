using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
/// <summary>
/// 所有数据模型基类
/// </summary>
public class BaseModel:Singleton<BaseModel>
{
    /// <summary>
    /// 数据集
    /// </summary>    
    static Dictionary<string,JsonData> jsonMap = new Dictionary<string,JsonData>();
    /// <summary>
    /// 保存数据
    /// </summary>
    public static void Save()
    {

    }
    /// <summary>
    /// 获取数据
    /// </summary>
    public static JsonData Get(string name)
    {
        if(jsonMap.ContainsKey(name)) return jsonMap[name];
        JsonData data = createData(name);
        jsonMap.Add(name,data);
        return data;
    }
    /// <summary>
    /// 生成数据
    /// </summary>    
    static JsonData createData(string name)
    {
        string data = PlayerPrefs.GetString(name);
        if(data == "") data = Resources.Load<TextAsset>("Json/" + name).text;
        return JsonMapper.ToObject(data);
    }
}

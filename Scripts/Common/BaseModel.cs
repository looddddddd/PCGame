using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
/// <summary>
/// 所有数据模型基类--
/// </summary>
public class BaseModel:Singleton<BaseModel>
{
    /// <summary>
    /// 渠道id
    /// </summary>
    protected static int channelId = 1001;
    /// <summary>
    /// 服务id
    /// </summary>
    protected static int serverId = 1;
    /// <summary>
    /// 用户id
    /// </summary>
    protected static int userId = 10;
    /// <summary>
    /// 数据集
    /// </summary>    
    static Dictionary<string,JsonData> jsonMap = new Dictionary<string,JsonData>();

    /// <summary>
    /// 取得单个对象数据
    /// </summary>
    /// <param name="id">数据id</param>
    /// <param name="type">数据类型</param>
    /// <returns></returns>
    protected static JsonData GetData(int id,DataType type)
    {
        string key = string.Format("{0}_{1}_{2}_{3}_{4}", channelId.ToString(), serverId.ToString(),userId.ToString(),type.ToString(),id.ToString());
        string data = PlayerPrefs.GetString(key);
        if (data == "") return null;
        return JsonMapper.ToObject(data);
    }
    /// <summary>
    /// 保存单个对象数据
    /// </summary>
    /// <param name="id">数据id</param>
    /// <param name="type">数据类型</param>
    /// <returns></returns>
    protected static void SaveData(string value, int id, DataType type)
    {
        string key = string.Format("{0}_{1}_{2}_{3}_{4}", channelId.ToString(), serverId.ToString(), userId.ToString(), type.ToString(), id.ToString());
        PlayerPrefs.SetString(key, value);
    }
    /// <summary>
    /// 保存数据
    /// </summary>
    public static void Save()
    {

    }
    /// <summary>
    /// 获取数据
    /// </summary>
    protected static JsonData Get(DataType type)
    {
        string name = type.ToString();
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

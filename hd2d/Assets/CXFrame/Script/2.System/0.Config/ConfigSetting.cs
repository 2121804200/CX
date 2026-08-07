using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

/// <summary>
/// 所有游戏中（非框架）配置，游戏运行时只有一个
/// 包含所有配置文件
/// </summary>
[CreateAssetMenu(fileName = "ConfigSetting", menuName = "CXFrame/Config/ConfigSetting")]
public class ConfigSetting : ConfigBase
{
    //所有配置容器：配置名，<ID,具体配置>
    [DictionaryDrawerSettings(KeyLabel = "类型", ValueLabel = "列表")]
    public Dictionary<string, Dictionary<int, ConfigBase>> configDic;

    /// <summary>
    /// 获取配置
    /// </summary>
    /// <typeparam name="T">配置类型</typeparam>
    /// <param name="configTypeName">配置类型名称</param>
    /// <param name="id">目标配置id</param>
    /// <returns></returns>
    /// <exception cref="System.Exception"></exception>
    public T GetConfig<T>(string configTypeName, int id) where T : ConfigBase
    {
        if (!configDic.ContainsKey(configTypeName))
        {
            throw new System.Exception($"CX:配置中不包含Key:{configTypeName}");
        }
        if (!configDic[configTypeName].ContainsKey(id))
        {
            throw new System.Exception($"CX:配置设置中{configTypeName}不包含这个ID{id}");
        }
        return configDic[configTypeName][id] as T;
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace HRQTextWar.Config
{
    /// <summary>
    /// 配置数据组件
    /// </summary>
    public class ConfigDataComponent : MonoBehaviour
    {

        #region 外部方法

        /// <summary>
        /// 获取配置数据
        /// </summary>
        /// <param name="configDataType">配置数据类型</param>
        /// <param name="configDataID">配置数据ID</param>
        /// <returns></returns>
        public ConfigData GetConfigData(Type configDataType, int configDataID)
        {
            if (m_allConfigDataDictionary.TryGetValue(configDataType, out Dictionary<int, ConfigData> configDataDict))
            {
                if (configDataDict.TryGetValue(configDataID, out ConfigData configData))
                {
                    return configData;
                }
                else
                {
                    Log.Error($"ConfigDataComponent.GetConfigData 未找到该数据 类型:{nameof(configDataType)} ID:{configDataID}");
                    return null;
                }
            }
            else
            {
                Log.Error($"ConfigDataComponent.GetConfigData 未找到该类型数据 类型:{nameof(configDataType)}");
                return null;
            }
        }

        /// <summary>
        /// 获取配置数据
        /// </summary>
        /// <typeparam name="T">配置数据类型</typeparam>
        /// <param name="configDataID">配置数据ID</param>
        /// <returns></returns>
        public ConfigData GetConfigData<T>(int configDataID)
        {
            if (m_allConfigDataDictionary.TryGetValue(typeof(T), out Dictionary<int, ConfigData> configDataDict))
            {
                if (configDataDict.TryGetValue(configDataID, out ConfigData configData))
                {
                    return configData;
                }
                else
                {
                    Log.Error($"ConfigDataComponent.GetConfigData 未找到该数据 类型:{nameof(T)} ID:{configDataID}");
                    return null;
                }
            }
            else
            {
                Log.Error($"ConfigDataComponent.GetConfigData 未找到该类型数据 类型:{nameof(T)}");
                return null;
            }
        }

        /// <summary>
        /// 添加配置数据
        /// </summary>
        /// <returns></returns>
        public bool AddConfigData()
        {
            return false;
        }

        #endregion

        #region 内部字段

        private Dictionary<Type, Dictionary<int, ConfigData>> m_allConfigDataDictionary;

        #endregion

    }

}
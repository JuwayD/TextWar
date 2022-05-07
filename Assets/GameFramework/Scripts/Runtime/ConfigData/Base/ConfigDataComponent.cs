using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace UnityGameFramework.ConfigData
{
    /// <summary>
    /// 配置数据组件
    /// </summary>
    public class ConfigDataComponent : GameFrameworkComponent
    {

        #region 外部方法

        /// <summary>
        /// 获取配置数据字典通过配置数据类型
        /// </summary>
        /// <typeparam name="T">该容器保存的配置数据类型</typeparam>
        /// <returns></returns>
        public Dictionary<int, T> GetConfigDataDictionryByConfigType<T>()
        {
            if (m_configDataContainerDictionary.TryGetValue(typeof(T), out ConfigDataContainer configDataContainer))
            {
                return configDataContainer.GetConfigDataDictionary() as Dictionary<int, T>;
            }
            else
            {
                Log.Error($"ConfigDataComponent.GetConfigDataDictionryByConfigType 不存在该类型的配置数据容器{nameof(T)}");
                return null;
            }
        }

        /// <summary>
        /// 获取配置数据字典通过配置数据类型
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, ConfigData> GetConfigDataDictionryByConfigType(Type type)
        {
            if (m_configDataContainerDictionary.TryGetValue(type, out ConfigDataContainer configDataContainer))
            {
                return configDataContainer.GetConfigDataDictionary();
            }
            else
            {
                Log.Error($"ConfigDataComponent.GetConfigDataDictionryByConfigType 不存在该类型的配置数据容器{nameof(type)}");
                return null;
            }
        }

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
        public T GetConfigData<T>(int configDataID) where T :class
        {
            if (m_allConfigDataDictionary.TryGetValue(typeof(T), out Dictionary<int, ConfigData> configDataDict))
            {
                if (configDataDict.TryGetValue(configDataID, out ConfigData configData))
                {
                    return configData as T;
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
        private bool AddConfigData(Type configDataType, int ID, ConfigData configData)
        {
            if (m_allConfigDataDictionary.ContainsKey(configDataType))
            {
                if (m_allConfigDataDictionary[configDataType].ContainsKey(ID))
                {
                    Log.Error($"ConfigDataComponent.AddConfigData 该类型的此ID已有相应数据 类型:{nameof(configDataType)} ID:{ID}");
                    return false;
                }
                else
                {
                    m_allConfigDataDictionary[configDataType].Add(ID, configData);
                    return true;
                }
            }
            else
            {
                m_allConfigDataDictionary.Add(configDataType, new Dictionary<int, ConfigData>() { { ID, configData } });
                return true;
            }
        }

        /// <summary>
        /// 添加配置数据容器
        /// </summary>
        /// <param name="configDataType">配置数据类型</param>
        /// <param name="configDataContainer">配置数据容器</param>
        /// <returns></returns>
        public bool AddConfigDataContainer(Type configDataType, ConfigDataContainer configDataContainer)
        {
            if (m_configDataContainerDictionary.ContainsKey(configDataType))
            {
                m_configDataContainerDictionary[configDataType].GetConfigDataList().AddRange(configDataContainer.GetConfigDataList());
                foreach (var item in configDataContainer.GetConfigDataDictionary())
                {
                    if (m_allConfigDataDictionary.ContainsKey(configDataType) 
                        && m_allConfigDataDictionary[configDataType].ContainsKey(item.Key))
                    {
                        Debug.LogError($"{configDataType}类型，id{item.Key} 重复出现");
                        continue;
                    }
                    m_allConfigDataDictionary[configDataType][item.Key] = item.Value;
                    m_configDataContainerDictionary[configDataType].GetConfigDataDictionary()[item.Key] = item.Value;
                }
                return false;
            }
            else
            {
                m_configDataContainerDictionary.Add(configDataType, configDataContainer);
                m_allConfigDataDictionary.Add(configDataType, configDataContainer.GetConfigDataDictionary());
                return true;
            }
        }

        #endregion

        #region mono

        protected void Start()
        {
            //加载所有配置数据
            GameEntry.Resource.LoadAsset(m_configDataRootDirectory, new GameFramework.Resource.LoadAssetCallbacks(OnConfigDataLoaded));
        }

        #endregion

        #region 内部函数

        /// <summary>
        /// 配置数据加载完成回调
        /// </summary>
        /// <param name="assetName"></param>
        /// <param name="asset"></param>
        /// <param name="duration"></param>
        /// <param name="userData"></param>
        private void OnConfigDataLoaded(string assetName, object asset, float duration, object userData)
        {
            if (asset is ConfigDataContainerList configDataList)
            {
                foreach (var configDataContainer in configDataList.GetAllConfigDataContainerList())
                {
                    AddConfigDataContainer(configDataContainer.GetConfigDataType(), configDataContainer);
                }
            }
        }

        #endregion

        #region 内部字段

        /// <summary>
        /// 配置数据根目录
        /// </summary>
        [SerializeField]
        [Header("配置数据总表目录")]
        private string m_configDataRootDirectory;

        /// <summary>
        /// 配置数据总字典
        /// </summary>
        private Dictionary<Type, Dictionary<int, ConfigData>> m_allConfigDataDictionary = new Dictionary<Type, Dictionary<int, ConfigData>>();

        /// <summary>
        /// 配置数据容器字典
        /// </summary>
        private Dictionary<Type, ConfigDataContainer> m_configDataContainerDictionary = new Dictionary<Type, ConfigDataContainer>();

        #endregion

    }

}
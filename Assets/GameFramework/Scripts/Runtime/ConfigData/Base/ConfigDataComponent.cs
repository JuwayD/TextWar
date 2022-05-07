using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace UnityGameFramework.ConfigData
{
    /// <summary>
    /// �����������
    /// </summary>
    public class ConfigDataComponent : GameFrameworkComponent
    {

        #region �ⲿ����

        /// <summary>
        /// ��ȡ���������ֵ�ͨ��������������
        /// </summary>
        /// <typeparam name="T">�����������������������</typeparam>
        /// <returns></returns>
        public Dictionary<int, T> GetConfigDataDictionryByConfigType<T>()
        {
            if (m_configDataContainerDictionary.TryGetValue(typeof(T), out ConfigDataContainer configDataContainer))
            {
                return configDataContainer.GetConfigDataDictionary() as Dictionary<int, T>;
            }
            else
            {
                Log.Error($"ConfigDataComponent.GetConfigDataDictionryByConfigType �����ڸ����͵�������������{nameof(T)}");
                return null;
            }
        }

        /// <summary>
        /// ��ȡ���������ֵ�ͨ��������������
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
                Log.Error($"ConfigDataComponent.GetConfigDataDictionryByConfigType �����ڸ����͵�������������{nameof(type)}");
                return null;
            }
        }

        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <param name="configDataType">������������</param>
        /// <param name="configDataID">��������ID</param>
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
                    Log.Error($"ConfigDataComponent.GetConfigData δ�ҵ������� ����:{nameof(configDataType)} ID:{configDataID}");
                    return null;
                }
            }
            else
            {
                Log.Error($"ConfigDataComponent.GetConfigData δ�ҵ����������� ����:{nameof(configDataType)}");
                return null;
            }
        }

        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <typeparam name="T">������������</typeparam>
        /// <param name="configDataID">��������ID</param>
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
                    Log.Error($"ConfigDataComponent.GetConfigData δ�ҵ������� ����:{nameof(T)} ID:{configDataID}");
                    return null;
                }
            }
            else
            {
                Log.Error($"ConfigDataComponent.GetConfigData δ�ҵ����������� ����:{nameof(T)}");
                return null;
            }
        }

        /// <summary>
        /// �����������
        /// </summary>
        /// <returns></returns>
        private bool AddConfigData(Type configDataType, int ID, ConfigData configData)
        {
            if (m_allConfigDataDictionary.ContainsKey(configDataType))
            {
                if (m_allConfigDataDictionary[configDataType].ContainsKey(ID))
                {
                    Log.Error($"ConfigDataComponent.AddConfigData �����͵Ĵ�ID������Ӧ���� ����:{nameof(configDataType)} ID:{ID}");
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
        /// ���������������
        /// </summary>
        /// <param name="configDataType">������������</param>
        /// <param name="configDataContainer">������������</param>
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
                        Debug.LogError($"{configDataType}���ͣ�id{item.Key} �ظ�����");
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
            //����������������
            GameEntry.Resource.LoadAsset(m_configDataRootDirectory, new GameFramework.Resource.LoadAssetCallbacks(OnConfigDataLoaded));
        }

        #endregion

        #region �ڲ�����

        /// <summary>
        /// �������ݼ�����ɻص�
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

        #region �ڲ��ֶ�

        /// <summary>
        /// �������ݸ�Ŀ¼
        /// </summary>
        [SerializeField]
        [Header("���������ܱ�Ŀ¼")]
        private string m_configDataRootDirectory;

        /// <summary>
        /// �����������ֵ�
        /// </summary>
        private Dictionary<Type, Dictionary<int, ConfigData>> m_allConfigDataDictionary = new Dictionary<Type, Dictionary<int, ConfigData>>();

        /// <summary>
        /// �������������ֵ�
        /// </summary>
        private Dictionary<Type, ConfigDataContainer> m_configDataContainerDictionary = new Dictionary<Type, ConfigDataContainer>();

        #endregion

    }

}
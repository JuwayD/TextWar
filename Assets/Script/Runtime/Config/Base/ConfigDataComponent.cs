using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace HRQTextWar.Config
{
    /// <summary>
    /// �����������
    /// </summary>
    public class ConfigDataComponent : MonoBehaviour
    {

        #region �ⲿ����

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
        public bool AddConfigData()
        {
            return false;
        }

        #endregion

        #region �ڲ��ֶ�

        private Dictionary<Type, Dictionary<int, ConfigData>> m_allConfigDataDictionary;

        #endregion

    }

}
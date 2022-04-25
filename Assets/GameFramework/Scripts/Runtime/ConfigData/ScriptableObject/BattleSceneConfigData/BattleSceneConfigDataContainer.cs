using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameFramework.ConfigData
{

    /// <summary>
    /// ��Ϸ������Դ
    /// </summary>
    [CreateAssetMenu(menuName = "ConfigDataContainer/BattleSceneConfigDataContainer", fileName = "BattleSceneConfigDataContainer", order = 1)]
    public class BattleSceneConfigDataContainer : ConfigDataContainer
    {
        /// <summary>
        /// ���ش洢���ݵ��ֵ�
        /// </summary>
        /// <returns></returns>
        public override Dictionary<int, ConfigData> GetConfigDataDictionary()
        {
            var configDataDictionary = new Dictionary<int, ConfigData>();

            foreach (var config in m_configDataDictionary)
            {
                configDataDictionary.Add(config.Key, config.Value);
            }

            return configDataDictionary;
        }

        /// <summary>
        /// ��ȡ������������
        /// </summary>
        /// <returns></returns>
        public override Type GetConfigDataType()
        {
            return typeof(BattleSceneConfigData);
        }

        /// <summary>
        /// ���ش洢�����б�
        /// </summary>
        /// <returns></returns>
        public override  List<ConfigData> GetConfigDataList()
        {
            return new List<ConfigData>(m_configDataList);
        }

        /// <summary>
        /// ���л�ǰ
        /// </summary>
        public override void OnBeforeSerialize()
        {
        }

        /// <summary>
        /// ���л�������ֵ�
        /// </summary>
        public override void OnAfterDeserialize()
        {            
            foreach (var configData in m_configDataList)
            {
                if (!m_configDataDictionary.ContainsKey(configData.Id))
                {
                    m_configDataDictionary.Add(configData.Id, configData);
                }
            }
        }

        #region �ڲ��ֶ�

        /// <summary>
        /// ���������ֵ�
        /// </summary>
        private Dictionary<int, BattleSceneConfigData> m_configDataDictionary = new Dictionary<int, BattleSceneConfigData>();

        /// <summary>
        /// ���������б�
        /// </summary>
        [SerializeField]
        private List<BattleSceneConfigData> m_configDataList = new List<BattleSceneConfigData>();

        #endregion
    }

    /// <summary>
    /// ս��������������
    /// </summary>
    [Serializable]
    public class BattleSceneConfigData:ConfigData
    {
        /// <summary>
        /// ��Դ·��
        /// </summary>
        [SerializeField]
        private string m_assetPath;

        /// <summary>
        /// ս��������Դ·��
        /// </summary>
        public string AssetPath { get => m_assetPath; }
    }

}
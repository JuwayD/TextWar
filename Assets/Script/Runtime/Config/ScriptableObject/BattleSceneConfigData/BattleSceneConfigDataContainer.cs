using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HRQTextWar.Config
{

    /// <summary>
    /// ��Ϸ������Դ
    /// </summary>
    [CreateAssetMenu(menuName = "ConfigDataContainer/BattleSceneConfigDataContainer", fileName = "BattleSceneConfigDataContainer", order = 1)]
    public class BattleSceneConfigDataContainer : ConfigDataContainer
    {
        /// <summary>
        /// ���������ֵ�
        /// </summary>
        private Dictionary<int, ConfigData> m_configDataDictionary = new Dictionary<int, ConfigData>();

        /// <summary>
        /// ���������б�
        /// </summary>
        [SerializeField]
        private List<BattleSceneConfigData> m_configDataList = new List<BattleSceneConfigData>();

        /// <summary>
        /// ���ش洢���ݵ��ֵ�
        /// </summary>
        /// <returns></returns>
        public override Dictionary<int, ConfigData> GetConfigDataDictionary()
        {
            return m_configDataDictionary;
        }

        /// <summary>
        /// ��ȡ������������
        /// </summary>
        /// <returns></returns>
        public override Type GetConfigDataType()
        {
            return typeof(BattleSceneConfigData);
        }
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
    }

}
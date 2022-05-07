using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameFramework.ConfigData
{

    /// <summary>
    /// 游戏配置资源
    /// </summary>
    [CreateAssetMenu(menuName = "ConfigDataContainer/BattleObjectConfigData", fileName = "BattleObjectConfigData", order = 1)]
    public class BattleObjectConfigDataContainer : ConfigDataContainer
    {
        /// <summary>
        /// 返回存储数据的字典
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
        /// 获取配置数据类型
        /// </summary>
        /// <returns></returns>
        public override Type GetConfigDataType()
        {
            return typeof(BattleObjectConfigData);
        }

        /// <summary>
        /// 返回存储数据列表
        /// </summary>
        /// <returns></returns>
        public override List<ConfigData> GetConfigDataList()
        {
            return new List<ConfigData>(m_configDataList);
        }

        /// <summary>
        /// 序列化前
        /// </summary>
        public override void OnBeforeSerialize()
        {
        }

        /// <summary>
        /// 序列化后填充字典
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

        #region 内部字段

        /// <summary>
        /// 配置数据字典
        /// </summary>
        private Dictionary<int, BattleObjectConfigData> m_configDataDictionary = new Dictionary<int, BattleObjectConfigData>();

        /// <summary>
        /// 配置数据列表
        /// </summary>
        [SerializeField]
        private List<BattleObjectConfigData> m_configDataList = new List<BattleObjectConfigData>();

        #endregion
    }

    /// <summary>
    /// 战斗场景配置数据
    /// </summary>
    [Serializable]
    public class BattleObjectConfigData : ConfigData
    {
        /// <summary>
        /// 资源路径
        /// </summary>
        [SerializeField]
        private string m_assetPath;

        /// <summary>
        /// 战斗对象资源路径
        /// </summary>
        public string AssetPath { get => m_assetPath; }
    }

}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HRQTextWar.Config
{

    /// <summary>
    /// 游戏配置资源
    /// </summary>
    [CreateAssetMenu(menuName = "ConfigDataContainer/BattleSceneConfigDataContainer", fileName = "BattleSceneConfigDataContainer", order = 1)]
    public class BattleSceneConfigDataContainer : ConfigDataContainer
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
            return typeof(BattleSceneConfigData);
        }

        /// <summary>
        /// 返回存储数据列表
        /// </summary>
        /// <returns></returns>
        public override  List<ConfigData> GetConfigDataList()
        {
            return new List<ConfigData>(m_configDataList);
        }

        /// <summary>
        /// 生成配置数据字典
        /// </summary>
        public override void GenerateConfigDataDict()
        {
            var configDataDict = m_configDataDictionary;
            foreach (var configData in m_configDataList)
            {
                configDataDict.Add(configData.Id, configData);
            }
        }

        #region 内部字段

        /// <summary>
        /// 配置数据字典
        /// </summary>
        private readonly Dictionary<int, BattleSceneConfigData> m_configDataDictionary = new Dictionary<int, BattleSceneConfigData>();

        /// <summary>
        /// 配置数据列表
        /// </summary>
        [SerializeField]
        private List<BattleSceneConfigData> m_configDataList = new List<BattleSceneConfigData>();

        #endregion
    }

    /// <summary>
    /// 战斗场景配置数据
    /// </summary>
    [Serializable]
    public class BattleSceneConfigData:ConfigData
    {
        /// <summary>
        /// 资源路径
        /// </summary>
        [SerializeField]
        private string m_assetPath;

        /// <summary>
        /// 战斗场景资源路径
        /// </summary>
        public string AssetPath { get => m_assetPath; }
    }

}
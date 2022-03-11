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
        /// 配置数据字典
        /// </summary>
        private Dictionary<int, ConfigData> m_configDataDictionary = new Dictionary<int, ConfigData>();

        /// <summary>
        /// 配置数据列表
        /// </summary>
        [SerializeField]
        private List<BattleSceneConfigData> m_configDataList = new List<BattleSceneConfigData>();

        /// <summary>
        /// 返回存储数据的字典
        /// </summary>
        /// <returns></returns>
        public override Dictionary<int, ConfigData> GetConfigDataDictionary()
        {
            return m_configDataDictionary;
        }

        /// <summary>
        /// 获取配置数据类型
        /// </summary>
        /// <returns></returns>
        public override Type GetConfigDataType()
        {
            return typeof(BattleSceneConfigData);
        }
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
    }

}
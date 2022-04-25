using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameFramework.ConfigData
{
    /// <summary>
    /// 配置数据容器列表
    /// </summary>
    [CreateAssetMenu(menuName = "ConfigDataContainer/ConfigDataContainerList", fileName = "ConfigDataContainerList", order = 1)]
    public class ConfigDataContainerList : ScriptableObject
    {

        #region 外部方法

        /// <summary>
        /// 获取所有配置数据容器列表
        /// </summary>
        /// <returns></returns>
        public List<ConfigDataContainer> GetAllConfigDataContainerList()
        {
            return m_allConfigDataContainerList;
        }

        #endregion

        #region 内部字段

        /// <summary>
        /// 所有的配置数据容器类型
        /// </summary>
        [SerializeField]
        public List<ConfigDataContainer> m_allConfigDataContainerList = new List<ConfigDataContainer>();

        #endregion
    }

}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HRQTextWar.Config
{
    /// <summary>
    /// 配置数据
    /// </summary>
    public abstract class ConfigDataContainer : ScriptableObject
    {
        /// <summary>
        /// 获取配置数据类型
        /// </summary>
        /// <returns></returns>
        public abstract Type GetConfigDataType();

        /// <summary>
        /// 返回存储数据的字典
        /// </summary>
        /// <returns></returns>
        public abstract Dictionary<int, ConfigData> GetConfigDataDictionary();
        
    }

    /// <summary>
    /// 配置数据类型
    /// </summary>
    public abstract class ConfigData
    {
        [SerializeField]
        private int m_id;
    }

}
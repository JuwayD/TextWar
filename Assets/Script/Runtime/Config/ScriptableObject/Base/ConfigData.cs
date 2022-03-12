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

        /// <summary>
        /// 返回存储数据的列表
        /// </summary>
        /// <returns></returns>
        public abstract List<ConfigData> GetConfigDataList();

        /// <summary>
        /// 生成配置数据字典
        /// </summary>
        public abstract void GenerateConfigDataDict();

    }

    /// <summary>
    /// 配置数据类型
    /// </summary>
    [Serializable]
    public abstract class ConfigData
    {
        [SerializeField]
        private int m_id;

        /// <summary>
        /// 除枚举外所有配置数据都有 ID
        /// </summary>
        public int Id { get => m_id; }
    }

}
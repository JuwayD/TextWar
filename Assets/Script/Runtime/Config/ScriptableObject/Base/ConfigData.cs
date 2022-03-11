using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HRQTextWar.Config
{
    /// <summary>
    /// ��������
    /// </summary>
    public abstract class ConfigDataContainer : ScriptableObject
    {
        /// <summary>
        /// ��ȡ������������
        /// </summary>
        /// <returns></returns>
        public abstract Type GetConfigDataType();

        /// <summary>
        /// ���ش洢���ݵ��ֵ�
        /// </summary>
        /// <returns></returns>
        public abstract Dictionary<int, ConfigData> GetConfigDataDictionary();
        
    }

    /// <summary>
    /// ������������
    /// </summary>
    public abstract class ConfigData
    {
        [SerializeField]
        private int m_id;
    }

}
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

        /// <summary>
        /// ���ش洢���ݵ��б�
        /// </summary>
        /// <returns></returns>
        public abstract List<ConfigData> GetConfigDataList();

        /// <summary>
        /// �������������ֵ�
        /// </summary>
        public abstract void GenerateConfigDataDict();

    }

    /// <summary>
    /// ������������
    /// </summary>
    [Serializable]
    public abstract class ConfigData
    {
        [SerializeField]
        private int m_id;

        /// <summary>
        /// ��ö���������������ݶ��� ID
        /// </summary>
        public int Id { get => m_id; }
    }

}
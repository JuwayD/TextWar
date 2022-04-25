using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameFramework.ConfigData
{
    /// <summary>
    /// ��������
    /// </summary>
    [Serializable]
    public abstract class ConfigDataContainer : ScriptableObject, ISerializationCallbackReceiver
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
        /// ���л�ǰ
        /// </summary>
        public abstract void OnBeforeSerialize();

        /// <summary>
        /// ���л���
        /// </summary>
        public abstract void OnAfterDeserialize();
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
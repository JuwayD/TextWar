using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameFramework.ConfigData
{
    /// <summary>
    /// �������������б�
    /// </summary>
    [CreateAssetMenu(menuName = "ConfigDataContainer/ConfigDataContainerList", fileName = "ConfigDataContainerList", order = 1)]
    public class ConfigDataContainerList : ScriptableObject
    {

        #region �ⲿ����

        /// <summary>
        /// ��ȡ�����������������б�
        /// </summary>
        /// <returns></returns>
        public List<ConfigDataContainer> GetAllConfigDataContainerList()
        {
            return m_allConfigDataContainerList;
        }

        #endregion

        #region �ڲ��ֶ�

        /// <summary>
        /// ���е�����������������
        /// </summary>
        [SerializeField]
        public List<ConfigDataContainer> m_allConfigDataContainerList = new List<ConfigDataContainer>();

        #endregion
    }

}
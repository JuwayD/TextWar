using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityGameFramework.Runtime;
using System;
using System.IO;
using UnityGameFramework.ConfigData;

namespace HRQTextWar.Editor.Config
{
    /// <summary>
    /// ������ز���
    /// </summary>
    public class ConfigWindow : EditorWindow
    {
        #region �ⲿ����

        /// <summary>
        /// �����ô���
        /// </summary>
        [MenuItem("EditorTool/OpenConfigTool")]
        public static void OpenConfigTool()
        {
            GetWindow<ConfigWindow>("���ù���");
        }

        #endregion

        #region mono

        private void OnGUI()
        {
            GUILayout.Label("�����������ݸ�Ŀ¼");
            m_configDataDirectory = GUILayout.TextField(m_configDataDirectory);

            if (GUILayout.Button("������������"))
            {
                GenerateConfigData();
            }
        }

        #endregion

        #region �ڲ�����

        /// <summary>
        /// ������������
        /// </summary>
        private void GenerateConfigData()
        {
            //��������Ŀ¼�µ�����asset�ļ��������������������ֵ�
            //todo huangrongqi ����������������ȥ�� ������
            if (!AssetDatabase.IsValidFolder(m_configDataDirectory))
            {
                Debug.LogError("��д��·����������ȷ���Ƿ���д��ȷ");
                return;
            }

            string[] assetPaths = AssetDatabase.FindAssets("t: ConfigDataContainer", new string[] {m_configDataDirectory});


            foreach (var assetPath in assetPaths)
            {
                if (AssetDatabase.LoadAssetAtPath<ConfigDataContainer>(AssetDatabase.GUIDToAssetPath(assetPath)) is ConfigDataContainer configDataContainer)
                {
                    configDataContainer.GenerateConfigDataDict();
                }
            }

            AssetDatabase.SaveAssets();
        }

        #endregion

        #region �ڲ��ֶ�

        /// <summary>
        /// ��������Ŀ¼
        /// </summary>
        private string m_configDataDirectory = "Assets/ConfigData";

        #endregion

    }

}
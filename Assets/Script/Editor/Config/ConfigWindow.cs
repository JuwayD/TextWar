using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityGameFramework.Runtime;
using System;

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
        }

        #endregion
    }

}
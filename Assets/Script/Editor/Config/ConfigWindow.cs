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
    /// 配置相关操作
    /// </summary>
    public class ConfigWindow : EditorWindow
    {
        #region 外部方法

        /// <summary>
        /// 打开配置窗口
        /// </summary>
        [MenuItem("EditorTool/OpenConfigTool")]
        public static void OpenConfigTool()
        {
            GetWindow<ConfigWindow>("配置工具");
        }

        #endregion

        #region mono

        private void OnGUI()
        {
            GUILayout.Label("输入配置数据根目录");
            m_configDataDirectory = GUILayout.TextField(m_configDataDirectory);

            if (GUILayout.Button("生成配置数据"))
            {
                GenerateConfigData();
            }
        }

        #endregion

        #region 内部函数

        /// <summary>
        /// 生成配置数据
        /// </summary>
        private void GenerateConfigData()
        {
            //编译配置目录下的所有asset文件，利用其中数据生成字典
            //todo huangrongqi 后续还会在这边添加去重 外键检查
            if (!AssetDatabase.IsValidFolder(m_configDataDirectory))
            {
                Debug.LogError("填写的路径不存在请确认是否填写正确");
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

        #region 内部字段

        /// <summary>
        /// 配置数据目录
        /// </summary>
        private string m_configDataDirectory = "Assets/ConfigData";

        #endregion

    }

}
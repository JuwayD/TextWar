using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityGameFramework.Runtime;
using System;

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
        }

        #endregion
    }

}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HRQTextWar.Config
{
    /// <summary>
    /// 配置数据组件
    /// </summary>
    public class ConfigDataComponent : MonoBehaviour
    {

        #region 内部字段

        private Dictionary<Type, Dictionary<int, ConfigData>> m_allConfigDataDictionary;

        #endregion

    }

}
using System;
using UnityEngine;
using UnityGameFramework.Runtime;
using GameFramework.Resource;
using System.Collections;
using System.Collections.Generic;

namespace HRQTextWar.Common.Logic
{
    public class UUID
    {
        #region 外部接口

        /// <summary>
        /// 获取类型对应ID
        /// </summary>
        /// <param name="uuidType"></param>
        /// <returns></returns>
        public static int GetNewID(UUIDType uuidType)
        {
            if (m_idType2ID[uuidType] == int.MaxValue)
            {
                m_idType2ID[uuidType] = 0;
                Debug.LogError($"{uuidType} 类型ID 已经达到上限，将归0");
            }
            return m_idType2ID[uuidType]++;
        }

        #endregion

        #region 外部类型

        /// <summary>
        /// uuid类型
        /// </summary>
        public enum UUIDType
        {
            Entity
        }

        #endregion

        /// <summary>
        /// id类型字典
        /// </summary>
        private static Dictionary<UUIDType, int> m_idType2ID = new Dictionary<UUIDType, int>() { { UUIDType.Entity,0} };

    }
}

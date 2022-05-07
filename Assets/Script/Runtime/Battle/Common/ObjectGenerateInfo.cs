using System;
using UnityEngine;

namespace HRQTextWar.Battle.Logic
{
    /// <summary>
    /// 对象生成信息
    /// </summary>
    public struct ObjectGenerateInfo
    {
        /// <summary>
        /// 对象ID
        /// </summary>
        public int m_id;

        /// <summary>
        /// 资源路径
        /// </summary>
        public string m_assetPath;

        /// <summary>
        /// 位置
        /// </summary>
        public Vector3 m_position;

        /// <summary>
        /// 旋转
        /// </summary>
        public Quaternion m_rotation;
    }
}

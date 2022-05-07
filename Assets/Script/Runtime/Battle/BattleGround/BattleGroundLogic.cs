using System;
using UnityEngine;
using UnityGameFramework.Runtime;
using GameFramework.Resource;
using System.Collections;
using HRQTextWar.Common.Logic;
using UnityGameFramework.ConfigData;

namespace HRQTextWar.Battle.Logic
{
    /// <summary>
    /// 战场逻辑组件
    /// </summary>
    public class BattleGroundLogic:EntityLogic
    {
        #region override entity

        /// <summary>
        /// 初始化。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            m_generateComp = GetComponent<ObjectGenerateComp>();
        }

        /// <summary>
        /// 轮询。
        /// </summary>
        /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位。</param>
        /// <param name="realElapseSeconds">真实流逝时间，以秒为单位。</param>
        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            if (m_generateInterval > 0)
            {
                m_generateInterval -= elapseSeconds;
            }
            else
            {
                m_generateInterval = 3;
                m_generateComp.GenerateObject(new ObjectGenerateInfo
                {
                    m_assetPath = GameEntry.ConfigData.GetConfigData<BattleObjectConfigData>(default).AssetPath,
                    m_id = UUID.GetNewID(UUID.UUIDType.Entity),
                    m_position = new Vector3(0,0,m_generateCount),
                    m_rotation = default,
                });
                m_generateCount++;
            }
        }

        #endregion

        #region 内部字段

        /// <summary>
        /// 生成组件
        /// </summary>
        private ObjectGenerateComp m_generateComp;

        /// <summary>
        /// 生成间隔
        /// </summary>
        private float m_generateInterval = 3;

        /// <summary>
        /// 生成计数
        /// </summary>
        private int m_generateCount;

        #endregion
    }
}

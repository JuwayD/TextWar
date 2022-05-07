using GameFramework.Fsm;
using GameFramework.Procedure;
using GameFramework.Resource;
using HRQTextWar.Common.Logic;
using UnityEngine;
using UnityGameFramework.ConfigData;
using UnityGameFramework.Runtime;

namespace HRQTextWar.Battle.Logic
{

    /// <summary>
    /// 战斗流程
    /// </summary>
    public class BattleProcedure : ProcedureBase
    {

        #region override ProcedureBase

        /// <summary>
        /// 战斗流程进入时
        /// </summary>
        /// <param name="procedureOwner"></param>
        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            string scenePath = GameEntry.ConfigData.GetConfigData<BattleSceneConfigData>(default).AssetPath;
            if (GameEntry.Entity.HasEntityGroup(scenePath) || GameEntry.Entity.AddEntityGroup(scenePath,DefaultValueDefine.DefaultInstanceAutoReleaseInterval, 
                DefaultValueDefine.DefaultInstanceCapacity, DefaultValueDefine.DefaultInstanceExpireTime, DefaultValueDefine.DefaultInstancePriority))
            {
                GameEntry.Entity.ShowEntity<BattleGroundLogic>(UUID.GetNewID(UUID.UUIDType.Entity), scenePath, scenePath);
            }
        }

        #endregion

        #region 内部函数

        /// <summary>
        /// 战场加载完成函数
        /// </summary>
        /// <param name="assetName"></param>
        /// <param name="asset"></param>
        /// <param name="duration"></param>
        /// <param name="userData"></param>
        private void OnBattleGroudLoadComplete(string assetName, object asset, float duration, object userData)
        {
        }

        #endregion

        #region 内部字段

        /// <summary>
        /// 战场
        /// </summary>
        private GameObject m_battleGround;

        #endregion

    }

}

using GameFramework.Fsm;
using GameFramework.Procedure;
using GameFramework.Resource;
using System;
using System.Collections;
using System.Collections.Generic;
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
            //加载战斗资源
            GameEntry.Resource.LoadAsset(GameEntry.GetComponent<ConfigDataComponent>().GetConfigData<BattleSceneConfigData>(0).AssetPath
                , new LoadAssetCallbacks(OnBattleGroudLoadComplete, (string assetName, LoadResourceStatus status, string errorMessage, object userData) =>
            {
                Log.Debug("BattleProcedure.OnEnter 加载战场失败，请检查资源");
            }));
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
            m_battleGround = GameObject.Instantiate(asset as GameObject);
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

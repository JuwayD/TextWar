using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Procedure;
using HRQTextWar.Battle.Logic;
using System;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace HRQTextWar.Entrance.Logic
{
    /// <summary>
    /// 入口流程
    /// </summary>
    public class EntranceProcedure : ProcedureBase
    {
        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            GameEntry.Event.Subscribe(LoadConfigSuccessEventArgs.EventId,OnEventLoadConfigSuccess);
            ChangeState<BattleProcedure>(procedureOwner);
            Log.Error("OK 入口流程已经启动");
        }

        #region 内部函数

        /// <summary>
        /// 当加载全局配置完成时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void OnEventLoadConfigSuccess(object sender, GameEventArgs e)
        {
            var eventArgs = e as LoadConfigSuccessEventArgs;
            switch (eventArgs.ConfigAssetName)
            {
                default:
                    break;
            }
        }


        #endregion

    }

}

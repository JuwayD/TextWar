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
    /// �������
    /// </summary>
    public class EntranceProcedure : ProcedureBase
    {
        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            GameEntry.Event.Subscribe(LoadConfigSuccessEventArgs.EventId,OnEventLoadConfigSuccess);
            ChangeState<BattleProcedure>(procedureOwner);
            Log.Error("OK ��������Ѿ�����");
        }

        #region �ڲ�����

        /// <summary>
        /// ������ȫ���������ʱ
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

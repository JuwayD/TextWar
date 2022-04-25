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
    /// ս������
    /// </summary>
    public class BattleProcedure : ProcedureBase
    {

        #region override ProcedureBase

        /// <summary>
        /// ս�����̽���ʱ
        /// </summary>
        /// <param name="procedureOwner"></param>
        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            //����ս����Դ
            GameEntry.Resource.LoadAsset(GameEntry.GetComponent<ConfigDataComponent>().GetConfigData<BattleSceneConfigData>(0).AssetPath
                , new LoadAssetCallbacks(OnBattleGroudLoadComplete, (string assetName, LoadResourceStatus status, string errorMessage, object userData) =>
            {
                Log.Debug("BattleProcedure.OnEnter ����ս��ʧ�ܣ�������Դ");
            }));
        }

        #endregion

        #region �ڲ�����

        /// <summary>
        /// ս��������ɺ���
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

        #region �ڲ��ֶ�

        /// <summary>
        /// ս��
        /// </summary>
        private GameObject m_battleGround;

        #endregion

    }

}

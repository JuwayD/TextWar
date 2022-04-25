using GameFramework.Fsm;
using GameFramework.Procedure;
using HRQTextWar.Battle.Logic;
using UnityGameFramework.Runtime;

namespace HRQTextWar.Launch.Logic
{
    /// <summary>
    /// 入口流程
    /// </summary>
    public class EntranceProcedure : ProcedureBase
    {
        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            ChangeState<BattleProcedure>(procedureOwner);
            Log.Error("OK 入口流程已经启动");
        }

    }

}

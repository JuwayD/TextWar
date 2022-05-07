using System.Collections;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace HRQTextWar.Battle.Logic
{
    /// <summary>
    /// 对象生成组件接口
    /// </summary>
    public interface IObjectGenerateComp
    {
        /// <summary>
        /// 对象生成
        /// </summary>
        /// <param name="objectGenerateInfo"></param>
        /// <returns></returns>
        void GenerateObject(ObjectGenerateInfo objectGenerateInfo);
    }
}

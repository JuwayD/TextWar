using System.Collections;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace HRQTextWar.Battle.Logic
{
    /// <summary>
    /// 对象生成组件
    /// </summary>
    public class ObjectGenerateComp : MonoBehaviour, IObjectGenerateComp
    {
        /// <summary>
        /// 对象生成
        /// </summary>
        /// <param name="objectGenerateInfo"></param>
        /// <returns></returns>
        public void GenerateObject(ObjectGenerateInfo objectGenerateInfo)
        {
            StartCoroutine(nameof(InternalGenerateObject), objectGenerateInfo);
        }

        /// <summary>
        /// 生成对象内部逻辑
        /// </summary>
        /// <param name="objectGenerateInfo"></param>
        /// <returns></returns>
        private IEnumerator InternalGenerateObject(ObjectGenerateInfo objectGenerateInfo)
        {

            if (GameEntry.Entity.HasEntityGroup(objectGenerateInfo.m_assetPath) || GameEntry.Entity.AddEntityGroup(objectGenerateInfo.m_assetPath, DefaultValueDefine.DefaultInstanceAutoReleaseInterval,
                DefaultValueDefine.DefaultInstanceCapacity, DefaultValueDefine.DefaultInstanceExpireTime, DefaultValueDefine.DefaultInstancePriority))
            {
                GameEntry.Entity.ShowEntity<EntityLogic>(objectGenerateInfo.m_id, objectGenerateInfo.m_assetPath, objectGenerateInfo.m_assetPath);
            }
            yield return new WaitWhile(() => GameEntry.Entity.HasEntity(objectGenerateInfo.m_id));
            GameEntry.Entity.GetEntity(objectGenerateInfo.m_id).transform.SetPositionAndRotation(objectGenerateInfo.m_position, objectGenerateInfo.m_rotation);
        }
    }
}

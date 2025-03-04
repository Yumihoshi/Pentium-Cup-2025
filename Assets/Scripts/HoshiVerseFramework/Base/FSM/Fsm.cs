// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/03 19:03
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections.Generic;
using HoshiVerseFramework.Base.FSM.Interfaces;
using UnityEngine;

namespace HoshiVerseFramework.Base.FSM
{
    public class Fsm
    {
        public readonly Dictionary<string, IState> statesDic = new(); // 状态字典
        public IState curState; // 当前状态

        /// <summary>
        /// 添加状态
        /// </summary>
        /// <param name="stateType">状态枚举类型</param>
        /// <param name="state">状态接口</param>
        public void AddState(string stateType, IState state)
        {
            // 如果字典中已经包含该状态，跳过添加
            if (statesDic.TryGetValue(stateType, out IState outState))
            {
                Debug.LogWarning($"无法添加状态，字典中已包含状态{stateType}，跳过添加");
                return;
            }

            statesDic.Add(stateType, state);
        }

        /// <summary>
        /// 切换状态
        /// </summary>
        /// <param name="stateType"></param>
        /// <param name="curExitContext">当前状态退出OnExit传参</param>
        /// <param name="nextCheckContext">下一状态OnCheck传参</param>
        /// <param name="nextEnterContext">下一状态OnEnter传参</param>
        public void SwitchState(string stateType,
            StateContext curExitContext = null,
            StateContext nextCheckContext = null,
            StateContext nextEnterContext = null)
        {
            // 不包含该状态，报错
            if (!statesDic.TryGetValue(stateType, out IState outIState))
            {
                Debug.LogError($"无法切换状态，字典中没有该状态: {stateType}");
                return;
            }

            if (!outIState.OnCheck(nextCheckContext))
            {
                Debug.LogWarning($"无法切换状态，状态检查失败: {stateType}");
                return;
            }

            // 当前状态不为空，退出当前状态
            curState?.OnExit(curExitContext);
            // 切换状态
            curState = outIState;
            curState.OnEnter(nextEnterContext);
        }

        /// <summary>
        /// 删除状态
        /// </summary>
        /// <param name="stateType"></param>
        public void DeleteState(string stateType)
        {
            // 不包含该状态，跳过
            if (!statesDic.TryGetValue(stateType, out IState outIState))
            {
                Debug.LogWarning($"无法删除状态，字典中没有该状态: {stateType}");
                return;
            }

            // 如果当前状态是要删除的状态，先退出当前状态
            if (curState == outIState) curState.OnExit();

            // 删除状态
            statesDic.Remove(stateType);
        }
    }
}

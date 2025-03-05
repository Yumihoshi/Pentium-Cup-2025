// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/03 19:03
// @version: 1.0
// @description:
// *****************************************************************************

using HoshiVerseFramework.Base.FSM.Interfaces;
using UnityEngine;

namespace HoshiVerseFramework.Base.FSM
{
    public abstract class FsmState : MonoBehaviour, IState
    {
        [SerializeField] protected string stateType;

        [SerializeField] protected bool isDefaultState;

        /// <summary>
        /// 状态类型
        /// </summary>
        public string StateType => stateType;

        public bool IsDefaultState => isDefaultState;

        public abstract bool OnCheck(StateContext context = null);
        public abstract void OnEnter(StateContext context = null);
        public abstract void OnUpdate();
        public abstract void OnFixedUpdate();
        public abstract void OnExit(StateContext context = null);
    }
}

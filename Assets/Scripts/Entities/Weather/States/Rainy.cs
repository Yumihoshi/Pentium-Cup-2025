// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/04 21:03
// @version: 1.0
// @description:
// *****************************************************************************

using HoshiVerseFramework.Base.FSM;
using UnityEngine;

namespace Entities.Weather.States
{
    public class Rainy : FsmState
    {
        [SerializeField] private GameObject rain;

        private void Start()
        {
            rain.SetActive(false);
        }

        public override bool OnCheck(StateContext context = null)
        {
            return true;
        }

        public override void OnEnter(StateContext context = null)
        {
            Debug.Log("天气进入雨天");
            rain.SetActive(true);
        }

        public override void OnUpdate()
        {
        }

        public override void OnFixedUpdate()
        {
        }

        public override void OnExit(StateContext context = null)
        {
            Debug.Log("天气退出雨天");
            rain.SetActive(false);
        }
    }
}

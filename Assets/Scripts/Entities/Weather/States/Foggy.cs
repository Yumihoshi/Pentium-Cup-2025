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
    public class Foggy : FsmState
    {
        private Fog _fog;

        private void Start()
        {
            _fog = GameObject.FindWithTag("Fog").GetComponent<Fog>();
        }

        public override bool OnCheck(StateContext context = null)
        {
            return true;
        }

        public override void OnEnter(StateContext context = null)
        {
            Debug.Log("天气进入雾天");
            if (!_fog)
            {
                Debug.LogWarning("找不到雾效果");
                return;
            }

            _fog.ShowFog(true);
        }

        public override void OnUpdate()
        {
        }

        public override void OnFixedUpdate()
        {
        }

        public override void OnExit(StateContext context = null)
        {
            Debug.Log("天气退出雾天");
            if (!_fog)
            {
                Debug.LogWarning("找不到雾效果");
                return;
            }

            _fog.ShowFog(false);
        }
    }
}

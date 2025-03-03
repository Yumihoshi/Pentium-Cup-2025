// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/03 18:03
// @version: 1.0
// @description:
// *****************************************************************************

namespace HoshiVerseFramework.Base.FSM.Interfaces
{
    public interface IState
    {
        public bool OnCheck(StateContext context = null);
        public void OnEnter(StateContext context = null);
        public void OnUpdate();
        public void OnFixedUpdate();
        public void OnExit(StateContext context = null);
    }
}

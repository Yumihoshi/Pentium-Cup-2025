// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/16 15:02
// @version: 1.0
// @description:
// *****************************************************************************

namespace LumiVerseFramework.Base.FSM.Interfaces;

public interface IState
{
    public bool OnCheck(StateContext context = null);
    public void OnEnter(StateContext context = null);
    public void OnProcess();
    public void OnPhysicsProcess();
    public void OnExit(StateContext context = null);
}

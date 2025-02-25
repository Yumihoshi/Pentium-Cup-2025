// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/25 12:02
// @version: 1.0
// @description:
// *****************************************************************************

using Godot;
using LumiVerseFramework.Base.FSM.Interfaces;

namespace LumiVerseFramework.Base.FSM;

public abstract partial class StateNode : Node, IState
{
    /// <summary>
    /// 状态类型
    /// </summary>
    [ExportGroup("FSM状态配置")]
    [Export]
    public string StateType { get; private set; }

    [Export] public bool IsDefaultState { get; private set; }

    public abstract bool OnCheck(StateContext context = null);
    public abstract void OnEnter(StateContext context = null);
    public abstract void OnProcess();
    public abstract void OnPhysicsProcess();
    public abstract void OnExit(StateContext context = null);
}

// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/16 15:02
// @version: 1.0
// @description: 状态机节点基类
// *****************************************************************************

using System;
using Godot;

namespace LumiVerseFramework.Base.FSM;

public abstract partial class FsmNode<TStateType> : Node where TStateType : Enum
{
    public Fsm<TStateType> Fsm { get; } = new();

    public override void _Process(double delta)
    {
        base._Process(delta);
        Fsm.curState.OnProcess();
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        Fsm.curState.OnPhysicsProcess();
    }
}

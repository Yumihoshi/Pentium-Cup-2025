// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/16 15:02
// @version: 1.0
// @description: 状态机节点基类
// *****************************************************************************

using Godot;

namespace LumiVerseFramework.Base.FSM;

public abstract partial class FsmNode : Node
{
    private string _defaultState;
    public Fsm Fsm { get; } = new();

    public override void _Ready()
    {
        base._Ready();
        // 遍历所有子节点，找到所有状态节点
        foreach (Node node in GetChildren())
        {
            // 判断是否为状态节点，如果不是则跳过
            if (node is not StateNode stateNode) continue;
            // 将状态节点添加到状态机中
            Fsm.AddState(stateNode.StateType, stateNode);
            // 如果是默认状态，则切换到该状态
            if (stateNode.IsDefaultState) _defaultState = stateNode.StateType;
        }

        // 切换
        Fsm.SwitchState(_defaultState);
    }

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

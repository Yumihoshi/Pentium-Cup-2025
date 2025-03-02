// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/02 17:03
// @version: 1.0
// @description:
// *****************************************************************************

using Godot;
using PentiumCup2025.Scripts.Entities.Base;

namespace PentiumCup2025.Scripts.Entities;

public partial class WindObj : FlyObj
{
    [ExportGroup("可碰撞风配置")]
    [Export(PropertyHint.Range, "0,1")]
    public float SpeedReduce { get; set; } = 0.3f;

    [Export] public float Duration { get; set; } = 1f;

    private void OnBodyEntered(Node2D body)
    {
        if (body is not CharacterBody2D playerr) return;
        playerr.Velocity *= SpeedReduce;
        GetTree().CreateTimer(Duration).Timeout += () =>
        {
            playerr.Velocity /= SpeedReduce;
        };
        QueueFree();
    }
}

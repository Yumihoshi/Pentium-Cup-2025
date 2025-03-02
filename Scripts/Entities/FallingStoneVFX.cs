// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/02 18:03
// @version: 1.0
// @description:
// *****************************************************************************

using Godot;

namespace PentiumCup2025.Scripts.Entities;

public partial class FallingStoneVFX : GpuParticles2D
{
    public override void _Process(double delta)
    {
        base._Process(delta);
        if (Emitting) return;
        QueueFree();
    }
}

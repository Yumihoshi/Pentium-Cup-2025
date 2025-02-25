// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/25 21:02
// @version: 1.0
// @description:
// *****************************************************************************

using Godot;

namespace PentiumCup2025.Scripts.Entities;

public partial class SpeedUpParticle : GpuParticles2D
{
    private void OnSpeedUpHandler(bool isSpeedUp)
    {
        Emitting = isSpeedUp;
    }
}

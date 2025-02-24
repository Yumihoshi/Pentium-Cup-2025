// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/24 20:02
// @version: 1.0
// @description:
// *****************************************************************************

using Godot;

namespace PentiumCup2025.Scripts.MVC.Models.Weather;

public partial class FallingStoneModel : Resource
{
    [ExportGroup("陨石生成配置")]
    [Export]
    public float MinSpawnInterval { get; set; } = 0.5f;

    [Export] public float MaxSpawnInterval { get; set; } = 1f;
}

// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/25 20:02
// @version: 1.0
// @description:
// *****************************************************************************

using Godot;

namespace PentiumCup2025.Scripts.MVC.Models.Weather;

public partial class RainModel : Resource
{
    [ExportGroup("雨配置")] [Export] public float MinInterval { get; set; } = 3;
    [Export] public float MaxInterval { get; set; } = 5;

    [Export] public float MinDuration { get; set; } = 5;

    [Export] public float MaxDuration { get; set; } = 10;
}

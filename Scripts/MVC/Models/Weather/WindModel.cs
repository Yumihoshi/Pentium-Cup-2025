// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/23 17:02
// @version: 1.0
// @description:
// *****************************************************************************

using Godot;
using PentiumCup2025.Scripts.Interfaces;

namespace PentiumCup2025.Scripts.MVC.Models.Weather;

public partial class WindModel : Resource
{
    [ExportGroup("生成间隔")] [Export] public float MinInterval { get; set; } = 5;
    [Export] public float MaxInterval { get; set; } = 10;

    [ExportGroup("连续生成时间")] [Export] public float MinDuration { get; set; } = 6;
    [Export] public float MaxDuration { get; set; } = 10;

    [ExportGroup("风力")] [Export] public float MinPower { get; set; } = 0.2f;
    [Export] public float MaxPower { get; set; } = 0.5f;
}

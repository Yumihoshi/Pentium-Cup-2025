// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/22 19:02
// @version: 1.0
// @description:
// *****************************************************************************

using Godot;

namespace PentiumCup2025.Scripts.MVC.Models.Player;

public partial class PlayerModel : Resource
{
    /// <summary>
    /// 移动速度
    /// </summary>
    [ExportGroup("玩家属性")]
    [Export]
    public float Speed { get; set; }

    /// <summary>
    /// 转向速度
    /// </summary>
    [Export]
    public float RotateSpeed { get; set; }

    /// <summary>
    /// 加速叠加的速度
    /// </summary>
    [Export]
    public float SpeedUpAddValue { get; set; }
}

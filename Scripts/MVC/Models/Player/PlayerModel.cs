// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/22 19:02
// @version: 1.0
// @description:
// *****************************************************************************

using Godot;
using LumiVerseFramework.Common;

namespace PentiumCup2025.Scripts.MVC.Models.Player;

public partial class PlayerModel : Resource
{
    [ExportGroup("玩家旋转限制（角度制）")]
    [Export]
    public float MinRotationDeg { get; set; } = -75;

    [Export] public float MaxRotationDeg { get; set; } = 75;

    /// <summary>
    /// 移动速度
    /// </summary>
    [ExportGroup("玩家速度")]
    [Export]
    public float Speed { get; set; } = 3000;

    /// <summary>
    /// 转向速度
    /// </summary>
    [Export]
    public float RotateSpeed { get; set; } = 1;

    /// <summary>
    /// 加速后的速度
    /// </summary>
    [Export]
    public float SpeedUpValue { get; set; } = 7500;

    [ExportGroup("玩家血量")] [Export] public int MaxHealth { get; set; } = 100;

    public int CurrentHealth { get; set; }

    [ExportGroup("攻击")]
    [Export]
    public PackedScene Firework { get; private set; }

    /// <summary>
    /// 攻击间隔
    /// </summary>
    [Export]
    public float AttackInterval { get; set; } = 0.3f;

    /// <summary>
    /// 初始化
    /// </summary>
    public void Init()
    {
        CurrentHealth = MaxHealth;
    }

    /// <summary>
    /// 受伤
    /// </summary>
    /// <param name="damage"></param>
    public void Damage(int damage)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, MaxHealth);
        YumihoshiDebug.Print<PlayerModel>("玩家受伤",
            $"受到伤害{damage}，当前血量{CurrentHealth}");
    }

    /// <summary>
    /// 治疗
    /// </summary>
    /// <param name="heal"></param>
    public void Heal(int heal)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + heal, 0, MaxHealth);
        YumihoshiDebug.Print<PlayerModel>("玩家治疗",
            $"受到治疗{heal}，当前血量{CurrentHealth}");
    }
}

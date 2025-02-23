// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/22 22:02
// @version: 1.0
// @description:
// *****************************************************************************

using Godot;
using LumiVerseFramework.Common;
using PentiumCup2025.Scripts.Managers;

namespace PentiumCup2025.Scripts.MVC.Controllers.Player;

public class PlayerAttack
{
    private readonly Node2D _firePoint;
    private readonly PackedScene _firework;
    private readonly CharacterBody2D _player;

    private float _attackCdTimer =
        ModelsManager.Instance.PlayerModelData.AttackInterval;

    public PlayerAttack(PackedScene firework, CharacterBody2D player,
        Node2D firePoint)
    {
        _firework = firework;
        _player = player;
        _firePoint = firePoint;
    }

    /// <summary>
    /// 开火
    /// </summary>
    /// <param name="delta"></param>
    public void HandleFire(double delta)
    {
        // 攻击冷却
        _attackCdTimer -= (float)delta;
        if (_attackCdTimer > 0) return;
        // 攻击按键
        if (!Input.IsActionJustPressed("Attack")) return;
        _attackCdTimer = ModelsManager.Instance.PlayerModelData.AttackInterval;
        // 攻击
        if (_firework.Instantiate() is not Node2D firework)
        {
            YumihoshiDebug.Error<PlayerAttack>("玩家开火失败", "Firework 实例化失败");
            return;
        }

        firework.GlobalPosition = _firePoint.GlobalPosition;
        firework.Rotation = _player.Rotation;
        _player.GetParent().AddChild(firework);
    }
}

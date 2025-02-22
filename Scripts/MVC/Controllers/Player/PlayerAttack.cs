// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/22 22:02
// @version: 1.0
// @description:
// *****************************************************************************

using Godot;
using LumiVerseFramework.Common;

namespace PentiumCup2025.Scripts.MVC.Controllers.Player;

public class PlayerAttack
{
    private readonly PackedScene _firework;
    private readonly CharacterBody2D _player;
    private readonly Node2D _firePoint;

    public PlayerAttack(PackedScene firework, CharacterBody2D player, Node2D firePoint)
    {
        _firework = firework;
        _player = player;
        _firePoint = firePoint;
    }

    /// <summary>
    /// 开火
    /// </summary>
    public void HandleFire()
    {
        if (!Input.IsActionJustPressed("Attack")) return;
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

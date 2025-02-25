// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/24 19:02
// @version: 1.0
// @description:
// *****************************************************************************

using Godot;
using LumiVerseFramework.Common;
using PentiumCup2025.Scripts.Managers;

namespace PentiumCup2025.Scripts.Entities;

public enum FallingStoneDirectionType
{
    Vertical = 1,
    TowardsPlayer
}

public partial class FallingStone : Area2D
{
    private Vector2 _direction = Vector2.Zero;

    private CharacterBody2D _player;
    private Vector2 _targetPos;

    [ExportGroup("陨石属性")]
    [Export]
    public FallingStoneDirectionType Direction { get; set; } =
        FallingStoneDirectionType.Vertical;

    [Export] public float Speed { get; set; } = 50f;
    [Export] public int Damage { get; set; } = 20;

    public override void _Ready()
    {
        base._Ready();
        _player = GetTree().GetNodesInGroup("Player")[0] as CharacterBody2D;
        if (_player == null)
        {
            YumihoshiDebug.Error<FallingStone>("陨石", "未找到玩家");
            return;
        }

        _targetPos = _player.Position;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        switch (Direction)
        {
            case FallingStoneDirectionType.Vertical:
                Position += Vector2.Down * Speed * (float)delta;
                break;
            case FallingStoneDirectionType.TowardsPlayer:
                if (_direction == Vector2.Zero)
                    _direction = Position.DirectionTo(_player.Position)
                        .Normalized();
                Position += _direction * Speed * (float)delta;
                break;
            default:
                YumihoshiDebug.Error<FallingStone>("陨石", "在Process时，未正确设置方向类型");
                return;
        }
    }

    private void OnBodyEntered(Node2D body)
    {
        if (body is not CharacterBody2D player)
            return;
        ModelsManager.Instance.PlayerData.Damage(Damage);
        QueueFree();
    }

    private void OnAreaEntered(Area2D area)
    {
        // 碰到火箭，销毁
        QueueFree();
    }
}

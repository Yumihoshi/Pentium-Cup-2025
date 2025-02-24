// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/24 19:02
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using Godot;
using LumiVerseFramework.Common;
using PentiumCup2025.Scripts.Managers;

namespace PentiumCup2025.Scripts.Entities;

public enum FallingStoneDirectionType
{
    Vertical = 1,
    HorizontalLeft,
    HorizontalRight,
    TowardsPlayer
}

public partial class FallingStone : Area2D
{
    [ExportGroup("陨石属性")] [Export]
    private FallingStoneDirectionType _directionType =
        FallingStoneDirectionType.Vertical;

    [Export] private float _speed = 50f;
    [Export] private int _damage = 20;

    private CharacterBody2D _player;
    private Vector2 _targetPos;
    private Vector2 _direction = Vector2.Zero;

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
        switch (_directionType)
        {
            case FallingStoneDirectionType.Vertical:
                Position += Vector2.Down * _speed * (float)delta;
                break;
            case FallingStoneDirectionType.HorizontalLeft:
                Position += Vector2.Left * _speed * (float)delta;
                break;
            case FallingStoneDirectionType.HorizontalRight:
                Position += Vector2.Right * _speed * (float)delta;
                break;
            case FallingStoneDirectionType.TowardsPlayer:
                if (_direction == Vector2.Zero)
                    _direction = Position.DirectionTo(_player.Position)
                        .Normalized();
                Position += _direction * _speed * (float)delta;
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
        ModelsManager.Instance.PlayerModelData.Damage(_damage);
    }

    private void OnAreaEntered(Area2D area)
    {
        // 碰到火箭，销毁
        QueueFree();
    }
}

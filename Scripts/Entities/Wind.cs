// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/23 17:02
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using Godot;
using LumiVerseFramework.Common;
using PentiumCup2025.Scripts.MVC.Models.Weather;

namespace PentiumCup2025.Scripts.Entities;

public partial class Wind : Node
{
    private WindDirection _direction;
    private float _power;
    private float _duration;
    private SceneTreeTimer _timer;
    private CharacterBody2D _player;
    private bool _isEnabled;

    public override void _Ready()
    {
        base._Ready();
        _player = GetNode<CharacterBody2D>("/root/GameScene/Player");
        // 销毁其他风
        foreach (Node wind in GetTree().GetNodesInGroup("Winds"))
        {
            if (wind is not Wind wind1) continue;
            if (wind1 == this) continue;
            wind1.Disable();
        }

        GetTree().GetNodesInGroup("Winds");
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        if (!_isEnabled) return;
        switch (_direction)
        {
            case WindDirection.Left:
                _player.Rotation -= _power * (float)delta;
                break;
            case WindDirection.Right:
                _player.Rotation += _power * (float)delta;
                break;
            default:
                YumihoshiDebug.Error<Wind>("机制-风",
                    $"启用{_direction.ToString()}风时方向错误");
                return;
        }

        _player.MoveAndSlide();
    }

    public void Init(WindDirection direction, float power, float duration)
    {
        _direction = direction;
        _power = power;
        _duration = duration;
    }

    public void Enable()
    {
        // 延时销毁
        _timer = GetTree().CreateTimer(_duration);
        _timer.Timeout += QueueFree;
        // 开始影响
        _isEnabled = true;
        YumihoshiDebug.Print<Wind>("机制-风",
            $"{_direction.ToString()}风已启用，持续{_duration}秒，强度{_power}");
    }

    public void Disable()
    {
        _isEnabled = false;
        QueueFree();
    }
}

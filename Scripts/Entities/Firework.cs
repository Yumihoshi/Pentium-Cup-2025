// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/22 22:02
// @version: 1.0
// @description:
// *****************************************************************************

using Godot;
using LumiVerseFramework.Common;

namespace PentiumCup2025.Scripts.Entities;

public partial class Firework : Area2D
{
    [ExportGroup("属性")] [Export] private float _lifeTime = 5f;
    [Export] private float _speed = 200f;

    private float _timer;

    public override void _Ready()
    {
        base._Ready();
        _timer = 0;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        // 超时销毁
        _timer += (float)delta;
        if (_timer >= _lifeTime)
        {
            YumihoshiDebug.Print<Firework>("子弹", "子弹超时销毁");
            QueueFree();
        }

        // 子弹飞行
        Position += new Vector2(0, -1).Rotated(Rotation) * _speed *
                    (float)delta;
    }
}

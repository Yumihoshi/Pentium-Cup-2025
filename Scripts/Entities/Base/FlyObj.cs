// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/02 17:03
// @version: 1.0
// @description:
// *****************************************************************************

using Godot;
using LumiVerseFramework.Common;

namespace PentiumCup2025.Scripts.Entities.Base;

public enum FlyObjDirectionType
{
    Vertical = 1,
    TowardsPlayer
}

public partial class FlyObj : Area2D
{
    protected Vector2 direction = Vector2.Zero;

    protected CharacterBody2D player;
    protected Vector2 targetPos;

    [ExportGroup("飞行物属性")]
    [Export]
    public FlyObjDirectionType Direction { get; set; } =
        FlyObjDirectionType.Vertical;

    [Export] public float Speed { get; set; } = 50f;

    public override void _Ready()
    {
        base._Ready();
        player = GetTree().GetNodesInGroup("Player")[0] as CharacterBody2D;
        if (player == null)
        {
            YumihoshiDebug.Error<FlyObj>("飞行物", "未找到玩家");
            return;
        }

        targetPos = player.Position;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        switch (Direction)
        {
            case FlyObjDirectionType.Vertical:
                Position += Vector2.Down * Speed * (float)delta;
                break;
            case FlyObjDirectionType.TowardsPlayer:
                if (direction == Vector2.Zero)
                    direction = Position.DirectionTo(player.Position)
                        .Normalized();
                Position += direction * Speed * (float)delta;
                break;
            default:
                YumihoshiDebug.Error<FlyObj>("飞行物", "在Process时，未正确设置方向类型");
                return;
        }
    }
}

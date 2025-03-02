// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/24 19:02
// @version: 1.0
// @description:
// *****************************************************************************

using Godot;
using PentiumCup2025.Scripts.Entities.Base;
using PentiumCup2025.Scripts.Managers;

namespace PentiumCup2025.Scripts.Entities;

public partial class FallingStone : FlyObj
{
    [Export] public int Damage { get; set; } = 20;

    private void OnBodyEntered(Node2D body)
    {
        if (body is not CharacterBody2D playerr)
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

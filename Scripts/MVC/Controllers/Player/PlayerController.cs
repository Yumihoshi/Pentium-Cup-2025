// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/22 19:02
// @version: 1.0
// @description:
// *****************************************************************************

using Godot;
using PentiumCup2025.Scripts.Managers;

namespace PentiumCup2025.Scripts.MVC.Controllers.Player;

public partial class PlayerController : Node
{
    [Export] private Node2D _firePoint;
    [ExportGroup("节点依赖")] [Export] private CharacterBody2D _player;
    private PlayerAttack _playerAttack;

    public PlayerMove PlayerMoveHandler { get; private set; }

    public override void _Ready()
    {
        base._Ready();
        PlayerMoveHandler = new PlayerMove(_player);
        _playerAttack =
            new PlayerAttack(ModelsManager.Instance.PlayerModelData.Firework,
                _player, _firePoint);
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        // 移动
        PlayerMoveHandler.HandleInput();
        PlayerMoveHandler.HandleRotate(delta);
        PlayerMoveHandler.HandleSpeedUp();
        // 攻击
        _playerAttack.HandleFire(delta);
    }
}

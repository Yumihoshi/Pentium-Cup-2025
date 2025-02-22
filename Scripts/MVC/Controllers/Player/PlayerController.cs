// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/22 19:02
// @version: 1.0
// @description:
// *****************************************************************************

using Godot;
using LumiVerseFramework.Common;
using PentiumCup2025.Scripts.Managers;

namespace PentiumCup2025.Scripts.MVC.Controllers.Player;

public partial class PlayerController : Node
{
    private Vector2 _inputDirection = Vector2.Zero;
    [ExportGroup("节点依赖")] [Export] private CharacterBody2D _player;

    public override void _Process(double delta)
    {
        base._Process(delta);
        HandleInput();
        HandleRotate(delta);
        HandleSpeedUp();
    }

    /// <summary>
    /// 处理输入
    /// </summary>
    private void HandleInput()
    {
        // 切换全屏
        if (Input.IsActionJustPressed("SwitchFullscreen"))
            YumihoshiFullScreen.SwitchFullScreenAuto();
        // 转向
        if (Input.IsActionJustPressed("RotateLeft")) _inputDirection.X = -1;
        else if (Input.IsActionJustReleased("RotateLeft"))
            _inputDirection.X = 0;
        else if (Input.IsActionJustPressed("RotateRight"))
            _inputDirection.X = 1;
        else if (Input.IsActionJustReleased("RotateRight"))
            _inputDirection.X = 0;
    }

    /// <summary>
    /// 处理转向
    /// </summary>
    /// <param name="delta"></param>
    private void HandleRotate(double delta)
    {
        if (_inputDirection.X > 0)
            _player.Rotation +=
                ModelsManager.Instance.PlayerModelData.RotateSpeed *
                (float)delta;
        else if (_inputDirection.X < 0)
            _player.Rotation -=
                ModelsManager.Instance.PlayerModelData.RotateSpeed *
                (float)delta;

        Vector2 direction = new Vector2(0, -1).Rotated(_player.Rotation);
        YumihoshiDebug.Print<PlayerController>("玩家",
            $"当前方向{direction}");
        _player.Velocity = direction *
                           ModelsManager.Instance.PlayerModelData.Speed *
                           (float)delta;
        _player.MoveAndSlide();
    }

    /// <summary>
    /// 处理加速
    /// </summary>
    private void HandleSpeedUp()
    {
        if (Input.IsActionJustPressed("SpeedUp"))
            ModelsManager.Instance.PlayerModelData.Speed +=
                ModelsManager.Instance.PlayerModelData.SpeedUpAddValue;
        else if (Input.IsActionJustReleased("SpeedUp"))
            ModelsManager.Instance.PlayerModelData.Speed -=
                ModelsManager.Instance.PlayerModelData.SpeedUpAddValue;
    }
}

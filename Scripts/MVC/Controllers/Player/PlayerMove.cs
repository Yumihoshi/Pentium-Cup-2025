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

public class PlayerMove
{
    private Vector2 _inputDirection = Vector2.Zero;
    private readonly CharacterBody2D _player;

    public PlayerMove(CharacterBody2D player)
    {
        _player = player;
    }

    /// <summary>
    /// 处理输入
    /// </summary>
    public void HandleInput()
    {
        // 切换全屏
        if (Input.IsActionJustPressed("SwitchFullscreen"))
            YumihoshiFullScreen.SwitchFullScreenAuto();
        // 转向
        _inputDirection.X = Input.GetAxis("RotateLeft", "RotateRight");
    }

    /// <summary>
    /// 处理转向
    /// </summary>
    /// <param name="delta"></param>
    public void HandleRotate(double delta)
    {
        if (_inputDirection.X > 0)
            _player.Rotation =
                Mathf.Clamp(
                    _player.Rotation +
                    ModelsManager.Instance.PlayerModelData.RotateSpeed *
                    (float)delta, Mathf.DegToRad(-75), Mathf.DegToRad(75));
        else if (_inputDirection.X < 0)
            _player.Rotation =
                Mathf.Clamp(
                    _player.Rotation -
                    ModelsManager.Instance.PlayerModelData.RotateSpeed *
                    (float)delta, Mathf.DegToRad(-75), Mathf.DegToRad(75));

        Vector2 direction = new Vector2(0, -1).Rotated(_player.Rotation);
        _player.Velocity = direction *
                           ModelsManager.Instance.PlayerModelData.Speed *
                           (float)delta;
        _player.MoveAndSlide();
    }

    /// <summary>
    /// 处理加速
    /// </summary>
    public void HandleSpeedUp()
    {
        if (Input.IsActionJustPressed("SpeedUp"))
            ModelsManager.Instance.PlayerModelData.Speed +=
                ModelsManager.Instance.PlayerModelData.SpeedUpAddValue;
        else if (Input.IsActionJustReleased("SpeedUp"))
            ModelsManager.Instance.PlayerModelData.Speed -=
                ModelsManager.Instance.PlayerModelData.SpeedUpAddValue;
    }
}

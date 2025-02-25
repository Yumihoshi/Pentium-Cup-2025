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

public partial class PlayerMove : Node
{
    [Signal]
    public delegate void OnSpeedUpEventHandler(bool isSpeedUp);

    private Vector2 _inputDirection = Vector2.Zero;

    [ExportGroup("节点依赖")] [Export] private CharacterBody2D _player;

    public override void _Process(double delta)
    {
        base._Process(delta);
        // 移动
        HandleInput();
        HandleRotate(delta);
        bool tag = GetSpeedUp();
        ApplyMove(delta, tag);
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
        _inputDirection.X = Input.GetAxis("RotateLeft", "RotateRight");
    }

    /// <summary>
    /// 处理转向
    /// </summary>
    /// <param name="delta"></param>
    private void HandleRotate(double delta)
    {
        // 处理转向
        if (_inputDirection.X > 0)
            AddRotation(ModelsManager.Instance.PlayerData.RotateSpeed *
                        (float)delta);
        else if (_inputDirection.X < 0)
            ReduceRotation(ModelsManager.Instance.PlayerData.RotateSpeed *
                           (float)delta);
    }

    /// <summary>
    /// 处理加速
    /// </summary>
    private bool GetSpeedUp()
    {
        if (Input.IsActionJustPressed("SpeedUp"))
        {
            EmitSignal(SignalName.OnSpeedUp, true);
            return true;
        }

        if (Input.IsActionPressed("SpeedUp"))
            return true;

        if (Input.IsActionJustReleased("SpeedUp"))
        {
            EmitSignal(SignalName.OnSpeedUp, false);
            return false;
        }

        return false;
    }

    /// <summary>
    /// 应用移动
    /// </summary>
    private void ApplyMove(double delta, bool isSpeedUp)
    {
        // 获取当前朝向
        Vector2 direction = new Vector2(0, -1).Rotated(_player.Rotation);
        // 应用转向和速度
        if (!isSpeedUp)
            _player.Velocity = direction *
                               ModelsManager.Instance.PlayerData.Speed *
                               (float)delta;
        else
            _player.Velocity = direction *
                               ModelsManager.Instance.PlayerData
                                   .SpeedUpValue *
                               (float)delta;
        _player.Velocity = new Vector2(_player.Velocity.X, 0);
        _player.MoveAndSlide();
    }

    /// <summary>
    /// 添加旋转（逆时针）
    /// </summary>
    /// <param name="rotationRad">弧度制旋转</param>
    public void AddRotation(float rotationRad)
    {
        _player.Rotation = Mathf.Clamp(
            _player.Rotation + rotationRad,
            Mathf.DegToRad(
                ModelsManager.Instance.PlayerData.MinRotationDeg),
            Mathf.DegToRad(
                ModelsManager.Instance.PlayerData.MaxRotationDeg));
    }

    /// <summary>
    /// 减少旋转（顺时针）
    /// </summary>
    /// <param name="rotationRad">弧度制旋转</param>
    public void ReduceRotation(float rotationRad)
    {
        _player.Rotation = Mathf.Clamp(
            _player.Rotation - rotationRad,
            Mathf.DegToRad(
                ModelsManager.Instance.PlayerData.MinRotationDeg),
            Mathf.DegToRad(
                ModelsManager.Instance.PlayerData.MaxRotationDeg));
    }
}

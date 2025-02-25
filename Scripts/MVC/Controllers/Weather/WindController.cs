// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/23 17:02
// @version: 1.0
// @description:
// *****************************************************************************

using Godot;
using LumiVerseFramework.Common;
using PentiumCup2025.Scripts.Entities;
using PentiumCup2025.Scripts.Interfaces;
using PentiumCup2025.Scripts.Managers;
using PentiumCup2025.Scripts.MVC.Models.Weather;

namespace PentiumCup2025.Scripts.MVC.Controllers.Weather;

public class WindController : IWeather
{
    private readonly WindDirection _direction;
    private readonly float _duration;
    private readonly float _power;

    public WindController()
    {
        _duration = GetRandomDuration();
        _power = GetRandomPower();
        _direction = GetRandomDirection();
    }

    public void Generate(Node parent)
    {
        Wind wind = (Wind)parent.GetTree().GetNodesInGroup("Winds")[0];
        wind.Init(_direction, _power, _duration);
        wind.Enable();
    }

    /// <summary>
    /// 获取间隔
    /// </summary>
    /// <returns></returns>
    public float GetInterval()
    {
        return YumihoshiRandom.GetRandomFloat(
            ModelsManager.Instance.WindData.MinInterval,
            ModelsManager.Instance.WindData.MaxInterval);
    }

    public float GetDuration()
    {
        return _duration;
    }

    /// <summary>
    /// 随机生成一个风向
    /// </summary>
    /// <returns></returns>
    private WindDirection GetRandomDirection()
    {
        return (WindDirection)YumihoshiRandom.GetRandomInt(1, 3);
    }

    /// <summary>
    /// 随机生成一个持续时间
    /// </summary>
    /// <returns></returns>
    private float GetRandomDuration()
    {
        return YumihoshiRandom.GetRandomFloat(
            ModelsManager.Instance.WindData.MinDuration,
            ModelsManager.Instance.WindData.MaxDuration);
    }

    /// <summary>
    /// 随机生成一个风力
    /// </summary>
    /// <returns></returns>
    private float GetRandomPower()
    {
        return YumihoshiRandom.GetRandomFloat(
            ModelsManager.Instance.WindData.MinPower,
            ModelsManager.Instance.WindData.MaxPower);
    }
}

// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/23 17:02
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using Godot;
using PentiumCup2025.Scripts.Commons;
using PentiumCup2025.Scripts.Entities;
using PentiumCup2025.Scripts.Interfaces;
using PentiumCup2025.Scripts.Managers;
using PentiumCup2025.Scripts.MVC.Models.Weather;

namespace PentiumCup2025.Scripts.MVC.Controllers.Weather;

public class WindController : IWeather
{
    public void Generate(Node parent)
    {
        PackedScene windScene =
            GD.Load<PackedScene>("res://Scenes/Weather/Wind.tscn");
        Wind wind = windScene.Instantiate<Wind>();
        wind.Init(GetRandomDirection(), GetRandomPower(), GetRandomDuration());
        parent.AddChild(wind);
        wind.Enable();
    }

    /// <summary>
    /// 获取间隔
    /// </summary>
    /// <returns></returns>
    public float GetInterval()
    {
        return Common.GetRandomFloat(
            ModelsManager.Instance.WindModelData.MinInterval,
            ModelsManager.Instance.WindModelData.MaxInterval);
    }

    /// <summary>
    /// 随机生成一个风向
    /// </summary>
    /// <returns></returns>
    private WindDirection GetRandomDirection()
    {
        return (WindDirection)Common.GetRandomInt(1, 3);
    }

    /// <summary>
    /// 随机生成一个持续时间
    /// </summary>
    /// <returns></returns>
    private float GetRandomDuration()
    {
        return Common.GetRandomFloat(
            ModelsManager.Instance.WindModelData.MinDuration,
            ModelsManager.Instance.WindModelData.MaxDuration);
    }

    /// <summary>
    /// 随机生成一个风力
    /// </summary>
    /// <returns></returns>
    private float GetRandomPower()
    {
        return Common.GetRandomFloat(
            ModelsManager.Instance.WindModelData.MinPower,
            ModelsManager.Instance.WindModelData.MaxPower);
    }
}

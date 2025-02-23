// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/23 17:02
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using LumiVerseFramework.Common;
using PentiumCup2025.Scripts.Commons;
using PentiumCup2025.Scripts.Interfaces;
using PentiumCup2025.Scripts.Managers;
using PentiumCup2025.Scripts.MVC.Models.Weather;

namespace PentiumCup2025.Scripts.MVC.Controllers.Weather;

public class WeatherFactory
{
    private readonly Random random = new();

    /// <summary>
    /// 创建天气
    /// </summary>
    /// <param name="weatherType"></param>
    /// <returns></returns>
    public IWeather GenerateWeather(WeatherType weatherType)
    {
        switch (weatherType)
        {
            // TODO: 天气工厂实现其他天气
            case WeatherType.Wind:
                return new WindController();
            case WeatherType.Sunny:
                return null;
            case WeatherType.Rain:
                return null;
            case WeatherType.Thunder:
                return null;
            case WeatherType.Fog:
                return null;
            case WeatherType.FallingStone:
                return null;
            default:
                YumihoshiDebug.Error<WeatherFactory>("天气工厂", "天气类型不存在");
                return null;
        }
    }

    /// <summary>
    /// 随机生成一个风生成间隔
    /// </summary>
    /// <returns></returns>
    public float GetRandomWindGenerateInterval()
    {
        return Common.GetRandomFloat(
            ModelsManager.Instance.WindModelData.MinInterval,
            ModelsManager.Instance.WindModelData.MaxInterval);
    }

    /// <summary>
    /// 随机获取天气
    /// </summary>
    /// <returns></returns>
    public WeatherType GetRandomWeatherType()
    {
        return (WeatherType)random.Next(1, 7);
    }
}

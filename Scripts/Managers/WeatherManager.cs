// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/23 17:02
// @version: 1.0
// @description:
// *****************************************************************************

using LumiVerseFramework.Base;
using PentiumCup2025.Scripts.MVC.Controllers.Weather;
using PentiumCup2025.Scripts.MVC.Models.Weather;

namespace PentiumCup2025.Scripts.Managers;

public partial class WeatherManager : Singleton<WeatherManager>
{
    private WeatherFactory _weatherFactory;

    public override async void _Ready()
    {
        base._Ready();
        _weatherFactory = new WeatherFactory();
        while (true)
        {
            _weatherFactory.GenerateWeather(WeatherType.Wind)
                .Generate(GetNode("/root/GameScene"));
            await ToSignal(
                GetTree()
                    .CreateTimer(
                        _weatherFactory.GetRandomWindGenerateInterval()),
                "timeout");
        }
    }
}

// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/03 21:03
// @version: 1.0
// @description:
// *****************************************************************************

using HoshiVerseFramework.Base;
using MVC.Models.FlyObj;
using MVC.Models.Player;
using MVC.Models.Weather;
using UnityEngine;

namespace Managers
{
    public class ModelsManager : Singleton<ModelsManager>
    {
        public PlayerConfig PlayerData { get; private set; }
        public FlyObjConfig FlyObjData { get; private set; }
        public WeatherConfig WeatherData { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            PlayerData = Resources.Load<PlayerConfig>("Configs/Player Config");
            FlyObjData =
                Resources.Load<FlyObjConfig>("Configs/Fly Object Config");
            WeatherData =
                Resources.Load<WeatherConfig>("Configs/Weather Config");
        }
    }
}

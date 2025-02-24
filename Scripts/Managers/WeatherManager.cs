// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/23 17:02
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Godot;
using LumiVerseFramework.Base;
using LumiVerseFramework.Common;
using PentiumCup2025.Scripts.MVC.Controllers.Weather;
using PentiumCup2025.Scripts.MVC.Models.Weather;

namespace PentiumCup2025.Scripts.Managers;

public partial class WeatherManager : Singleton<WeatherManager>
{
    private WeatherFactory _weatherFactory;

    public ObservableCollection<WeatherType> WeatherList { get; private set; } =
        new();

    [Signal]
    public delegate void WeatherListAddedEventHandler(WeatherType newWeather);

    [Signal]
    public delegate void WeatherListRemovedEventHandler(WeatherType oldWeather);

    [Signal]
    public delegate void WeatherListResetEventHandler();

    public override void _EnterTree()
    {
        base._EnterTree();
        // 注册天气列表变化事件
        WeatherList.CollectionChanged += OnWeatherListChanged;
    }

    public override async void _Ready()
    {
        base._Ready();
        _weatherFactory = new WeatherFactory();
        while (true)
        {
            _weatherFactory.GenerateWeather(WeatherType.Wind)
                .Generate(GetNode("/root/GameScene"));
            WeatherList.Add(WeatherType.Wind);
            await ToSignal(
                GetTree()
                    .CreateTimer(
                        _weatherFactory.GetRandomWindGenerateInterval()),
                "timeout");
        }
    }

    public override void _ExitTree()
    {
        base._ExitTree();
        // 取消注册天气列表变化事件
        WeatherList.CollectionChanged -= OnWeatherListChanged;
    }

    /// <summary>
    /// 天气列表变化时调用
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    private void OnWeatherListChanged(object sender,
        NotifyCollectionChangedEventArgs args)
    {
        switch (args.Action)
        {
            case NotifyCollectionChangedAction.Add:
                if (args.NewItems is null) return;
                // 发送天气添加的信号
                foreach (WeatherType weatherType in args.NewItems)
                {
                    EmitSignal(SignalName.WeatherListAdded, (int)weatherType);
                }

                break;
            case NotifyCollectionChangedAction.Remove:
                if (args.OldItems is null) return;
                // 发送天气删除的信号
                foreach (WeatherType weatherType in args.OldItems)
                {
                    EmitSignal(SignalName.WeatherListRemoved, (int)weatherType);
                }
                break;
            case NotifyCollectionChangedAction.Reset:
                // 发送天气重置的信号
                EmitSignal(SignalName.WeatherListReset);
                break;
            // 其他情况不处理
            case NotifyCollectionChangedAction.Replace:
            case NotifyCollectionChangedAction.Move:
                return;
            default:
                YumihoshiDebug.Error<WeatherManager>("天气管理器单例", "未知的天气列表变化类型");
                return;
        }
    }
}

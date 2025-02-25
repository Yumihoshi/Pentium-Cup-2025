// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/23 17:02
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Godot;
using LumiVerseFramework.Base;
using LumiVerseFramework.Common;
using PentiumCup2025.Scripts.Interfaces;
using PentiumCup2025.Scripts.MVC.Controllers.Weather;
using PentiumCup2025.Scripts.MVC.Models.Weather;

namespace PentiumCup2025.Scripts.Managers;

public partial class WeatherManager : Singleton<WeatherManager>
{
    [Signal]
    public delegate void EnableGenerateWeatherChangedEventHandler(bool status);

    [Signal]
    public delegate void WeatherListAddedEventHandler(WeatherType newWeather);

    [Signal]
    public delegate void WeatherListRemovedEventHandler(WeatherType oldWeather);

    [Signal]
    public delegate void WeatherListResetEventHandler();

    private bool _enableGenerateWeather = true;
    private float _interval;
    private float _timer;

    private WeatherFactory _weatherFactory;

    public bool EnableGenerateWeather
    {
        get => _enableGenerateWeather;
        set
        {
            if (value == _enableGenerateWeather) return;
            _enableGenerateWeather = value;
            EmitSignal(SignalName.EnableGenerateWeatherChanged,
                _enableGenerateWeather);
        }
    }

    public ObservableCollection<WeatherType> WeatherList { get; } =
        new();

    public override void _EnterTree()
    {
        base._EnterTree();
        // 注册天气列表变化事件
        WeatherList.CollectionChanged += OnWeatherListChanged;
    }

    public override void _Ready()
    {
        base._Ready();
        _weatherFactory = new WeatherFactory();
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        if (!EnableGenerateWeather) return;
        _timer += (float)delta;
        if (_timer < _interval) return;
        // 生成新的天气
        WeatherType newWeatherType = GetRandomWeatherType();
        IWeather newWeather =
            _weatherFactory.GenerateWeather(newWeatherType);
        newWeather.Generate(GetNode("/root/GameScene"));
        WeatherList.Add(newWeatherType);
        // 更新计时器
        _interval = newWeather.GetInterval();
        _timer = 0;
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
                    EmitSignal(SignalName.WeatherListAdded, (int)weatherType);

                break;
            case NotifyCollectionChangedAction.Remove:
                if (args.OldItems is null) return;
                // 发送天气删除的信号
                foreach (WeatherType weatherType in args.OldItems)
                    EmitSignal(SignalName.WeatherListRemoved, (int)weatherType);

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

    /// <summary>
    /// 随机获取天气
    /// </summary>
    /// <returns></returns>
    public WeatherType GetRandomWeatherType()
    {
        // TODO: 待改回来
        // return (WeatherType)Common.GetRandomInt(1, 7);
        return (WeatherType)YumihoshiRandom.GetRandomInt(1, 3);
    }
}

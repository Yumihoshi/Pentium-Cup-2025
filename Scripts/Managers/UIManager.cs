using Godot;
using LumiVerseFramework.Base;
using PentiumCup2025.Scripts.MVC.Models.Weather;

namespace PentiumCup2025.Scripts.Managers;

public partial class UIManager : Singleton<UIManager>
{
    private Label _windLabel;

    public override void _Ready()
    {
        base._Ready();
        _windLabel = GetNode<Label>("/root/GameScene/UI/WindLabel");
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        _windLabel.Text = "当前天气\n";
        foreach (WeatherType weather in WeatherManager.Instance.WeatherList)
        {
            if (weather == WeatherType.FallingStone) continue;
            _windLabel.Text += weather + "\n";
        }
    }
}

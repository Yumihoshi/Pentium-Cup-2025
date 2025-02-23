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

    public void UpdateWindLabel(WindDirection direction, float power,
        float duration)
    {
        _windLabel.Text =
            $"当前\n风向：{direction.ToString()}\n风力：{power}\n持续时间：{duration:F2}";
    }
}

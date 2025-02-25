// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/25 20:02
// @version: 1.0
// @description:
// *****************************************************************************

using Godot;
using LumiVerseFramework.Common;
using PentiumCup2025.Scripts.Interfaces;
using PentiumCup2025.Scripts.Managers;

namespace PentiumCup2025.Scripts.MVC.Controllers.Weather;

public class RainController : IWeather
{
    private readonly float _duration;
    private readonly float _interval;

    public RainController()
    {
        _interval = YumihoshiRandom.GetRandomFloat(
            ModelsManager.Instance.RainData.MinInterval,
            ModelsManager.Instance.RainData.MaxInterval);
        _duration = YumihoshiRandom.GetRandomFloat(
            ModelsManager.Instance.RainData.MinDuration,
            ModelsManager.Instance.RainData.MaxDuration);
        _interval += _duration;
    }

    public void Generate(Node parent)
    {
        YumihoshiDebug.Print<RainController>("雨", "生成雨");
        parent.GetNode<GpuParticles2D>("%Rain").Emitting = true;
        parent.GetTree().CreateTimer(_duration).Timeout += () =>
        {
            parent.GetNode<GpuParticles2D>("%Rain").Emitting = false;
        };
    }

    public float GetInterval()
    {
        return _interval;
    }

    public float GetDuration()
    {
        return _duration;
    }
}

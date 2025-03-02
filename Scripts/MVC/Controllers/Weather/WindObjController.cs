// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/02 17:03
// @version: 1.0
// @description:
// *****************************************************************************

using Godot;
using LumiVerseFramework.Common;
using PentiumCup2025.Scripts.Commons;
using PentiumCup2025.Scripts.Entities;
using PentiumCup2025.Scripts.Interfaces;

namespace PentiumCup2025.Scripts.MVC.Controllers.Weather;

public class WindObjController : IWeather
{
    private WindObj _windObj;

    public void Generate(Node parent)
    {
        PackedScene windObjScene =
            GD.Load<PackedScene>("res://Prefabs/Weather/WindObj.tscn");
        _windObj = windObjScene.Instantiate<WindObj>();
        _windObj.Direction = Common.GetRandomDirection();
        Vector2 screenSize = parent.GetViewport().GetVisibleRect().Size;
        Vector2 randomPos = Common
            .GetRandomScreenTopPos(screenSize);
        randomPos = YumihoshiConvert.ConvertScreenToWorld(randomPos, parent);
        _windObj.Position = randomPos;
        YumihoshiDebug.Print<FallingStoneController>("可碰撞风生成",
            "位置：" + _windObj.Position);
        parent.AddChild(_windObj);
    }

    public float GetInterval()
    {
        return GetDuration();
    }

    public float GetDuration()
    {
        return _windObj.Duration;
    }
}

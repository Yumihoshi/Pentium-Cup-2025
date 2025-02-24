// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/24 20:02
// @version: 1.0
// @description:
// *****************************************************************************

using Godot;
using LumiVerseFramework.Common;
using PentiumCup2025.Scripts.Commons;
using PentiumCup2025.Scripts.Entities;
using PentiumCup2025.Scripts.Interfaces;
using PentiumCup2025.Scripts.Managers;

namespace PentiumCup2025.Scripts.MVC.Controllers.Weather;

public class FallingStoneController : IWeather
{
    /// <summary>
    /// 生成陨石
    /// </summary>
    /// <param name="parent"></param>
    public void Generate(Node parent)
    {
        PackedScene fallingStoneScene =
            GD.Load<PackedScene>("res://Scenes/FallingStone/FallingStone.tscn");
        FallingStone fallingStone =
            fallingStoneScene.Instantiate<FallingStone>();
        // 初始化陨石
        fallingStone.Direction = GetRandomDirection();
        Vector2 screenSize = parent.GetViewport().GetVisibleRect().Size;
        Vector2 randomPos = Common
            .GetRandomScreenTopPos(screenSize);
        randomPos = parent.GetViewport().GetCanvasTransform()
            .AffineInverse() * randomPos;
        fallingStone.GlobalPosition = randomPos;
        YumihoshiDebug.Print<FallingStoneController>("陨石生成",
            "位置：" + fallingStone.GlobalPosition);
        parent.AddChild(fallingStone);
    }

    /// <summary>
    /// 获取生成间隔
    /// </summary>
    /// <returns></returns>
    public float GetInterval()
    {
        return Common.GetRandomFloat(
            ModelsManager.Instance.FallingStoneModelData.MinSpawnInterval,
            ModelsManager.Instance.FallingStoneModelData.MaxSpawnInterval);
    }

    /// <summary>
    /// 获取随机方向
    /// </summary>
    /// <returns></returns>
    private FallingStoneDirectionType GetRandomDirection()
    {
        return (FallingStoneDirectionType)Common.GetRandomInt(1, 3);
    }
}

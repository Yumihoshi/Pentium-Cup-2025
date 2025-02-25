// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/22 20:02
// @version: 1.0
// @description:
// *****************************************************************************

using Godot;
using LumiVerseFramework.Base;
using PentiumCup2025.Scripts.MVC.Models.Player;
using PentiumCup2025.Scripts.MVC.Models.Weather;

namespace PentiumCup2025.Scripts.Managers;

public partial class ModelsManager : Singleton<ModelsManager>
{
    public PlayerModel PlayerModelData { get; private set; }
    public WindModel WindModelData { get; private set; }
    public FallingStoneModel FallingStoneModelData { get; private set; }

    public override void _EnterTree()
    {
        base._EnterTree();
        // 获取模型数据
        PlayerModelData =
            GD.Load<PlayerModel>(
                "res://Assets/Resources/Player/PlayerModel.tres");
        WindModelData =
            GD.Load<WindModel>(
                "res://Assets/Resources/Weather/WindModel.tres");
        FallingStoneModelData = GD.Load<FallingStoneModel>(
            "res://Assets/Resources/Weather/FallingStoneModel.tres");
        // 初始化模型数据
        PlayerModelData.Init();
    }
}

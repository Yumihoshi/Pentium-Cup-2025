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

namespace PentiumCup2025.Scripts.Managers;

public partial class ModelsManager : Singleton<ModelsManager>
{
    public PlayerModel PlayerModelData { get; private set; }

    public override void _Ready()
    {
        base._Ready();
        PlayerModelData =
            GD.Load<PlayerModel>(
                "res://Assets/Resources/Player/PlayerModel.tres");
    }
}

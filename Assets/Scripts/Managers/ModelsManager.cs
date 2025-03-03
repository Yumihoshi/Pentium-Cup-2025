// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/03 21:03
// @version: 1.0
// @description:
// *****************************************************************************

using HoshiVerseFramework.Base;
using MVC.Models.Player;
using UnityEngine;

namespace Managers
{
    public class ModelsManager : Singleton<ModelsManager>
    {
        public PlayerModel PlayerData { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            PlayerData = Resources.Load<PlayerModel>("Configs/Player Config");
        }
    }
}

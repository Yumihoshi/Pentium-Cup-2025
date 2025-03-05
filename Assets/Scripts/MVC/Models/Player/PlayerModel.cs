// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/04 13:03
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using Managers;
using UnityEngine;

namespace MVC.Models.Player
{
    public class PlayerModel
    {
        private int _curHp;

        private Vector2 _inputDirection = Vector2.zero;
        private bool _isSpeedUp;

        public PlayerModel(int initHp)
        {
            _curHp = initHp;
        }

        public bool IsEnterThunder { get; set; }

        public bool IsSpeedUp
        {
            get => _isSpeedUp;
            set
            {
                if (_isSpeedUp == value) return;
                _isSpeedUp = value;
                OnSpeedUpEvent?.Invoke(_isSpeedUp);
            }
        }

        public Vector2 InputDirection
        {
            get => _inputDirection;
            set
            {
                if (_inputDirection == value) return;
                _inputDirection = value;
                OnMoveEvent?.Invoke(_inputDirection);
            }
        }

        public event Action<bool> OnSpeedUpEvent;
        public event Action<Vector2> OnMoveEvent;

        public void Init()
        {
            _curHp = ModelsManager.Instance.PlayerData.MaxHp;
        }

        /// <summary>
        /// 受到伤害
        /// </summary>
        /// <param name="damage"></param>
        public void TakeDamage(int damage)
        {
            _curHp = Mathf.Clamp(_curHp - damage, 0,
                ModelsManager.Instance.PlayerData.MaxHp);
            Debug.Log("玩家受到伤害，剩余血量" + _curHp);
        }

        /// <summary>
        /// 治疗
        /// </summary>
        /// <param name="heal"></param>
        public void Heal(int heal)
        {
            _curHp = Mathf.Clamp(_curHp + heal, 0,
                ModelsManager.Instance.PlayerData.MaxHp);
            Debug.Log("玩家受到治疗，剩余血量" + _curHp);
        }
    }
}

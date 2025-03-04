// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/03 20:03
// @version: 1.0
// @description:
// *****************************************************************************

using Entities.Bullet;
using HoshiVerseFramework.Base;
using Managers;
using MVC.Models.Player;
using MVC.Views.Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MVC.Controllers.Player
{
    public class PlayerController : MonoBehaviour
    {
        private float _attackTimer;
        private Transform _bulletSpawnPos;
        private PlayerView _view;
        public PlayerModel Model { get; private set; }

        private void Awake()
        {
            Model = new PlayerModel(ModelsManager.Instance.PlayerData.MaxHp);
            Model.Init();
            _view = GetComponent<PlayerView>();
        }

        private void Start()
        {
            _bulletSpawnPos = GameObject.FindWithTag("Player").transform
                .Find("FirePos");
            // 注册减速事件
            EventCenterManager.Instance.AddListener<SpeedDownArg>(
                _view.RotateReverse);
        }

        private void Update()
        {
            if (_attackTimer <= 0) return;
            _attackTimer -= Time.deltaTime;
        }

        /// <summary>
        /// 按下旋转键
        /// </summary>
        /// <param name="value"></param>
        private void OnRotate(InputValue value)
        {
            Model.InputDirection = value.Get<Vector2>();
        }

        /// <summary>
        /// 按下攻击键
        /// </summary>
        /// <param name="value"></param>
        private void OnAttack(InputValue value)
        {
            if (_attackTimer > 0) return;
            // 发射子弹
            Bullet bullet = PoolManager.Instance.BulletPool.Get();
            bullet.Init(_bulletSpawnPos.position, transform.rotation);
            bullet.Launch();
            _attackTimer = ModelsManager.Instance.PlayerData.AttackInterval;
        }

        /// <summary>
        /// 按下加速键
        /// </summary>
        /// <param name="value"></param>
        private void OnSpeedUp(InputValue value)
        {
            Model.IsSpeedUp = value.isPressed;
        }
    }
}

// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/03 20:03
// @version: 1.0
// @description:
// *****************************************************************************

using Managers;
using MVC.Models.Player;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace MVC.Controllers.Player
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerModel Model { get; private set; }
        
        private float _attackTimer;
        private GameObject _bulletPrefab;
        private Transform _bulletSpawnPos;

        private void Awake()
        {
            Model = new PlayerModel(ModelsManager.Instance.PlayerData.MaxHp);
            _bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");
        }

        private void Start()
        {
            _bulletSpawnPos = transform.Find("FirePos");
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
            Instantiate(_bulletPrefab, _bulletSpawnPos.position,
                transform.rotation);
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

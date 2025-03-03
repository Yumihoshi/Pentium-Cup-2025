// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/03 20:03
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using Managers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace MVC.Controllers.Player
{
    public class PlayerController : MonoBehaviour
    {
        public UnityEvent<bool> OnSpeedUpEvent => onSpeedUpEvent;

        [SerializeField] private UnityEvent<bool> onSpeedUpEvent = new();
        private Vector2 _inputDirection = Vector2.zero;
        private bool _isSpeedUp;
        private Rigidbody2D _rb;
        private GameObject _bulletPrefab;
        private Transform _bulletSpawnPos;
        private float _attackTimer;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
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

        private void FixedUpdate()
        {
            Move();
            SpeedUp();
        }

        /// <summary>
        /// 按下旋转键
        /// </summary>
        /// <param name="value"></param>
        private void OnRotate(InputValue value)
        {
            _inputDirection = value.Get<Vector2>();
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
            _isSpeedUp = value.isPressed;
        }

        private void Move()
        {
            if (_inputDirection == Vector2.zero) return;
            // 旋转
            float targetRotation = Mathf.Clamp(_rb.rotation -
                                               _inputDirection.x *
                                               ModelsManager.Instance.PlayerData
                                                   .RotateSpeed *
                                               Time.fixedDeltaTime,
                ModelsManager.Instance.PlayerData.MinRotateAngle,
                ModelsManager.Instance.PlayerData.MaxRotateAngle);
            _rb.MoveRotation(targetRotation);
        }

        private void SpeedUp()
        {
            if (!_isSpeedUp)
            {
                _rb.linearVelocity = transform.up *
                                     ModelsManager.Instance.PlayerData
                                         .MoveSpeed;
                onSpeedUpEvent.Invoke(false);
            }
            else
            {
                _rb.linearVelocity = transform.up *
                                     ModelsManager.Instance.PlayerData
                                         .SpeedUpSpeed;
                onSpeedUpEvent.Invoke(true);
            }
        }
    }
}

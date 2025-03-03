// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/03 20:03
// @version: 1.0
// @description:
// *****************************************************************************

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

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Move();
            SpeedUp();
        }

        private void OnRotate(InputValue value)
        {
            _inputDirection = value.Get<Vector2>();
        }

        private void OnAttack(InputValue value)
        {
        }

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

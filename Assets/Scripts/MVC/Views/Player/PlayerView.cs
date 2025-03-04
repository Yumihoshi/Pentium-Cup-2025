// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/03 20:03
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using Managers;
using MVC.Controllers.Player;
using MVC.Models.Player;
using UnityEngine;

namespace MVC.Views.Player
{
    public class PlayerView : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private PlayerModel _model;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        
        private void Start()
        {
            _model = GetComponent<PlayerController>().Model;
        }

        private void FixedUpdate()
        {
            Move();
            SpeedUp();
        }

        private void Move()
        {
            if (_model.InputDirection == Vector2.zero) return;
            // 旋转
            float targetRotation = Mathf.Clamp(_rb.rotation -
                                               _model.InputDirection.x *
                                               ModelsManager.Instance.PlayerData
                                                   .RotateSpeed *
                                               Time.fixedDeltaTime,
                ModelsManager.Instance.PlayerData.MinRotateAngle,
                ModelsManager.Instance.PlayerData.MaxRotateAngle);
            _rb.MoveRotation(targetRotation);
        }

        private void SpeedUp()
        {
            if (!_model.IsSpeedUp)
            {
                _rb.linearVelocity = transform.up *
                                     ModelsManager.Instance.PlayerData
                                         .MoveSpeed;
                _model.IsSpeedUp = false;
            }
            else
            {
                _rb.linearVelocity = transform.up *
                                     ModelsManager.Instance.PlayerData
                                         .SpeedUpSpeed;
                _model.IsSpeedUp = true;
            }
        }
    }
}

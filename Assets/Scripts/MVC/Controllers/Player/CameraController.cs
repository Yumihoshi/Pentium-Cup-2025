// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/03 21:03
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using DG.Tweening;
using UnityEngine;

namespace MVC.Controllers.Player
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float smoothDuration = 0.2f;
        private Vector3 _originPos;
        private Vector3 _speedUpPos;

        private void Awake()
        {
            _originPos = transform.position;
            _speedUpPos = _originPos + new Vector3(0, -1.2f, 0);
        }

        private void Start()
        {
            // 获取玩家
            GameObject player = GameObject.FindWithTag("Player");
            if (!player) return;
            // 订阅玩家的加速事件
            PlayerController playerController =
                player.GetComponent<PlayerController>();
            if (!playerController) return;
            playerController.OnSpeedUpEvent.AddListener(OnSpeedUp);
        }

        private void OnSpeedUp(bool isSpeedUp)
        {
            if (isSpeedUp)
            {
                transform.DOMove(_speedUpPos, smoothDuration)
                    .SetEase(Ease.OutQuad);
            }
            else
            {
                transform.DOMove(_originPos, smoothDuration)
                    .SetEase(Ease.OutQuad);
            }
        }
    }
}

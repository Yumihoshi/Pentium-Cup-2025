// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/11 20:03
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections.Generic;
using MVC.Controllers.Player;
using MVC.Models.Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HpBar : MonoBehaviour
    {
        [SerializeField] private List<Sprite> hpSprites;
        private Image _img;
        private PlayerModel _playerModel;

        private void Awake()
        {
            _img = GetComponent<Image>();
        }

        private void Start()
        {
            // 设置满血图标
            _img.sprite = hpSprites[^1];
            _playerModel = GameObject.FindWithTag("Player")
                .GetComponent<PlayerController>().Model;
            _playerModel.OnHpChangeEvent += OnHpChange;
        }

        private void OnHpChange(int hp)
        {
            int index = hp / 20;
            Debug.Log($"index为{index}");
            if (index < 0 || index >= hpSprites.Count) return;
            if (index == 0 && hp > 0) return;
            _img.sprite = hpSprites[index];
        }
    }
}

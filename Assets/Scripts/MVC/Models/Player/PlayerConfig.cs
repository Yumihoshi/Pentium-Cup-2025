// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/03 20:03
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections.Generic;
using UnityEngine;

namespace MVC.Models.Player
{
    [CreateAssetMenu(fileName = "Player Config", menuName = "配置/新建玩家配置",
        order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        [Header("旋转限制")] [Range(-180f, 0f)] [SerializeField]
        private float minRotateAngle = -75f;

        [Range(0f, 180f)] [SerializeField] private float maxRotateAngle = 75f;

        [Header("移动")] [SerializeField] private float rotateSpeed = 140f;

        [SerializeField] private float moveSpeed = 3f;

        [Header("加速")] [SerializeField] private float speedUpSpeed = 6f;

        [Header("攻击间隔")] [SerializeField] private float attackInterval = 0.3f;

        [Header("血量")] [SerializeField] private int maxHp = 100;

        [Header("每张地图所需里程数")] [SerializeField]
        private List<int> milesPerMap = new();

        public float RotateSpeed => rotateSpeed;
        public float MoveSpeed => moveSpeed;
        public float MinRotateAngle => minRotateAngle;
        public float MaxRotateAngle => maxRotateAngle;
        public float SpeedUpSpeed => speedUpSpeed;
        public float AttackInterval => attackInterval;
        public int MaxHp => maxHp;
        public List<int> MilesPerMap => milesPerMap;
    }
}

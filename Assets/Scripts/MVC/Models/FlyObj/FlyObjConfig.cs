// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/04 20:03
// @version: 1.0
// @description:
// *****************************************************************************

using UnityEngine;

namespace MVC.Models.FlyObj
{
    [CreateAssetMenu(fileName = "Fly Object Config", menuName = "配置/新建飞行物配置",
        order = 1)]
    public class FlyObjConfig : ScriptableObject
    {
        [Header("陨石生成间隔")] [SerializeField]
        private float minStoneSpawnInterval = 3f;

        [SerializeField] private float maxStoneSpawnInterval = 5f;

        [Header("风生成间隔")] [SerializeField]
        private float minWindSpawnInterval = 5f;

        [SerializeField] private float maxWindSpawnInterval = 8f;

        [Header("雷暴生成间隔")] [SerializeField]
        private float minThunderSpawnInterval = 5f;

        [SerializeField] private float maxThunderSpawnInterval = 8f;
        public float MinThunderSpawnInterval => minThunderSpawnInterval;
        public float MaxThunderSpawnInterval => maxThunderSpawnInterval;
        public float MinStoneSpawnInterval => minStoneSpawnInterval;
        public float MaxStoneSpawnInterval => maxStoneSpawnInterval;
        public float MinWindSpawnInterval => minWindSpawnInterval;
        public float MaxWindSpawnInterval => maxWindSpawnInterval;
    }
}

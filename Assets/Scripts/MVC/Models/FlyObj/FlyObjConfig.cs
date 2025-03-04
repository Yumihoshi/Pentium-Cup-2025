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
        [SerializeField] private float minSpawnInterval;
        [SerializeField] private float maxSpawnInterval;
        public float MinSpawnInterval => minSpawnInterval;
        public float MaxSpawnInterval => maxSpawnInterval;
    }
}

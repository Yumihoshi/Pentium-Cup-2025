// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/04 21:03
// @version: 1.0
// @description:
// *****************************************************************************

using UnityEngine;

namespace MVC.Models.Weather
{
    [CreateAssetMenu(fileName = "Weather Config", menuName = "配置/天气配置",
        order = 2)]
    public class WeatherConfig : ScriptableObject
    {
        [Header("天气切换间隔")] [SerializeField] private float minInterval = 10f;

        [SerializeField] private float maxInterval = 15f;
        public float MinInterval => minInterval;
        public float MaxInterval => maxInterval;
    }
}

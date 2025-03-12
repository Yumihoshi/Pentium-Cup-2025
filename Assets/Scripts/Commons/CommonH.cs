// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/04 20:03
// @version: 1.0
// @description:
// *****************************************************************************

using UnityEngine;

namespace Commons
{
    public class CommonH
    {
        /// <summary>
        /// 获取随机屏幕顶部位置
        /// </summary>
        /// <returns></returns>
        public static Vector3 GetRandomScreenTopPos()
        {
            Vector3 screenPos = new(Random.Range(0f, Screen.width),
                Screen.height, 0f);
            if (!Camera.main)
            {
                Debug.LogError("获取随机屏幕顶部位置失败，未找到主相机");
                return Vector3.zero;
            }

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
            worldPos.z = 0f;
            worldPos.y += 10f;
            return worldPos;
        }

        public static Vector3 GetRandomScreenPos()
        {
            Vector3 screenPos = new(Random.Range(0f, Screen.width),
                Random.Range(0f, Screen.height), 0f);
            if (!Camera.main)
            {
                Debug.LogError("获取随机屏幕位置失败，未找到主相机");
                return Vector3.zero;
            }

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
            worldPos.z = 0f;
            return worldPos;
        }
    }
}

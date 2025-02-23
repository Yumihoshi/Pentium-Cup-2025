// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/23 18:02
// @version: 1.0
// @description:
// *****************************************************************************

using System;

namespace PentiumCup2025.Scripts.Commons;

public static class Common
{
    /// <summary>
    /// 随机生成一个小数
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static float GetRandomFloat(float min, float max)
    {
        Random random = new();
        return min + (float)random.NextDouble() * (max - min);
    }
}

// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/25 19:02
// @version: 1.0
// @description:
// *****************************************************************************

using System;

namespace LumiVerseFramework.Common;

public class YumihoshiRandom
{
    private static readonly Random Random = new();

    /// <summary>
    /// 随机生成一个小数，左闭右开
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static float GetRandomFloat(float min, float max)
    {
        return min + (float)Random.NextDouble() * (max - min);
    }

    /// <summary>
    /// 随机生成一个整数，左闭右开
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static int GetRandomInt(int min, int max)
    {
        return Random.Next(min, max);
    }
}

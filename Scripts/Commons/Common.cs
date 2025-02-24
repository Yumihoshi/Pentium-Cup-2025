// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/23 18:02
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using Godot;

namespace PentiumCup2025.Scripts.Commons;

public static class Common
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

    /// <summary>
    /// 获取一个随机的屏幕顶部的位置
    /// </summary>
    /// <param name="screenSize"></param>
    /// <returns></returns>
    public static Vector2 GetRandomScreenTopPos(Vector2 screenSize)
    {
        return new Vector2(GetRandomFloat(0, screenSize.X), -screenSize.Y);
    }
}

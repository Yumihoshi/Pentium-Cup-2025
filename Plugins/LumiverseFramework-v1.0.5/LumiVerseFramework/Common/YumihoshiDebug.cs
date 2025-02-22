// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/13 15:02
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using Godot;

namespace LumiVerseFramework.Common;

public static class YumihoshiDebug
{
    /// <summary>
    /// 打印Info级别的日志
    /// </summary>
    /// <param name="funcType">功能模块类型</param>
    /// <param name="message">打印日志</param>
    /// <typeparam name="T">当前调用的脚本类名</typeparam>
    public static void Print<T>(string funcType, string message)
    {
        GD.Print(
            $"[{funcType}] {typeof(T).Name} {GetNowTime()}\n>>> {message}");
    }

    /// <summary>
    /// 打印Warning级别的日志
    /// </summary>
    /// <param name="funcType">功能模块类型</param>
    /// <param name="message">打印日志</param>
    /// <typeparam name="T">当前调用的脚本类名</typeparam>
    public static void Warn<T>(string funcType, string message)
    {
        GD.PushWarning($"[{funcType}] {typeof(T).Name}\n>>> {message}");
    }

    /// <summary>
    /// 将Error级别的日志推送到栈，便于调试（不会输出到控制台）
    /// </summary>
    /// <param name="funcType">功能模块类型</param>
    /// <param name="message">打印日志</param>
    /// <typeparam name="T">当前调用的脚本类名</typeparam>
    public static void Error<T>(string funcType, string message)
    {
        GD.PushError($"[{funcType}] {typeof(T).Name}\n>>> {message}");
    }

    private static string GetNowTime()
    {
        DateTime now = DateTime.Now;
        return now.ToString("yyyy-MM-dd HH:mm:ss.fff");
    }
}

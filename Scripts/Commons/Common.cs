// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/23 18:02
// @version: 1.0
// @description:
// *****************************************************************************

using Godot;
using LumiVerseFramework.Common;

namespace PentiumCup2025.Scripts.Commons;

public static class Common
{
    /// <summary>
    /// 获取一个随机的屏幕顶部的位置
    /// </summary>
    /// <param name="screenSize"></param>
    /// <returns></returns>
    public static Vector2 GetRandomScreenTopPos(Vector2 screenSize)
    {
        return new Vector2(YumihoshiRandom.GetRandomFloat(0, screenSize.X),
            0);
    }
}

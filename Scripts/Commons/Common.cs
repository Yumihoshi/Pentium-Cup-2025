// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/23 18:02
// @version: 1.0
// @description:
// *****************************************************************************

using Godot;
using LumiVerseFramework.Common;
using PentiumCup2025.Scripts.Entities.Base;

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

    /// <summary>
    /// 获取随机方向
    /// </summary>
    /// <returns></returns>
    public static FlyObjDirectionType GetRandomDirection()
    {
        return (FlyObjDirectionType)YumihoshiRandom.GetRandomInt(1, 3);
    }
}

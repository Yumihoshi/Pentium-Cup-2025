// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/25 19:02
// @version: 1.0
// @description:
// *****************************************************************************

using Godot;

namespace LumiVerseFramework.Common;

public class YumihoshiConvert
{
    /// <summary>
    /// 将屏幕坐标转换为世界坐标
    /// </summary>
    /// <param name="screenPos">屏幕坐标</param>
    /// <param name="node">当前节点</param>
    /// <returns>世界坐标</returns>
    public static Vector2 ConvertScreenToWorld(Vector2 screenPos, Node node)
    {
        Viewport viewport = node.GetViewport();
        Transform2D inverseTransform = viewport.CanvasTransform.AffineInverse();
        return inverseTransform * screenPos;
    }

    /// <summary>
    /// 将世界坐标转换为屏幕坐标
    /// </summary>
    /// <param name="worldPos">世界坐标</param>
    /// <param name="node">当前节点</param>
    /// <returns>屏幕坐标</returns>
    public static Vector2 ConvertWorldToScreen(Vector2 worldPos, Node node)
    {
        Viewport viewport = node.GetViewport();
        Transform2D transform = viewport.CanvasTransform;
        return transform * worldPos;
    }
}

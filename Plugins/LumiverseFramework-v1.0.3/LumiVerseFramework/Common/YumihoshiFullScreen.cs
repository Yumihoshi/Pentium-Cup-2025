// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/13 15:02
// @version: 1.0
// @description:
// *****************************************************************************

using Godot;

namespace LumiVerseFramework.Common;

public class YumihoshiFullScreen
{
    /// <summary>
    /// 切换全屏/窗口
    /// </summary>
    /// <param name="isFullScreen"></param>
    /// <param name="windowId">窗口id，默认当前窗口</param>
    public static void SwitchFullScreen(bool isFullScreen, int windowId = 0)
    {
        if (isFullScreen)
            DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen,
                windowId);
    }

    /// <summary>
    /// 切换全屏/窗口，根据当前状态切换，全屏->窗口，窗口->全屏
    /// </summary>
    /// <param name="windowId">窗口id，默认当前窗口</param>
    public static void SwitchFullScreenAuto(int windowId = 0)
    {
        DisplayServer.WindowSetMode(
            DisplayServer.WindowGetMode(windowId) ==
            DisplayServer.WindowMode.Fullscreen
                ? DisplayServer.WindowMode.Windowed
                : DisplayServer.WindowMode.Fullscreen);
    }
}

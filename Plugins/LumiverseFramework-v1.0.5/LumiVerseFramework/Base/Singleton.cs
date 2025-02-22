// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/02/22 20:02
// @version: 1.0
// @description:
// *****************************************************************************

using Godot;

namespace LumiVerseFramework.Base;

public partial class Singleton<T> : Node where T : Node
{
    public static T Instance { get; private set; }

    public override void _EnterTree()
    {
        base._EnterTree();
        if (Instance != null) QueueFree();

        Instance = this as T;
    }
}

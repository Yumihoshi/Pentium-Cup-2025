// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/02 17:03
// @version: 1.0
// @description:
// *****************************************************************************

using UnityEngine;

namespace HoshiVerseFramework.Base
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        private static readonly object Lock = new();

        public static T Instance
        {
            get
            {
                if (_instance != null) return _instance;
                lock (Lock)
                {
                    _instance = FindFirstObjectByType<T>();

                    if (_instance != null) return _instance;
                    // 避免退出播放模式时，实例重建
                    if (!Application.isPlaying) return null;
                    // 创建一个新的实例
                    GameObject singletonObject = new();
                    _instance = singletonObject.AddComponent<T>();
                    singletonObject.name = typeof(T) + " (Singleton)";

                    return _instance;
                }
            }
        }

        protected virtual void Awake()
        {
            if (_instance != null && _instance != this) Destroy(gameObject);
            else _instance = this as T;
            // DontDestroyOnLoad(gameObject);
        }

        protected virtual void OnDestroy()
        {
            if (_instance == this) _instance = null;
        }
    }
}

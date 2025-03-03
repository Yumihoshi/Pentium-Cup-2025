// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/03 23:03
// @version: 1.0
// @description:
// *****************************************************************************

using HoshiVerseFramework.Base;
using UnityEngine;

namespace Managers
{
    public class ResourcesManager : Singleton<ResourcesManager>
    {
        [Header("爆炸特效")] [SerializeField] private GameObject explosionPrefab;
        public GameObject ExplosionPrefab => explosionPrefab;
    }
}

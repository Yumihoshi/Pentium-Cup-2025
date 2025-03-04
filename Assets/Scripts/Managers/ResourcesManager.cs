// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/03 23:03
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections.Generic;
using HoshiVerseFramework.Base;
using UnityEngine;

namespace Managers
{
    public class ResourcesManager : Singleton<ResourcesManager>
    {
        [Header("爆炸特效")] [SerializeField] private GameObject explosionPrefab;

        [Header("子弹")] [SerializeField] private GameObject bulletPrefab;

        [Header("陨石")] [SerializeField]
        private List<GameObject> fallingStonePrefabs;

        [Header("风")] [SerializeField] private GameObject windPrefab;

        public GameObject ExplosionPrefab => explosionPrefab;
        public GameObject BulletPrefab => bulletPrefab;

        public List<GameObject> FallingStonePrefabs => fallingStonePrefabs;
        public GameObject WindPrefab => windPrefab;
    }
}

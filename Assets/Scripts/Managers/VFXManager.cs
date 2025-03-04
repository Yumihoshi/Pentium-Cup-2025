// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/04 19:03
// @version: 1.0
// @description:
// *****************************************************************************

using Entities.VFX;
using HoshiVerseFramework.Base;
using UnityEngine;
using UnityEngine.Pool;

namespace Managers
{
    public class VFXManager : Singleton<VFXManager>
    {
        public ObjectPool<ExplosionVFX> ExplosionPool { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            ExplosionPool = new ObjectPool<ExplosionVFX>(CreateExplosion,
                GetExplosion,
                ReleaseExplosion, DestroyExplosion, true, 10, 100);
        }

        private ExplosionVFX CreateExplosion()
        {
            GameObject explosion =
                Instantiate(ResourcesManager.Instance.ExplosionPrefab);
            ExplosionVFX explosionScript =
                explosion.GetComponent<ExplosionVFX>();
            explosionScript.SetPool(ExplosionPool);
            return explosionScript;
        }

        private void GetExplosion(ExplosionVFX explosion)
        {
            explosion.gameObject.SetActive(true);
        }

        private void ReleaseExplosion(ExplosionVFX explosion)
        {
            explosion.gameObject.SetActive(false);
        }

        private void DestroyExplosion(ExplosionVFX explosion)
        {
            Destroy(explosion.gameObject);
        }
    }
}

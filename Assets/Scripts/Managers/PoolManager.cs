// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/04 18:03
// @version: 1.0
// @description:
// *****************************************************************************

using Entities.Bullet;
using Entities.FallingStone;
using Entities.VFX;
using Entities.Weather;
using Entities.Wind;
using HoshiVerseFramework.Base;
using UnityEngine;
using UnityEngine.Pool;

namespace Managers
{
    public class PoolManager : Singleton<PoolManager>
    {
        public ObjectPool<Bullet> BulletPool { get; private set; }
        public ObjectPool<ExplosionVFX> ExplosionVFXPool { get; private set; }
        public ObjectPool<FallingStone> FallingStonePool { get; private set; }
        public ObjectPool<Wind> WindPool { get; private set; }
        public ObjectPool<Thunder> ThunderPool { get; private set; }

        private void Start()
        {
            BulletPool = new ObjectPool<Bullet>(CreateBullet, GetBullet,
                ReleaseBullet, DestroyBullet, true, 10, 50);
            ExplosionVFXPool = new ObjectPool<ExplosionVFX>(CreateExplosion,
                GetExplosion,
                ReleaseExplosion, DestroyExplosion, true, 10, 50);
            FallingStonePool = new ObjectPool<FallingStone>(CreateFallingStone,
                GetFallingStone,
                ReleaseFallingStone, DestroyFallingStone, true, 10, 50);
            WindPool = new ObjectPool<Wind>(CreateWind, GetWind, ReleaseWind,
                DestroyWind, true, 10, 50);
            ThunderPool = new ObjectPool<Thunder>(CreateThunder, GetThunder,
                ReleaseThunder, DestroyThunder, true, 10, 50);
        }

        #region 子弹

        private Bullet CreateBullet()
        {
            GameObject bullet =
                Instantiate(ResourcesManager.Instance.BulletPrefab);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.SetPool(BulletPool);
            return bulletScript;
        }

        private void GetBullet(Bullet bullet)
        {
            bullet.gameObject.SetActive(true);
        }

        private void ReleaseBullet(Bullet bullet)
        {
            bullet.gameObject.SetActive(false);
        }

        private void DestroyBullet(Bullet bullet)
        {
            Destroy(bullet.gameObject);
        }

        #endregion

        #region 子弹命中爆炸特效

        private ExplosionVFX CreateExplosion()
        {
            GameObject explosion =
                Instantiate(ResourcesManager.Instance.ExplosionPrefab);
            ExplosionVFX explosionScript =
                explosion.GetComponent<ExplosionVFX>();
            explosionScript.SetPool(ExplosionVFXPool);
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

        #endregion

        #region 陨石

        private FallingStone CreateFallingStone()
        {
            GameObject fallingStone =
                Instantiate(
                    ResourcesManager.Instance.FallingStonePrefabs[
                        Random.Range(0, 2)]);
            FallingStone fallingStoneScript =
                fallingStone.GetComponent<FallingStone>();
            fallingStoneScript.SetPool(FallingStonePool);
            return fallingStoneScript;
        }

        private void GetFallingStone(FallingStone stone)
        {
            stone.gameObject.SetActive(true);
        }

        private void ReleaseFallingStone(FallingStone stone)
        {
            stone.gameObject.SetActive(false);
        }

        private void DestroyFallingStone(FallingStone stone)
        {
            Destroy(stone.gameObject);
        }

        #endregion

        #region 风

        private Wind CreateWind()
        {
            GameObject wind = Instantiate(ResourcesManager.Instance.WindPrefab);
            Wind windScript = wind.GetComponent<Wind>();
            windScript.SetPool(WindPool);
            return windScript;
        }

        private void GetWind(Wind wind)
        {
            wind.gameObject.SetActive(true);
        }

        private void ReleaseWind(Wind wind)
        {
            wind.gameObject.SetActive(false);
        }

        private void DestroyWind(Wind wind)
        {
            Destroy(wind.gameObject);
        }

        #endregion

        #region 雷暴

        private Thunder CreateThunder()
        {
            GameObject thunder =
                Instantiate(ResourcesManager.Instance.ThunderPrefab);
            Thunder thunderScript = thunder.GetComponent<Thunder>();
            thunderScript.SetPool(ThunderPool);
            return thunderScript;
        }

        private void GetThunder(Thunder thunder)
        {
            thunder.gameObject.SetActive(true);
        }

        private void ReleaseThunder(Thunder thunder)
        {
            thunder.gameObject.SetActive(false);
        }

        private void DestroyThunder(Thunder thunder)
        {
            Destroy(thunder.gameObject);
        }

        #endregion
    }
}

// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/04 18:03
// @version: 1.0
// @description:
// *****************************************************************************

using Entities.Bullet;
using HoshiVerseFramework.Base;
using UnityEngine;
using UnityEngine.Pool;

namespace Managers
{
    public class BulletManager : Singleton<BulletManager>
    {
        private GameObject _bulletPrefab;
        public ObjectPool<Bullet> BulletPool { get; private set; }

        private void Start()
        {
            BulletPool = new ObjectPool<Bullet>(CreateBullet, GetBullet,
                ReleaseBullet, DestroyBullet, true, 10, 100);
            _bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");
        }

        private Bullet CreateBullet()
        {
            GameObject bullet = Instantiate(_bulletPrefab);
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
    }
}

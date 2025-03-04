// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/03 22:03
// @version: 1.0
// @description:
// *****************************************************************************

using Entities.VFX;
using Managers;
using UnityEngine;
using UnityEngine.Pool;

namespace Entities.Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float lifeTime = 5f;
        [SerializeField] private float speed = 10f;

        private ObjectPool<Bullet> _pool;
        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Enemy")) return;
            // 播放爆炸特效
            ExplosionVFX explosion =
                PoolManager.Instance.ExplosionVFXPool.Get();
            explosion.Init(transform.position, Quaternion.identity);
            explosion.PlayVFX();
            // 销毁子弹
            Destroy(other.gameObject);
            _pool.Release(this);
        }

        private void ReleaseSelf()
        {
            if (!gameObject.activeSelf) return;
            _pool.Release(this);
        }

        public void SetPool(ObjectPool<Bullet> pool)
        {
            _pool = pool;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="rot"></param>
        public void Init(Vector3 pos, Quaternion rot)
        {
            transform.position = pos;
            transform.rotation = rot;
        }

        /// <summary>
        /// 发射子弹
        /// </summary>
        public void Launch()
        {
            Invoke(nameof(ReleaseSelf), lifeTime);
            if (!_rb) _rb = GetComponent<Rigidbody2D>();
            _rb.linearVelocity = transform.up * speed;
        }
    }
}

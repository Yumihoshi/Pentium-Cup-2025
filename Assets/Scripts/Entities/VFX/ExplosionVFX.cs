// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/03 23:03
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using UnityEngine;
using UnityEngine.Pool;

namespace Entities.VFX
{
    public class ExplosionVFX : MonoBehaviour
    {
        private ObjectPool<ExplosionVFX> _pool;
        private ParticleSystem _particleSystem;

        private void Awake()
        {
            _particleSystem = GetComponent<ParticleSystem>();
            _particleSystem.Stop();
        }

        private void OnEnable()
        {
            _particleSystem.Stop();
        }

        /// <summary>
        /// 设置对象池
        /// </summary>
        /// <param name="pool"></param>
        public void SetPool(ObjectPool<ExplosionVFX> pool)
        {
            _pool = pool;
        }

        public void PlayVFX()
        {
            _particleSystem.Play();
            Invoke(nameof(ReleaseSelf), 1.5f);
        }

        private void ReleaseSelf()
        {
            _pool.Release(this);
        }

        public void Init(Vector3 pos, Quaternion rot)
        {
            transform.position = pos;
            transform.rotation = rot;
        }
    }
}

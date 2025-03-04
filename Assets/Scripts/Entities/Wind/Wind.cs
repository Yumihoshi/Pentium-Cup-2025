// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/04 21:03
// @version: 1.0
// @description:
// *****************************************************************************

using HoshiVerseFramework.Base;
using MVC.Controllers.Player;
using UnityEngine;
using UnityEngine.Pool;

namespace Entities.Wind
{
    public class Wind : MonoBehaviour
    {
        [Header("风属性配置")] [SerializeField] private float lifeTime = 5f;

        [SerializeField] private float speed = 5f;
        [SerializeField] private float effectDuration = 2f;
        private Vector3 _direction;
        private ObjectPool<Wind> _pool;
        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            CancelInvoke(nameof(ReleaseSelf));
            EventCenterManager.Instance.TriggerEvent(
                new SpeedDownArg
                {
                    Duration = effectDuration,
                    IsReverse = true
                });
            ReleaseSelf();
        }

        public void SetPool(ObjectPool<Wind> pool)
        {
            _pool = pool;
        }

        public void Init(Vector3 pos, Quaternion rot)
        {
            transform.position = pos;
            transform.rotation = rot;
        }

        public void Launch()
        {
            _rb = GetComponent<Rigidbody2D>();
            Invoke(nameof(ReleaseSelf), lifeTime);
            _direction = GameObject.FindWithTag("Player").transform.position -
                         transform.position;
            _direction = _direction.normalized;
            _rb.linearVelocity = _direction * speed;
        }

        private void ReleaseSelf()
        {
            if (!gameObject.activeSelf) return;
            _pool.Release(this);
        }
    }
}

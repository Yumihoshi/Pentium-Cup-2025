// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/04 20:03
// @version: 1.0
// @description:
// *****************************************************************************

using MVC.Controllers.Player;
using UnityEngine;
using UnityEngine.Pool;

namespace Entities.FallingStone
{
    public class FallingStone : MonoBehaviour
    {
        [SerializeField] private StoneType type;
        [SerializeField] private int damage;
        [SerializeField] private float speed;
        [SerializeField] private float lifeTime = 5f;
        private Vector3 _direction;
        private ObjectPool<FallingStone> _pool;
        private Rigidbody2D _rb;
        public StoneType SizeType => type;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            CancelInvoke(nameof(ReleaseSelf));
            other.GetComponent<PlayerController>().Model.TakeDamage(damage);
            ReleaseSelf();
        }

        public void SetPool(ObjectPool<FallingStone> pool)
        {
            _pool = pool;
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

        public void Init(Vector3 pos, Quaternion rot)
        {
            transform.position = pos;
            transform.rotation = rot;
        }
    }
}

// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/03 22:03
// @version: 1.0
// @description:
// *****************************************************************************

using Managers;
using UnityEngine;

namespace Entities.Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float lifeTime = 5f;
        [SerializeField] private float speed = 10f;

        private Rigidbody2D _rb;
        // TODO: 对象池管理子弹

        private void Start()
        {
            Destroy(gameObject, lifeTime);
            _rb = GetComponent<Rigidbody2D>();
            _rb.linearVelocity = transform.up * speed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Enemy")) return;
            Instantiate(ResourcesManager.Instance.ExplosionPrefab,
                transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}

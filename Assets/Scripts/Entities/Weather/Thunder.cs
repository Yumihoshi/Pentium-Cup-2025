// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/05 15:03
// @version: 1.0
// @description:
// *****************************************************************************

using HoshiVerseFramework.Base;
using MVC.Controllers.Player;
using UnityEngine;
using UnityEngine.Pool;

namespace Entities.Weather
{
    public class Thunder : MonoBehaviour
    {
        [SerializeField] private float duration = 3f;
        [SerializeField] private float damageInterval = 0.1f;
        private ObjectPool<Thunder> _pool;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            Debug.Log("玩家进入雷暴区域，持续扣血");
            EventCenterManager.Instance.TriggerEvent(
                new EnterThunderAreaArg
                {
                    Damage = true,
                    DamageInterval = damageInterval
                });
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            Debug.Log("玩家退出雷暴区域，停止扣血");
            EventCenterManager.Instance.TriggerEvent(
                new EnterThunderAreaArg
                {
                    Damage = false,
                    DamageInterval = damageInterval
                });
        }

        public void SetPool(ObjectPool<Thunder> pool)
        {
            _pool = pool;
        }

        public void Launch()
        {
            Invoke(nameof(ReleaseSelf), duration);
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

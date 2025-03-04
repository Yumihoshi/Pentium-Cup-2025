// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/03 23:03
// @version: 1.0
// @description:
// *****************************************************************************

using UnityEngine;

namespace Entities.VFX
{
    public class ExplosionVFX : MonoBehaviour
    {
        private void Start()
        {
            // TODO: 对象池管理特效
            Destroy(gameObject, 1.5f);
        }
    }
}

// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/12 16:03
// @version: 1.0
// @description:
// *****************************************************************************

using Managers;
using UnityEngine;

namespace UI
{
    public class GameLevelBg : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;

        [Header("背景移动速度系数")] [Range(0f, 1f)] [SerializeField]
        private float parallaxSpeed = 0.1f;

        [SerializeField] private float ySpeed = 0.00028f;

        private void Start()
        {
            if (BgManager.Instance.LastX == 0)
                return;
            transform.parent.position = new Vector3(BgManager.Instance.LastX,
                transform.parent.position.y, transform.parent.position.z);
        }

        private void LateUpdate()
        {
            // 相机跟踪背景
            Vector3 offset = BgManager.Instance.LastPos -
                             mainCamera.transform.position;
            transform.position += offset * parallaxSpeed;
            transform.position = new Vector3(transform.position.x,
                transform.position.y - ySpeed, 0);
            BgManager.Instance.LastPos = mainCamera.transform.position;
        }
    }
}

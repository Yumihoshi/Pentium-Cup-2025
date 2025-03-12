// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/12 16:03
// @version: 1.0
// @description:
// *****************************************************************************

using UnityEngine;

namespace Entities.Cameras
{
    public class PlayerFollow : MonoBehaviour
    {
        private Vector3 _offset;
        private Transform _playerTransform;

        private void Start()
        {
            _playerTransform = GameObject.FindWithTag("Player").transform;
            _offset = transform.position - _playerTransform.position;
        }

        private void Update()
        {
            transform.position = _playerTransform.position + _offset;
        }
    }
}

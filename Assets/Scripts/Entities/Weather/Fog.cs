// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/05 15:03
// @version: 1.0
// @description:
// *****************************************************************************

using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Entities.Weather
{
    public class Fog : MonoBehaviour
    {
        [SerializeField] private float duration = 1f;
        private Image _img;

        private void Awake()
        {
            _img = GetComponent<Image>();
        }

        public void ShowFog(bool show)
        {
            _img.DOKill();
            _img.DOColor(show ? new Color(1, 1, 1, 20 / 255f) : Color.clear,
                duration);
        }
    }
}

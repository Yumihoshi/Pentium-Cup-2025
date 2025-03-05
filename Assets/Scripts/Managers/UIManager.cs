// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/05 18:03
// @version: 1.0
// @description:
// *****************************************************************************

using HoshiVerseFramework.Base;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private TMP_Text mileText;

        private void Start()
        {
            GameManager.Instance.OnMileChanged += UpdateMileTMP;
        }

        private void UpdateMileTMP(int mile)
        {
            mileText.text = $"当前里程：{mile}km";
        }
    }
}

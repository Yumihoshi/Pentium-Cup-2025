// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/09 23:03
// @version: 1.0
// @description:
// *****************************************************************************

using Managers;
using UnityEditor;
using UnityEngine;

namespace UI
{
    public class StartScene : MonoBehaviour
    {
        [SerializeField] private GameObject helpPanel;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F11))
                Screen.fullScreen = !Screen.fullScreen;
        }

        /// <summary>
        /// 开始游戏
        /// </summary>
        public void BtnStartClicked()
        {
            GameManager.Instance.LoadScene(1);
        }

        /// <summary>
        /// 退出游戏
        /// </summary>
        public void BtnExitClicked()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        public void ShowPanelHelp(bool show)
        {
            helpPanel.SetActive(show);
        }
    }
}

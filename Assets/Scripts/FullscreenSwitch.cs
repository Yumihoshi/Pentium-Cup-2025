// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/11 20:03
// @version: 1.0
// @description:
// *****************************************************************************

using UnityEngine;
using UnityEngine.SceneManagement;

public class FullscreenSwitch : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
            Screen.fullScreen = !Screen.fullScreen;
        else if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(1);
    }
}

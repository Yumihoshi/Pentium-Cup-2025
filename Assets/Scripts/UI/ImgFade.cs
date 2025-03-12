// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/11 20:03
// @version: 1.0
// @description:
// *****************************************************************************

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class ImgFade : MonoBehaviour
    {
        private Animator _animator;
        private Image _img;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _img = GetComponent<Image>();
            DontDestroyOnLoad(gameObject.transform.parent);
        }

        private void OnEnable()
        {
            if (GameObject.FindGameObjectsWithTag("ImgFade").Length > 1)
                Destroy(gameObject);
            SceneManager.sceneLoaded += (scene, mode) =>
            {
                _animator.SetBool("FadeIn", false);
                _animator.SetBool("FadeOut", true);
            };
        }

        public void EnableRaycast()
        {
            _img.raycastTarget = true;
        }

        public void DisableRaycast()
        {
            _img.raycastTarget = false;
        }

        public void PlayFadeIn()
        {
            _animator.SetBool("FadeOut", false);
            _animator.SetBool("FadeIn", true);
        }
    }
}

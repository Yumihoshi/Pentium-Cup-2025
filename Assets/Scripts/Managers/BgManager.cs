// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/05 17:03
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using HoshiVerseFramework.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class BgManager : Singleton<BgManager>
    {
        [SerializeField] private List<GameObject> bgs;
        [SerializeField] private float fadeTime = 3f;
        private int _curIndex = -1;
        private bool _finished = true;
        public List<GameObject> Bgs => bgs;

        private void Start()
        {
            SetBg(0);
        }

        public void SetNextBg()
        {
            SetBg(_curIndex + 1);
        }

        public void SetBg(int index)
        {
            if (index >= bgs.Count) return;
            if (_curIndex != -1)
            {
                // 渐变隐藏
                Image[] imgs = bgs[_curIndex].GetComponentsInChildren<Image>();
                foreach (Image img in imgs)
                    img.DOColor(new Color(1, 1, 1, 0), fadeTime).OnComplete(
                        () =>
                        {
                            _finished = true;
                            img.transform.parent.gameObject.SetActive(false);
                        });
            }

            StartCoroutine(BgHandler(index));
        }

        private IEnumerator BgHandler(int index)
        {
            while (!_finished) yield return null;
            _curIndex = index;
            bgs[index].SetActive(true);
            Image[] targetImgs = bgs[index].GetComponentsInChildren<Image>();
            foreach (Image img in targetImgs)
            {
                img.color = new Color(1, 1, 1, 0);
                img.DOColor(new Color(1, 1, 1, 1), fadeTime);
            }

            _finished = false;
        }
    }
}

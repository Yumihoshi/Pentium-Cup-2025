// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/04 22:03
// @version: 1.0
// @description:
// *****************************************************************************

using HoshiVerseFramework.Base;
using UnityEngine;

namespace Managers
{
    public class AudioManager : Singleton<AudioManager>
    {
        [SerializeField] private AudioSource bgmSource;
        [SerializeField] private AudioSource sfxSource;
        [SerializeField] private AudioSource rotateSfxSource;
        [SerializeField] private AudioSource attackSfxSource;
        [SerializeField] private AudioSource hitSfxSource;

        /// <summary>
        /// 播放BGM背景音乐
        /// </summary>
        /// <param name="bgmName"></param>
        public void PlayBgm(string bgmName)
        {
            bgmSource.Stop();
            bgmSource.clip = Resources.Load<AudioClip>("Audio/BGM/" + bgmName);
            bgmSource.Play();
        }

        /// <summary>
        /// 播放BGM背景音乐
        /// </summary>
        /// <param name="clip"></param>
        public void PlayBgm(AudioClip clip)
        {
            bgmSource.Stop();
            bgmSource.clip = clip;
            bgmSource.Play();
        }

        /// <summary>
        /// 播放音效
        /// </summary>
        /// <param name="sfxName"></param>
        public void PlaySfx(string sfxName)
        {
            sfxSource.PlayOneShot(
                Resources.Load<AudioClip>("Audio/SFX/" + sfxName));
        }

        /// <summary>
        /// 播放音效
        /// </summary>
        /// <param name="clip"></param>
        public void PlaySfx(AudioClip clip)
        {
            sfxSource.PlayOneShot(clip);
        }

        public void StopSfx()
        {
            sfxSource.Stop();
        }

        /// <summary>
        /// 播放旋转音效
        /// </summary>
        /// <param name="status"></param>
        public void PlayRotateSfx(bool status)
        {
            if (status)
            {
                if (rotateSfxSource.isPlaying) return;
                rotateSfxSource.Play();
            }
            else
            {
                rotateSfxSource.Stop();
            }
        }

        public void PlayAttackSfx()
        {
            attackSfxSource.Play();
        }

        public void PlayHitSfx()
        {
            hitSfxSource.Play();
        }
    }
}

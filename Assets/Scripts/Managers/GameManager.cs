﻿// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/04 20:03
// @version: 1.0
// @description:
// *****************************************************************************

using System;
using System.Collections;
using Commons;
using Entities.FallingStone;
using Entities.Wind;
using HoshiVerseFramework.Base;
using MVC.Controllers.Player;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private int mileLimit = 96100;
        private int _curMile;
        private ImgFade _imgFade;
        private int _level;
        private bool _spawnState;
        private float _timer;

        public int CurMile
        {
            get => _curMile;
            set
            {
                if (value == _curMile) return;
                _curMile = value;
                OnMileChanged?.Invoke(value);
            }
        }

        public bool SpawnState
        {
            get => _spawnState;
            set
            {
                if (value == _spawnState) return;
                _spawnState = value;
                OnSpawnFallingStone?.Invoke(value);
            }
        }

        private void Start()
        {
            OnSpawnFallingStone += isSpawn =>
                StartCoroutine(SpawnStoneHandler(isSpawn));
            OnSpawnFallingStone += isSpawn =>
                StartCoroutine(SpawnWindHandler(isSpawn));
            Invoke(nameof(Init), 2f);
        }

        private void Update()
        {
            if (_timer >= 0.0003f)
            {
                _timer = 0f;
                CurMile += 15;
                if (CurMile / mileLimit != _level)
                {
                    _level = CurMile / mileLimit;
                    BgManager.Instance.SetNextBg();
                }
            }

            _timer += Time.deltaTime;
            // 全屏切换
            if (Input.GetKeyDown(KeyCode.F11))
                Screen.fullScreen = !Screen.fullScreen;
        }

        private event Action<bool> OnSpawnFallingStone;
        public event Action<int> OnMileChanged;

        private void Init()
        {
            SpawnState = true;
            _imgFade = GameObject.FindWithTag("ImgFade")
                ?.GetComponent<ImgFade>();
            GameObject.FindWithTag("Player").GetComponent<PlayerController>()
                    .Model.OnDieEvent +=
                () => { LoadScene(0); };
        }

        private IEnumerator SpawnStoneHandler(bool isSpawn)
        {
            while (isSpawn)
            {
                // 生成陨石
                Vector3 spawnPos = CommonH.GetRandomScreenTopPos();
                FallingStone stone =
                    PoolManager.Instance.FallingStonePool.Get();
                stone.Init(spawnPos, Quaternion.identity);
                stone.Launch();
                yield return new WaitForSeconds(Random.Range(
                    ModelsManager.Instance.FlyObjData.MinStoneSpawnInterval,
                    ModelsManager.Instance.FlyObjData.MaxStoneSpawnInterval));
            }

            yield return null;
        }

        private IEnumerator SpawnWindHandler(bool isSpawn)
        {
            while (isSpawn)
            {
                // 生成风
                Vector3 windPos = CommonH.GetRandomScreenTopPos();
                Wind wind = PoolManager.Instance.WindPool.Get();
                wind.Init(windPos, Quaternion.identity);
                wind.Launch();
                yield return new WaitForSeconds(Random.Range(
                    ModelsManager.Instance.FlyObjData.MinWindSpawnInterval,
                    ModelsManager.Instance.FlyObjData.MaxWindSpawnInterval));
            }

            yield return null;
        }

        public void LoadScene(int index)
        {
            _imgFade = GameObject.FindWithTag("ImgFade")
                .GetComponent<ImgFade>();
            StartCoroutine(HandleLoadScene(index));
        }

        private IEnumerator HandleLoadScene(int index)
        {
            _imgFade.PlayFadeIn();
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(index);
        }
    }
}

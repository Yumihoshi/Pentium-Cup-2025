// *****************************************************************************
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
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        private bool _spawnState;

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

        private event Action<bool> OnSpawnFallingStone;

        private void Init()
        {
            SpawnState = true;
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
    }
}

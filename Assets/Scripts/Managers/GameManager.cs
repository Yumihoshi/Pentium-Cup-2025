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
using HoshiVerseFramework.Base;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        private bool _spawnFallingStone;

        public bool SpawnFallingStone
        {
            get => _spawnFallingStone;
            set
            {
                if (value == _spawnFallingStone) return;
                _spawnFallingStone = value;
                OnSpawnFallingStone?.Invoke(value);
            }
        }

        private void Start()
        {
            OnSpawnFallingStone += isSpawn =>
                StartCoroutine(SpawnFallingStoneHandler(isSpawn));
            Invoke(nameof(Init), 2f);
        }

        private event Action<bool> OnSpawnFallingStone;

        private void Init()
        {
            SpawnFallingStone = true;
        }

        private IEnumerator SpawnFallingStoneHandler(bool isSpawn)
        {
            while (isSpawn)
            {
                Vector3 spawnPos = CommonH.GetRandomScreenTopPos();
                FallingStone stone =
                    PoolManager.Instance.FallingStonePool.Get();
                stone.Init(spawnPos, Quaternion.identity);
                stone.Launch();
                yield return new WaitForSeconds(Random.Range(
                    ModelsManager.Instance.FlyObjData.MinSpawnInterval,
                    ModelsManager.Instance.FlyObjData.MaxSpawnInterval));
            }

            yield return null;
        }
    }
}

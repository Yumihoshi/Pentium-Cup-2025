// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/04 21:03
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections;
using System.Collections.Generic;
using Commons;
using HoshiVerseFramework.Base.FSM;
using Managers;
using UnityEngine;

namespace Entities.Weather.States
{
    public class ThunderRainy : FsmState
    {
        [SerializeField] private List<ParticleSystem> rain;
        private bool _isSpawn;

        public override bool OnCheck(StateContext context = null)
        {
            return true;
        }

        public override void OnEnter(StateContext context = null)
        {
            Debug.Log("天气进入雷雨");
            _isSpawn = true;
            StartCoroutine(SpawnThunderHandler());
            foreach (ParticleSystem s in rain) s.Play();
        }

        public override void OnUpdate()
        {
        }

        public override void OnFixedUpdate()
        {
        }

        public override void OnExit(StateContext context = null)
        {
            Debug.Log("天气退出雷雨");
            _isSpawn = false;
            foreach (ParticleSystem s in rain) s.Stop();
        }

        private IEnumerator SpawnThunderHandler()
        {
            while (_isSpawn)
            {
                Vector3 spawnPos = CommonH.GetRandomScreenPos();
                Thunder thunder = PoolManager.Instance.ThunderPool.Get();
                thunder.Init(spawnPos, Quaternion.identity);
                thunder.Launch();
                yield return new WaitForSeconds(Random.Range(
                    ModelsManager.Instance.FlyObjData.MinThunderSpawnInterval,
                    ModelsManager.Instance.FlyObjData.MaxThunderSpawnInterval));
            }

            yield return null;
        }
    }
}

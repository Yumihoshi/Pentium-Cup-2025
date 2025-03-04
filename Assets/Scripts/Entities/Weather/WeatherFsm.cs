// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/04 21:03
// @version: 1.0
// @description:
// *****************************************************************************

using System.Collections;
using HoshiVerseFramework.Base.FSM;
using Managers;
using UnityEngine;

namespace Entities.Weather
{
    public class WeatherFsm : FsmComponent
    {
        private int _lastIndex;
        public bool ChangeWeather { get; } = true;

        protected override void Start()
        {
            base.Start();
            StartCoroutine(HandleWeather());
        }

        private IEnumerator HandleWeather()
        {
            while (ChangeWeather)
            {
                yield return new WaitForSeconds(Random.Range(
                    ModelsManager.Instance.WeatherData.MinInterval,
                    ModelsManager.Instance.WeatherData.MaxInterval));
                FsmState weather = statesList[GetRandomIndex()];
                FsmStateMachine.SwitchState(weather.StateType);
            }
        }

        private int GetRandomIndex()
        {
            int index = Random.Range(0, statesList.Count);
            while (index == _lastIndex)
                index = Random.Range(0, statesList.Count);
            _lastIndex = index;
            return index;
        }
    }
}

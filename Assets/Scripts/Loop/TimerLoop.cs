using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

namespace Core.Loop
{
    public class TimerLoop : MonoBehaviour
    {
        [SerializeField] private double _time = 0;
        private Coroutine _main;

        private static UnityEvent<double> _updateEvent = new UnityEvent<double>();

        public static event UnityAction<double> UpdateTimer
        {
            add => _updateEvent.AddListener(value);
            remove => _updateEvent.RemoveListener(value);
        }

        private void Start()
        {
            _updateEvent.Invoke(_time);
            _main = StartCoroutine(Timer());
        }

        private IEnumerator Timer()
        {
            while (true)
            {
                 yield return null;
                _time += Time.deltaTime;
                _updateEvent.Invoke(_time);
            }
        }
    }
}
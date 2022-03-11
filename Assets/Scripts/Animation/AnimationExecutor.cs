using UnityEngine.Events;
using UnityEngine;
using Core.Loop;

namespace Core.Animation
{
    public class AnimationExecutor : MonoBehaviour
    {
        private static UnityEvent<double> _updateEvent = new UnityEvent<double>();

        public static event UnityAction<double> UpdateTimer
        {
            add => _updateEvent.AddListener(value);
            remove => _updateEvent.RemoveListener(value);
        }

        private void OnEnable()
        {
            TimerLoop.UpdateTimer += UpdateAnimation;
        }
        private void OnDisable()
        {
            TimerLoop.UpdateTimer -= UpdateAnimation;
        }

        private void UpdateAnimation(double time)
        {
            _updateEvent.Invoke(time);
        }
    }
}
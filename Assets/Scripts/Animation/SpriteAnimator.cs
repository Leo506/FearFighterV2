using System.Collections.Generic;
using UnityEngine;

namespace Core.Animation
{
    public class SpriteAnimator : MonoBehaviour
    {
        [SerializeField] private List<Animation> _animations = new List<Animation>();
        [SerializeField] private Animation _current;
        [SerializeField] private SpriteRenderer _renderer;

        private double startTime, currentTime;

        private void OnEnable()
        {
            AnimationExecutor.UpdateTimer += UpdateSprite;
        }
        private void OnDisable()
        {
            AnimationExecutor.UpdateTimer -= UpdateSprite;
        }

        public void Switch(string name)
        {
            //Debug.Log(string.Format("Object {0} switch animation to {1}", gameObject.name, name));
            Animation anim = _animations.Find((Animation a) => a.Name == name);

            if (anim == null)
                return;

            _current = anim;
            startTime = currentTime;
            UpdateSprite(currentTime);
        }

        private void UpdateSprite(double time)
        {
            currentTime = time;
            _renderer.sprite = _current.Get(currentTime - startTime);
        }
    }
}
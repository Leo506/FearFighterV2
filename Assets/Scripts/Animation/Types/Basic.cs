using UnityEngine.Events;
using UnityEngine;
using Core.Loop;

namespace Core.Animation
{
    [CreateAssetMenu(fileName = "New Animation", menuName = "Animations/Basic")]
    public class Basic : Animation
    {
        [SerializeField] private Sprite[] _sprites;

        public override Sprite Get(double time)// Проверить работоспособность
        {
            long frame = (long)(time * FPS);
            //Debug.Log(string.Join(" ", frame, _sprites.Length));
            return _sprites[frame % _sprites.Length];
        }
    }
}
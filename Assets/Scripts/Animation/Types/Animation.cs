using UnityEngine;

namespace Core.Animation
{
    public class Animation : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private int _fps;

        public string Name => _name;
        public int FPS => _fps;

        public virtual Sprite Get(double time)
        {
            return null;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Entities
{
    [System.Serializable]
    public class Stats
    {
#if UNITY_EDITOR
        private const string healthTooltip = "Сила - отвечает за количество здоровья у персонажа";
        private const string speedTooltip = "Ловкость - отвечает за скорость передвижения персонажа";
        private const string armorTooltip = "Броня - отвечает за сопротивление урону персонажа ";
        private const string damageTooltip = "Базовый урон - отвечает за базовый урон персонажа";
        private const string critChanceTooltip = "Шанс критического урона - определяет базовый шанс критического урона (от 0 до 100)";
        private const string critDamageTooltip = "Урон критического удара - определяет урон, который наносит крит (после всех модификаторов)";
#endif

        [Header("Stats")]

#if UNITY_EDITOR
        [Tooltip(healthTooltip)]
#endif
        [SerializeField] private int _health;

#if UNITY_EDITOR
        [Tooltip(speedTooltip)]
#endif
        [SerializeField] private int _speed;

#if UNITY_EDITOR
        [Tooltip(armorTooltip)]
#endif
        [SerializeField] private int _armor;

#if UNITY_EDITOR
        [Tooltip(damageTooltip)]
#endif
        [SerializeField] private int _damage;

#if UNITY_EDITOR
        [Tooltip(critChanceTooltip)]
#endif
        [SerializeField] [Range(0, 100)] private int _critChance;

#if UNITY_EDITOR
        [Tooltip(critDamageTooltip)]
#endif
        [SerializeField] private int _critDamage;

        public int Health => _health;
        public int Speed => _speed;
        public int Armor => _armor;
        public int Damage => _damage;
        public int CritChance => _critChance;
        public int CritDamage => _critDamage;

        public Stats(int health, int speed, int armor, int damage, int critChance, int critDamage)
        {
            _health = health;
            _speed = speed;
            _armor = armor;
            _damage = damage;
            _critChance = critChance;
            _critDamage = critDamage;
        }
        public Stats()
        {
            _health = 0;
            _speed = 0;
            _armor = 0;
            _damage = 0;
            _critChance = 0;
            _critDamage = 0;
        }

        public void Normalize()
        {
            _health = Mathf.Max(_health, 1);
            _speed = Mathf.Clamp(_speed, 1, 10);
            _damage = Mathf.Max(_damage, 0);
            _critChance = Mathf.Clamp(_critChance, 1, 100);
            _critDamage = Mathf.Max(_critChance, 1);
        }
        public static Stats Combine(params Stats[] stats)
        {
            int health = stats[0].Health;
            int speed = stats[0].Speed;
            int armor = stats[0].Armor;
            int damage = stats[0].Damage;
            int critChance = stats[0].CritChance;
            int critDamage = stats[0].CritDamage;

            for (int i = 1; i < stats.Length; i++)
            {
                health += stats[i].Health;
                speed += stats[i].Speed;
                armor += stats[i].Armor;
                damage += stats[i].Damage;
                critChance += stats[i].CritChance;
                critDamage += stats[i].CritDamage;
            }

            return new Stats(health, speed, armor, damage, critChance, critDamage);
        }

        public static Stats operator +(Stats stats1, Stats stats2)
        {
            int health = stats1.Health + stats2.Health;
            int speed = stats1.Speed + stats2.Speed;
            int armor = stats1.Armor + stats2.Armor;
            int damage = stats1.Damage + stats2.Damage;
            int critChance = stats1.CritChance + stats2.CritChance;
            int critDamage = stats1.CritDamage + stats2.CritDamage;
            return new Stats(health, speed, armor, damage, critChance, critDamage);
        }
        public static Stats operator -(Stats stats1, Stats stats2)
        {
            int health = stats1.Health - stats2.Health;
            int speed = stats1.Speed - stats2.Speed;
            int armor = stats1.Armor - stats2.Armor;
            int damage = stats1.Damage - stats2.Damage;
            int critChance = stats1.CritChance - stats2.CritChance;
            int critDamage = stats1.CritDamage - stats2.CritDamage;
            return new Stats(health, speed, armor, damage, critChance, critDamage);
        }
    }
}
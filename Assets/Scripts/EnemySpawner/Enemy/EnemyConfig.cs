using FightingSim.Assets.Scripts.Infrastructure;
using UnityEngine;

namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy
{
    [CreateAssetMenu(fileName = "Enemy Config", menuName = "Fight Sim/Config/Enemy")]
    public class EnemyConfig : Config
    {
        [SerializeField] private float _maxHealth;

        public float MaxHealth => _maxHealth;
    }

}
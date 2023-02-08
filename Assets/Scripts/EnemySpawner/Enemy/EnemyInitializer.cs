using FightingSim.Assets.Scripts.Infrastructure.Configs;
using FightingSim.Assets.Scripts.Weapons.WeaponSubcontainer;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy
{
    public class EnemyInitializer
    {
        private readonly DiContainer _container;
        private readonly EnemyConfig _config;
        private readonly Transform _transform;

        public EnemyInitializer(DiContainer container, EnemyConfig config, Transform transform)
        {
            _container = container;
            _config = config;
            _transform = transform;
            _container.InstantiatePrefab(_config.Prefab, _transform);
        }

    }
}

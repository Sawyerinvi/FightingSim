using FightingSim.Assets.Scripts.Infrastructure.Configs;
using UnityEngine;
using Zenject;

namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy
{
    public class EnemyInitializer : IInitializable
    {
        private readonly DiContainer _container;
        private readonly EnemyConfig _config;
        private readonly Animator _animator;

        public EnemyInitializer(DiContainer container, EnemyConfig config, Animator animator)
        {
            _container = container;
            _config = config;
            _animator = animator;
        }

        public void Initialize()
        {
            var obj = _container.InstantiatePrefab(_config.Prefab);
            _animator.runtimeAnimatorController = _config.AnimatorController;
        }
    }
}

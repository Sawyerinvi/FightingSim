using System;
using UnityEngine;
using Zenject;

namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy
{
    public class EnemyFacade
    {
        private readonly CurrentStats _currentStats;
        private readonly Transform _transform;

        public event Action<EnemyFacade> OnDeath;

        public EnemyFacade(Transform transform, CurrentStats currentStats)
        {

            _transform = transform;
            _currentStats = currentStats;

            _currentStats.OnDeath += EnemyDeath;
        }
        public void SetPosition(Vector3 position)
        {
            _transform.position = position;
        }

        private void EnemyDeath()
        {
            OnDeath?.Invoke(this);
            DestroySelf();
        }

        private void DestroySelf()
        {
            UnityEngine.Object.Destroy(_transform.gameObject);
        }

        public class Factory : PlaceholderFactory<EnemyFacade>
        {

        }

    }
}
using FightingSim.Assets.Scripts.Infrastructure;
using FightingSim.Assets.Scripts.Infrastructure.Configs;
using FightingSim.Assets.Scripts.Player;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy
{
    public class EnemyNavigation : IFixedTickable
    {
        private readonly PlayerFacade _player;
        private readonly EnemyConfig _config;
        private readonly Transform _transform;
        private float _elapsedTime;

        public EnemyNavigation(PlayerFacade player, EnemyConfig config, Transform transform)
        {
            _player = player;
            _config = config;
            _transform = transform;
        }

        public void FixedTick()
        {
            LookForPlayer();
        }

        private void LookForPlayer()
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime < _config.OverlapshpereTime) return;
            _elapsedTime = 0f;
            Collider[] colliders = Physics.OverlapSphere(_transform.position, _config.SphereSearchRadius);
            foreach(var collider in colliders)
            {
                if(collider.gameObject.TryGetComponent<ICollisionFacade<PlayerFacade>>(out var facade))
                {
                    
                }
            }
        }
    }
}

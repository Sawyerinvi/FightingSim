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
        private readonly EnemyBehaviourStation _behaviourStation;
        private float _elapsedTime;

        public EnemyNavigation(PlayerFacade player, EnemyConfig config, Transform transform, EnemyBehaviourStation behaviourStation)
        {
            _player = player;
            _config = config;
            _transform = transform;
            _behaviourStation = behaviourStation;
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
                if(collider.gameObject.TryGetComponent<ICollisionFacade<PlayerFacade>>(out _))
                {
                    EnemyAction();
                    return;
                }
            }
            _behaviourStation.Idle();
        }
        private void EnemyAction()
        {
            var distance = Vector3.Distance(_player.PlayerPosition, _transform.position);
            if(distance <= _config.AttackDistance)
            {
                _behaviourStation.Attack();
            }
            else
            {
                _behaviourStation.MoveToAttack();
            }
        }
    }
}

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

        private bool _isPlayerFound;
        private bool _isFacingPlayer;
        private bool _isInAttackRange;
        public EnemyNavigation(PlayerFacade player, EnemyConfig config, Transform transform, EnemyBehaviourStation behaviourStation)
        {
            _player = player;
            _config = config;
            _transform = transform;
            _behaviourStation = behaviourStation;
        }

        public void FixedTick()
        {
            ActionTimer();
            _isFacingPlayer = RotationCheck();
            _isInAttackRange = DistanceCheck();
            Attack();
            Rotate();
        }

        private void ActionTimer()
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime < _config.OverlapshpereTime) return;

            _isPlayerFound = LookForPlayer();
            Move();
        }
        
        private void Attack()
        {
            if (_isPlayerFound == false) return;
            if (_isInAttackRange == false) return;
            if (_isFacingPlayer == false) return;
            _behaviourStation.Attack();
        }
        private void Move()
        {
            if (_isPlayerFound == false) return;
            if (_isInAttackRange) return;
            _behaviourStation.Move();
        }
        private void Rotate()
        {
            if (_isPlayerFound == false) return;
            if (_isInAttackRange == false) return;
            if (_isFacingPlayer) return;
            _behaviourStation.Rotate();
        }
        
        private bool LookForPlayer()
        {
            Collider[] colliders = Physics.OverlapSphere(_transform.position, _config.SphereSearchRadius);
            foreach (var collider in colliders)
            {
                if (collider.gameObject.TryGetComponent<ICollisionFacade<PlayerFacade>>(out _))
                {
                    return true;
                }
            }
            return false;
        }
        private bool RotationCheck()
        {
            Vector3 direction = (_player.PlayerPosition - _transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);

            if (Mathf.Abs(lookRotation.eulerAngles.y - _transform.rotation.eulerAngles.y) >= _config.AttackAngle) return false;
            return true;
        }
        private bool DistanceCheck()
        {
            var distance = Vector3.Distance(_player.PlayerPosition, _transform.position);
            if (distance > _config.AttackDistance)
            {
                return false;
            }
            return true;

        }
    }
}

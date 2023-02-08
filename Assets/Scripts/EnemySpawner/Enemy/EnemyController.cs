using FightingSim.Assets.Scripts.EnemySpawner.Enemy.Animations;
using FightingSim.Assets.Scripts.Infrastructure.Configs;
using FightingSim.Assets.Scripts.Player;
using System;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy
{
    public class EnemyController 
    {
        private readonly PlayerFacade _player;
        private NavMeshAgent _navMeshAgent;
        private readonly Transform _transform;
        private readonly EnemyAnimationController _animationController;

        public EnemyController(PlayerFacade player, EnemyAnimationController animationController, NavMeshAgent navMeshAgent, Transform transform)
        {
            _player = player;
            _animationController = animationController;
            _navMeshAgent = navMeshAgent;
            _transform = transform;
        }
        
        public void MoveToPlayer()
        {
            _navMeshAgent.isStopped = false;
            _navMeshAgent.SetDestination(_player.PlayerPosition);
        }
        public void Idle()
        {
            
        }
        public void Attack(Action callback)
        {
            _navMeshAgent.isStopped = true;
            _animationController.Attack(callback);
        }
        public void RotateToPlayer()
        {
            Vector3 direction = (_player.PlayerPosition - _transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            _transform.rotation = Quaternion.RotateTowards(_transform.rotation, lookRotation, Time.fixedDeltaTime * _navMeshAgent.angularSpeed);
        }
        
    }
}

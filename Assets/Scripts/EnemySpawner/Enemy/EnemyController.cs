using FightingSim.Assets.Scripts.EnemySpawner.Enemy.Animations;
using FightingSim.Assets.Scripts.Player;
using System;
using UnityEngine.AI;

namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy
{
    public class EnemyController
    {
        private readonly PlayerFacade _player;
        private readonly NavMeshAgent _navMeshAgent;
        private readonly EnemyAnimationController _animationController;

        public EnemyController(PlayerFacade player, NavMeshAgent navMeshAgent, EnemyAnimationController animationController)
        {
            _player = player;
            _navMeshAgent = navMeshAgent;
            _animationController = animationController;
        }

        public void MoveToPlayer()
        {
            _navMeshAgent.SetDestination(_player.PlayerPosition);
        }
        public void Idle()
        {
            _navMeshAgent.isStopped = true;
        }
        public void Attack(Action callback)
        {
            _animationController.Attack(callback);
        }
    }
}

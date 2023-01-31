using FightingSim.Assets.Scripts.EnemySpawner.Enemy.Animations;
using FightingSim.Assets.Scripts.EnemySpawner.Enemy.Animations.States;
using FightingSim.Assets.Scripts.Infrastructure.Configs;
using FightingSim.Assets.Scripts.Player;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy
{
    public class EnemyBehaviourStation : IEnemyStateSwitcher
    {
        private EnemyBaseState _currentState;
        private List<EnemyBaseState> _allStates;
        private readonly Transform _transform;
        private readonly PlayerFacade _player;
        private readonly EnemyConfig _config;
        private readonly EnemyController _enemyController;

        public EnemyBehaviourStation(Transform transform, PlayerFacade player, EnemyConfig config, EnemyController enemyController)
        {
            _transform = transform;
            _player = player;
            _config = config;
            _enemyController = enemyController;
            _allStates = new List<EnemyBaseState>()
            {
                new AttackState(this, _config, _enemyController),
                new IdleState(this, _config, _enemyController),
                new RoamState(this, _config, _enemyController),
                new MoveToAttackState(this, _config, _enemyController)
            };
            SwitchState<IdleState>();
        }

        public void Idle()
        {
            _currentState.Idle();
        }
        public void Attack()
        {
            _currentState.StartAttack();
        }
        public void MoveToAttack()
        {
            _currentState.MoveToAttack();
        }
        public void Roam()
        {
            _currentState.Roam();
        }

        public void SwitchState<T>() where T : EnemyBaseState
        {
            _currentState = _allStates.FirstOrDefault(s => s is T);
        }
    }
}

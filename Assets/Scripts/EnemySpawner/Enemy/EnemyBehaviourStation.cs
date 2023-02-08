using FightingSim.Assets.Scripts.EnemySpawner.Enemy.Animations.States;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy
{
    public class EnemyBehaviourStation : IStateSwitcher
    {
        private EnemyBaseState _currentState;
        private List<EnemyBaseState> _allStates;
        private readonly EnemyController _enemyController;

        public EnemyBehaviourStation(EnemyController enemyController)
        {
            _enemyController = enemyController;
            _allStates = new List<EnemyBaseState>{
                new IdleState(this, _enemyController),
                new AttackState(this, _enemyController),
                new RotateState(this, _enemyController),
                new MoveState(this, _enemyController)
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
        public void Move()
        {
            _currentState.Move();
        }
        public void Rotate()
        {
            _currentState.Rotate();
        }

        public void SwitchState<T>() where T : EnemyBaseState
        {
            _currentState = _allStates.FirstOrDefault(s => s is T);
        }
    }
}

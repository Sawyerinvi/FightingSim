using FightingSim.Assets.Scripts.EnemySpawner.Enemy.Animations.States;
using FightingSim.Assets.Scripts.Player.Animations;
using System.Collections.Generic;
using System.Linq;


namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy.Animations
{
    public class MovementStationBehaviour : IEnemyStateSwitcher
    {
        private EnemyBaseState _currentState;
        private List<EnemyBaseState> _allStates;
        public MovementStationBehaviour()
        {
            _allStates = new List<EnemyBaseState>()
            {
                new AttackState(this),
                new IdleState(this),
                new RoamState(this),
                new MoveToAttackState(this)
            };
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

using FightingSim.Assets.Scripts.Infrastructure.Configs;
using FightingSim.Assets.Scripts.Player;
using UnityEngine;

namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy.Animations.States
{
    class IdleState : EnemyBaseState
    {
        public IdleState(IStateSwitcher stateSwitcher, EnemyController enemyController) : base(stateSwitcher, enemyController)
        {
        }

        public override void Move()
        {
            _enemyController.MoveToPlayer();
            _stateSwitcher.SwitchState<MoveState>();
        }

        public override void Idle()
        {
            _enemyController.Idle();
        }

        public override void Rotate()
        {
            _enemyController.RotateToPlayer();
            _stateSwitcher.SwitchState<RotateState>();
        }
        public override void StartAttack()
        {
            _enemyController.Attack(EndAttack);
            _stateSwitcher.SwitchState<AttackState>();
        }

        public override void EndAttack()
        {
            _stateSwitcher.SwitchState<IdleState>();
        }
    }
}

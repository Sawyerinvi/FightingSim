using FightingSim.Assets.Scripts.Infrastructure.Configs;

namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy.Animations.States
{
    class RotateState : EnemyBaseState
    {
        public RotateState(IStateSwitcher stateSwitcher, EnemyController enemyController) : base(stateSwitcher, enemyController)
        {
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

        public override void Move()
        {
            _enemyController.MoveToPlayer();
            _stateSwitcher.SwitchState<MoveState>();
        }

        public override void Idle()
        {
            _enemyController.Idle();
            _stateSwitcher.SwitchState<IdleState>();
        }


        public override void Rotate()
        {
            _enemyController.RotateToPlayer();
        }
    }
}

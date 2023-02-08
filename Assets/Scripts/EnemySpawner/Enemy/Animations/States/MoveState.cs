using FightingSim.Assets.Scripts.Infrastructure.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy.Animations.States
{
    class MoveState : EnemyBaseState
    {
        public MoveState(IStateSwitcher stateSwitcher, EnemyController enemyController) : base(stateSwitcher, enemyController)
        {
        }

        public override void Move()
        {
            _enemyController.MoveToPlayer();
        }

        public override void Idle()
        {
            _enemyController.Idle();
            _stateSwitcher.SwitchState<IdleState>();
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

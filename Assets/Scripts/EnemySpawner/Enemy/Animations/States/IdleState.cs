using FightingSim.Assets.Scripts.Infrastructure.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy.Animations.States
{
    class IdleState : EnemyBaseState
    {
        public IdleState(IEnemyStateSwitcher stateSwitcher, EnemyConfig config, EnemyController animationController) : base(stateSwitcher, config, animationController)
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

        public override void MoveToAttack()
        {
            _enemyController.MoveToPlayer();
        }

        public override void Idle()
        {
            _enemyController.Idle();
        }

        public override void Roam()
        {
        }
    }
}

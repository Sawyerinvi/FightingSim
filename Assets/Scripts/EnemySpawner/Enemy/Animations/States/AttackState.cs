using FightingSim.Assets.Scripts.Infrastructure.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy.Animations.States
{
    class AttackState : EnemyBaseState
    {
        public AttackState(IEnemyStateSwitcher stateSwitcher, EnemyConfig config, EnemyController animationController) : base(stateSwitcher, config, animationController)
        {
        }

        public override void StartAttack()
        {
        }

        public override void EndAttack()
        {
        }

        public override void MoveToAttack()
        {
        }

        public override void Idle()
        {
        }

        public override void Roam()
        {
        }
    }
}

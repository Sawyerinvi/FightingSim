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
        public AttackState(IStateSwitcher stateSwitcher, EnemyController enemyController) : base(stateSwitcher, enemyController)
        {
        }

        public override void Move()
        {
        }
        public override void Idle()
        {
        }
        public override void Rotate()
        {
        }
        public override void StartAttack()
        {
        }

        public override void EndAttack()
        {
        }
    }
}

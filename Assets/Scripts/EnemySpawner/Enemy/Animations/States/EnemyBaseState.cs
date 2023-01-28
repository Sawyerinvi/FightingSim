using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy.Animations.States
{
    public abstract class EnemyBaseState
    {
        private readonly IEnemyStateSwitcher _stateSwitcher;

        protected EnemyBaseState(IEnemyStateSwitcher stateSwitcher)
        {
            _stateSwitcher = stateSwitcher;
        }

        public abstract void StartAttack();
        public abstract void EndAttack();
        public abstract void MoveToAttack();
        public abstract void Idle();
        public abstract void Roam();
    }
}

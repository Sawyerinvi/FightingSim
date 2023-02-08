using FightingSim.Assets.Scripts.Infrastructure.Configs;

namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy.Animations.States
{
    public abstract class EnemyBaseState
    {
        protected readonly IStateSwitcher _stateSwitcher;
        protected readonly EnemyController _enemyController;

        public EnemyBaseState(IStateSwitcher stateSwitcher, EnemyController enemyController)
        {
            _stateSwitcher = stateSwitcher;
            _enemyController = enemyController;
        }

        public abstract void Move();
        public abstract void Idle();
        public abstract void Rotate();
        public abstract void StartAttack();
        public abstract void EndAttack();
        
    }
}

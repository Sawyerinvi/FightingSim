using FightingSim.Assets.Scripts.Infrastructure.Configs;

namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy.Animations.States
{
    public abstract class EnemyBaseState
    {
        protected readonly IEnemyStateSwitcher _stateSwitcher;
        protected readonly EnemyConfig _config;
        protected readonly EnemyController _enemyController;

        protected EnemyBaseState(IEnemyStateSwitcher stateSwitcher, EnemyConfig config, EnemyController animationController)
        {
            _stateSwitcher = stateSwitcher;
            _config = config;
            _enemyController = animationController;
        }


        public abstract void StartAttack();
        public abstract void EndAttack();
        public abstract void MoveToAttack();
        public abstract void Idle();
        public abstract void Roam();
    }
}

using FightingSim.Assets.Scripts.EnemySpawner.Enemy.Animations.States;

namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy.Animations
{
    public interface IEnemyStateSwitcher
    {
        public void SwitchState<T>() where T : EnemyBaseState;
    }
}

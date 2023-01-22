using Zenject;

namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy
{
    public class EnemyInitializer : IInitializable
    {
        private const string _enemyPath = "Prefab/NPC/Dummy";
        private readonly DiContainer _container;

        public EnemyInitializer(DiContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _container.InstantiatePrefabResource(_enemyPath);
        }
    }
}

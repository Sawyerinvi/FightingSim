using FightingSim.Assets.Scripts.Infrastructure.Configs;
using Zenject;

namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy
{
    public class EnemyInitializer : IInitializable
    {
        private readonly DiContainer _container;
        private readonly EnemyConfig _config;

        public EnemyInitializer(DiContainer container, EnemyConfig config)
        {
            _container = container;
            _config = config;
        }

        public void Initialize()
        {
            _container.InstantiatePrefab(_config.Prefab);
        }
    }
}

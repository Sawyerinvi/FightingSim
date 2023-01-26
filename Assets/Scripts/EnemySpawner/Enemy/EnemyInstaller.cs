using FightingSim.Assets.Scripts.Infrastructure.Configs;
using UnityEngine;
using Zenject;

namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy
{
    public class EnemyInstaller : Installer<EnemyInstaller>
    {
        [Inject]
        private EnemyConfig _config;
        public override void InstallBindings()
        {
            Container.Bind<EnemyConfig>().FromInstance(_config).AsSingle();
            Container.Bind<Transform>().FromComponentOnRoot().AsSingle();
            Container.BindInterfacesAndSelfTo<CurrentStats>().AsSingle();
            Container.Bind<EnemyFacade>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyInitializer>().AsSingle();
            
        }
    }
}

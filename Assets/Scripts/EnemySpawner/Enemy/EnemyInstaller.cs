using FightingSim.Assets.Scripts.EnemySpawner.Enemy.Animations;
using FightingSim.Assets.Scripts.EnemySpawner.Enemy.Animations.States;
using FightingSim.Assets.Scripts.Infrastructure.Configs;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy
{
    public class EnemyInstaller : Installer<EnemyInstaller>
    {
        [Inject]
        private EnemyConfig _config;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EnemyInitializer>().AsSingle().NonLazy();

            Container.Bind<EnemyFacade>().AsSingle();
            Container.Bind<EnemyConfig>().FromInstance(_config).AsSingle();
            Container.BindInterfacesAndSelfTo<CurrentStats>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyNavigation>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyController>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyAnimationController>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyBehaviourStation>().AsSingle();

            Container.Bind<Transform>().FromComponentOnRoot().AsSingle();
            Container.Bind<NavMeshAgent>().FromComponentOnRoot().AsSingle();

            
        }
    }
}

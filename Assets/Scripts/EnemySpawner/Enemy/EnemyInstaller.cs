using FightingSim.Assets.Scripts.EnemySpawner.Enemy.Animations;
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
            Container.Bind<EnemyFacade>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyInitializer>().AsSingle();
            Container.Bind<EnemyConfig>().FromInstance(_config).AsSingle();
            Container.BindInterfacesAndSelfTo<CurrentStats>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyNavigation>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyBehaviourStation>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyController>().AsSingle();
            Container.Bind<EnemyAnimationController>().AsSingle();

            Container.Bind<Transform>().FromComponentOnRoot().AsSingle();
            Container.Bind<NavMeshAgent>().FromComponentOnRoot().AsSingle();
            Container.Bind<Animator>().FromComponentOnRoot().AsSingle();
            Container.BindInterfacesAndSelfTo<HitHandler>().FromComponentOnRoot();
        }
    }
}

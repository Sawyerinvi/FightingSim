using UnityEngine;
using Zenject;

namespace FightingSim.Assets.Scripts.EnemySpawner.Enemy
{
    public class EnemyInstaller : Installer<EnemyInstaller>
    {
        
        public override void InstallBindings()
        {
            Container.Bind<Transform>().FromComponentOnRoot().AsSingle();
            Container.BindInterfacesAndSelfTo<CurrentStats>().AsSingle();
            Container.Bind<EnemyFacade>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyInitializer>().AsSingle();
            
        }
    }
}

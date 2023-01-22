using FightingSim.Assets.Scripts.EnemySpawner.Enemy;
using UnityEngine;
using Zenject;

namespace FightingSim.Assets.Scripts.EnemySpawner
{
    public class SpawnerInstaller : Installer<SpawnerInstaller>
    {
        private const string _enemySpawnPointsPath = "Prefab/NPC/Spawners/Enemy/Enemy Spawn Points";
        public override void InstallBindings()
        {
            Container.BindFactory<EnemyFacade, EnemyFacade.Factory>().FromSubContainerResolve().ByNewGameObjectInstaller<EnemyInstaller>().WithGameObjectName("Enemy");
            Container.Bind<EnemySpawnPoints>().FromScriptableObjectResource(_enemySpawnPointsPath).AsSingle();

            Container.Bind<EnemySpawnerFacade>().AsSingle();
            Container.Bind<SpawnerContent>().AsSingle();
            Container.BindInterfacesAndSelfTo<Spawner>().AsSingle();
            

            Container.Bind<string>().FromInstance("Dummy 1");
        }
    }


}
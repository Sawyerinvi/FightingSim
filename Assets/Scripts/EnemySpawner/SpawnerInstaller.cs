using FightingSim.Assets.Scripts.EnemySpawner.Enemy;
using FightingSim.Assets.Scripts.Infrastructure.Configs;
using UnityEngine;
using Zenject;

namespace FightingSim.Assets.Scripts.EnemySpawner
{
    public class SpawnerInstaller : Installer<SpawnerInstaller>
    {
        private const string _enemySpawnPointsPath = "Prefab/NPC/Spawners/Enemy/Enemy Spawn Points";
        private const string _enemyWrapperPath = "Prefab/NPC/Spawners/Enemy/Enemy Wrapper";

        public override void InstallBindings()
        {
            Container.BindFactory<EnemyConfig, EnemyFacade, EnemyFacade.Factory>().FromSubContainerResolve().
                ByNewPrefabResourceInstaller<EnemyInstaller>(_enemyWrapperPath).AsSingle();
            Container.Bind<EnemySpawnPoints>().FromScriptableObjectResource(_enemySpawnPointsPath).AsSingle();

            Container.Bind<EnemySpawnerFacade>().AsSingle();
            Container.Bind<SpawnerContent>().AsSingle();
            Container.BindInterfacesAndSelfTo<Spawner>().AsSingle();
            

            Container.Bind<string>().FromInstance("Dummy 1");
        }
    }


}
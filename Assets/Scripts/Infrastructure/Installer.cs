using Zenject;
using UnityEngine;
using FightingSim.Assets.Scripts.Player;
using FightingSim.Assets.Scripts.UI;
using FightingSim.Assets.Scripts.EnemySpawner;
using FightingSim.Assets.Scripts.Weapons.WeaponSubcontainer;
using FightingSim.Assets.Scripts.Infrastructure.Configs;
using FightingSim.Assets.Scripts.Infrastructure.ConfigList;

namespace FightingSim.Assets.Scripts.Infrastructure
{
    public class Installer : MonoInstaller
    {
        [SerializeField] private AsyncProcessor _asycnProcessor;

        private GameObject _playerPrefab;
        private GameObject _uiPrefab;
        private GameObject _enemySpawner;
        private ConfigManager _configProvider;
        private WeaponDataAsset _weaponDataAsset;
        

        private const string _playerPrefabPath = "Prefab/Player/Player";
        private const string _uiPrefabPath = "Prefab/UI/Canvas";
        private const string _enemySpawnerPath = "Prefab/NPC/Spawners/Enemy/Enemy Spawner";
        private const string _configProviderPath = "Config Manager";

        public override void InstallBindings()
        {
            Load();
            Container.BindInterfacesAndSelfTo<UIFacade>().FromSubContainerResolve().ByNewPrefabInstaller<UIInstaller>(_uiPrefab).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerFacade>().FromSubContainerResolve().ByNewPrefabInstaller<PlayerInstaller>(_playerPrefab).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<EnemySpawnerFacade>().FromSubContainerResolve().ByNewPrefabInstaller<SpawnerInstaller>(_enemySpawner).AsSingle().NonLazy();
            Container.BindFactory<IWeaponConfig, Weapon, Weapon.Factory>().FromSubContainerResolve().ByNewGameObjectInstaller<WeaponInstaller>().AsSingle();

            Container.Bind<AsyncProcessor>().FromInstance(_asycnProcessor).AsSingle();
            Container.Bind<ConfigManager>().FromInstance(_configProvider).AsSingle();
            
        }
        private void Load()
        {
            _playerPrefab = Resources.Load(_playerPrefabPath) as GameObject;
            _uiPrefab = Resources.Load(_uiPrefabPath) as GameObject;
            _enemySpawner = Resources.Load(_enemySpawnerPath) as GameObject;
            _configProvider = Resources.Load(_configProviderPath) as ConfigManager;
        }
    }
}


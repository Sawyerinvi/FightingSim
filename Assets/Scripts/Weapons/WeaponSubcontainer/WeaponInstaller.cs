using FightingSim.Assets.Scripts.Infrastructure.Configs;
using UnityEngine;
using Zenject;

namespace FightingSim.Assets.Scripts.Weapons.WeaponSubcontainer
{
    public class WeaponInstaller : Installer<WeaponInstaller>
    {
        [Inject]
        private IWeaponConfig _weaponConfig;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<WeaponInitializer>().AsSingle();
            Container.BindInterfacesAndSelfTo<Weapon>().AsSingle();
            Container.Bind<IWeaponConfig>().FromInstance(_weaponConfig).AsSingle();
            Container.Bind<Transform>().FromComponentOnRoot().AsSingle();
        }
    }
}

using FightingSim.Assets.Scripts.Player.Animations;
using UnityEngine;
using Zenject;

namespace FightingSim.Assets.Scripts.Player
{
    public class PlayerInstaller : Installer<PlayerInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerFacade>().AsSingle();
            Container.Bind<PlayerWeaponInventory>().AsSingle();
            Container.BindInterfacesAndSelfTo<TargetSelect>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerControl>().AsSingle();
            Container.BindInterfacesAndSelfTo<CameraMovement>().AsSingle();
            Container.Bind<PlayerAnimationController>().AsSingle();
            Container.Bind<MovementStationBehaviour>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputHandler>().AsSingle();
            Container.Bind<PlayerAnimationSet>().AsSingle();

            Container.Bind<Animator>().FromComponentOnRoot().AsSingle();
            Container.Bind<Rigidbody>().FromComponentOnRoot().AsSingle();
            Container.Bind<Transform>().FromComponentOnRoot().AsSingle();
            Container.Bind<Camera>().FromInstance(Camera.main).AsSingle();

            
        }
    }
}
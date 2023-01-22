using Zenject;

namespace FightingSim.Assets.Scripts.UI
{
    public class UIInstaller : Installer<UIInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<UIFacade>().AsSingle();
        }
    }
}

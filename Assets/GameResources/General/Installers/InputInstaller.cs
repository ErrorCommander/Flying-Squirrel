using GameResources.Services.Input;
using Zenject;

namespace GameResources.General.Installers
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            IInputService input = new EditorInputServiceService();
            Container.Bind<IInputService>().FromInstance(input).AsSingle().NonLazy();
        }
    }
}
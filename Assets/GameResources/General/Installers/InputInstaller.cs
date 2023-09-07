using GameResources.Services.Input;
using UnityEngine;
using Zenject;

namespace GameResources.General.Installers
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            IInputService input = GetInputService();
            Container.Bind<IInputService>().FromInstance(input).AsSingle().NonLazy();
        }
        
        
        private IInputService GetInputService()
        {
            if (Application.isEditor)
                return new EditorInputServiceService();

            if (Application.isMobilePlatform)
                return new MobileInputServiceService();

            return new StandaloneInputServiceService();
        }
    }
}
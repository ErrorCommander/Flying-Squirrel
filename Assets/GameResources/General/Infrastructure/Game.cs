using GameResources.Services.Input;
using Zenject;

namespace GameResources.General.Infrastructure
{
   public class Game
   {
      private IInputService _inputService;
      private DiContainer _container;

      public Game(DiContainer container)
      {
         _container = container;
         RegisterInputService();
      }

      private void RegisterInputService()
      {
         _inputService = new EditorInputServiceService();
         _container.Bind<IInputService>().FromInstance(_inputService).AsSingle().NonLazy();
      }
   }
}
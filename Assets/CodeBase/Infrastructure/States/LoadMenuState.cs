using CodeBase.Services.Factory;
using CodeBase.UI;

namespace CodeBase.Infrastructure.States
{
   public class LoadMenuState : IState
   {
      private const string MENU_SCENE_NAME = "Menu";
      
      private readonly SceneLoader _sceneLoader;
      private readonly IGameFactory _gameFactory;
      private readonly IUIFactory _uiFactory;

      public LoadMenuState(SceneLoader sceneLoader, IGameFactory gameFactory, IUIFactory uiFactory)
      {
         _sceneLoader = sceneLoader;
         _gameFactory = gameFactory;
         _uiFactory = uiFactory;
      }

      public void Enter()
      {
         _sceneLoader.Load(MENU_SCENE_NAME, OnLoaded);
      }

      public void Exit()
      {
      }

      private void OnLoaded()
      {
         _uiFactory.CreateMenu(WindowType.MainMenu);
      }
   }
}
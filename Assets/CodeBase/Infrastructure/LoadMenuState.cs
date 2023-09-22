using CodeBase.Services.Factory;

namespace CodeBase.Infrastructure
{
   public class LoadMenuState : IState
   {
      private const string MENU_SCENE_NAME = "Menu";
      
      private readonly SceneLoader _sceneLoader;
      private readonly IGameFactory _gameFactory;

      public LoadMenuState(SceneLoader sceneLoader, IGameFactory gameFactory)
      {
         _sceneLoader = sceneLoader;
         _gameFactory = gameFactory;
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
         _gameFactory.CreateMainMenu();
      }
   }
}
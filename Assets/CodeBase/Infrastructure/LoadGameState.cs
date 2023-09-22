using CodeBase.Services.Factory;
using UnityEngine;

namespace CodeBase.Infrastructure
{
   public class LoadGameState : IPayloadState<string>
   {
      private readonly SceneLoader _sceneLoader;
      private readonly IGameFactory _gameFactory;

      public LoadGameState(SceneLoader sceneLoader, IGameFactory gameFactory)
      {
         _sceneLoader = sceneLoader;
         _gameFactory = gameFactory;
      }

      public void Enter(string name)
      {
         _sceneLoader.Load(name, OnLoaded);
      }

      public void Exit()
      {
      }

      private void OnLoaded()
      {
         var hero = _gameFactory.CreateHero();
         var followCamera = _gameFactory.CreateFollowCamera(hero.transform);

         if (Application.isMobilePlatform || Application.isEditor)
         {
            _gameFactory.CreateMobileJoystick();
         }

         Debug.Log("Game Loaded");
      }
   }
}
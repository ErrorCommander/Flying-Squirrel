using Cinemachine;
using GameResources.Player;
using GameResources.Services.Factory;
using UnityEngine;
using Zenject;

namespace GameResources.General.Infrastructure
{
   public class LoadGameState : IPayloadState<string>
   {
      private readonly SceneLoader _sceneLoader;
      private readonly DiContainer _container;
      private readonly IGameFactory _gameFactory;

      public LoadGameState(SceneLoader sceneLoader, DiContainer container, IGameFactory gameFactory)
      {
         _sceneLoader = sceneLoader;
         _container = container;
         _gameFactory = gameFactory;
      }

      public DiContainer container
      {
         get { return _container; }
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
         Debug.Log("Game Loaded");
         var hero = _gameFactory.CreateHero();
         var followCamera = _gameFactory.CreateFollowCamera();
         followCamera.Follow = hero.transform;
         
         if (Application.isMobilePlatform || Application.isEditor)
         {
            _gameFactory.CreateMobileJoystick();
         }
      }
   }
}
using Cinemachine;
using GameResources.Player;
using UnityEngine;
using Zenject;

namespace GameResources.General.Infrastructure
{
   public class LoadGameState : IPayloadState<string>
   {
      private readonly SceneLoader _sceneLoader;
      private readonly DiContainer _container;

      public LoadGameState(SceneLoader sceneLoader, DiContainer container)
      {
         _sceneLoader = sceneLoader;
         _container = container;
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
         Debug.Log("On Loaded");
         var hero = Instantiate<PlayerMove>("Game/Hero");
         var followCamera = Instantiate<CinemachineVirtualCamera>("Game/FollowCamera");
         followCamera.Follow = hero.transform;
         
         if (Application.isMobilePlatform || Application.isEditor)
         {
            Instantiate("Game/MobileInput");
         }
      }
      
      private TValue Instantiate<TValue>(string path) where TValue : Component
      {
         var heroPrefab = Resources.Load<TValue>(path);
         return _container.InstantiatePrefabForComponent<TValue>(heroPrefab);
      }
      
      private GameObject Instantiate(string path)
      {
         var heroPrefab = Resources.Load<GameObject>(path);
         return Object.Instantiate(heroPrefab);
      }
   }
}
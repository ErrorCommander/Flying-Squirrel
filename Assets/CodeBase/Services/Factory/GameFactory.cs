using Cinemachine;
using CodeBase.Infrastructure;
using CodeBase.Player;
using CodeBase.Services.AssetProvider;
using CodeBase.UI;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace CodeBase.Services.Factory
{
   public class GameFactory : IGameFactory
   {
      private readonly DiContainer _container;
      private readonly IAssetProvider _assetProvider;

      public GameFactory(DiContainer container, IAssetProvider assetProvider)
      {
         _container = container;
         _assetProvider = assetProvider;
      }

      public PlayerMove CreateHero()
      {
         return Instantiate<PlayerMove>(AssetPath.HERO_PATH, Vector3.zero)
            .With(o => Inject<PlayerMove>(o));
      }

      public CinemachineVirtualCamera CreateFollowCamera(Transform target)
      {
         var camera = Instantiate<CinemachineVirtualCamera>(AssetPath.CAMERA_PATH);
         camera.Follow = target;
         return camera;
      }

      public GameObject CreateMobileJoystick()
      {
         return Instantiate(AssetPath.MOBILE_JOYSTICK_PATH);
      }

      public GameObject CreateMainMenu()
      {
         return Instantiate<LoadGameButton>(AssetPath.MAIN_MENU_PATH)
                .With(m => Inject(m)).gameObject;
      }

      private GameObject Instantiate(string prefabPath)
      {
         var prefab = _assetProvider.Load(prefabPath);
         return Object.Instantiate(prefab);
      }

      private GameObject Instantiate(string prefabPath, Vector3 at)
      {
         var prefab = _assetProvider.Load(prefabPath);
         return Object.Instantiate(prefab, at, Quaternion.identity);
      }

      private TValue Instantiate<TValue>(string prefabPath) where TValue : Component
      {
         TValue prefab = _assetProvider.LoadAs<TValue>(prefabPath);
         return Object.Instantiate(prefab);
      }

      private TValue Instantiate<TValue>(string prefabPath, Vector3 at) where TValue : Component
      {
         TValue prefab = _assetProvider.LoadAs<TValue>(prefabPath);
         return Object.Instantiate(prefab, at, Quaternion.identity);
      }

      private TValue Inject<TValue>(TValue instance) where TValue : Component
      {
         _container.Inject(instance);
         return instance;
      }
   }
}
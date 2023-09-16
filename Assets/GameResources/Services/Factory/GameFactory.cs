using Cinemachine;
using GameResources.Player;
using GameResources.Services.AssetProvider;
using UnityEngine;
using Zenject;

namespace GameResources.Services.Factory
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
         var playerPrefab = _assetProvider.LoadAs<PlayerMove>(AssetPath.HERO_PATH);
         var player = Object.Instantiate(playerPrefab, Vector3.zero, Quaternion.identity, null);
         _container.Inject(player);
         return player;
      }

      public CinemachineVirtualCamera CreateFollowCamera()
      {
         var camera = _assetProvider.LoadAs<CinemachineVirtualCamera>(AssetPath.CAMERA_PATH);
         return Object.Instantiate(camera);
      }

      public GameObject CreateMobileJoystick()
      {
         var mobileJoystick = _assetProvider.Load(AssetPath.MOBILE_JOYSTICK_PATH);
         return Object.Instantiate(mobileJoystick);
      }
   }
}
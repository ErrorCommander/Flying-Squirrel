using Cinemachine;
using GameResources.Player;
using GameResources.Services.AssetProvider;
using UnityEngine;

namespace GameResources.Services.Factory
{
   public class GameFactory : IGameFactory
   {
      private readonly IAssetProvider _assetProvider;

      public GameFactory(IAssetProvider assetProvider)
      {
         _assetProvider = assetProvider;
      }

      public PlayerMove CreateHero()
      {
         return _assetProvider.InstantiateAs<PlayerMove>(AssetPath.HERO_PATH);
      }

      public CinemachineVirtualCamera CreateFollowCamera()
      {
         return _assetProvider.InstantiateAs<CinemachineVirtualCamera>(AssetPath.CAMERA_PATH);
      }

      public GameObject CreateMobileJoystick()
      {
         return _assetProvider.Instantiate(AssetPath.MOBILE_JOYSTICK_PATH);
      }
   }
}
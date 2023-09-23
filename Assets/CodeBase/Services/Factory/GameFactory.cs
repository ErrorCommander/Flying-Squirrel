using Cinemachine;
using CodeBase.Infrastructure;
using CodeBase.Player;
using CodeBase.Services.AssetProvider;
using UnityEngine;
using Zenject;

namespace CodeBase.Services.Factory
{
   public class GameFactory : FactoryBase, IGameFactory
   {
      public GameFactory(DiContainer container, IAssetProvider assetProvider) : base(container, assetProvider) {}

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
   }
}
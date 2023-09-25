using Cinemachine;
using CodeBase.Player;
using CodeBase.Services.Asset;
using UnityEngine;
using Zenject;

namespace CodeBase.Services.Factory
{
   public class GameFactory : FactoryBase, IGameFactory
   {
      public GameFactory(DiContainer container, IAssetProvider assetProvider) : base(container, assetProvider) {}

      public HeroMove CreateHero()
      {
         return Instantiate<HeroMove>(AssetPath.HERO, Vector3.zero)
            .With(o => Inject<HeroMove>(o));
      }

      public CinemachineVirtualCamera CreateFollowCamera(Transform target)
      {
         var camera = Instantiate<CinemachineVirtualCamera>(AssetPath.CAMERA);
         camera.Follow = target;
         return camera;
      }
   }
}
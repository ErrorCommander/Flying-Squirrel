using CodeBase.Services.Asset;
using CodeBase.Services.Curtain;
using CodeBase.UI;
using UnityEngine;
using Zenject;

namespace CodeBase.Services.Factory
{
   public class UIFactory : FactoryBase, IUIFactory
   {
      public UIFactory(DiContainer container, IAssetProvider assetProvider) : base(container, assetProvider){}

      public GameObject CreateMobileJoystick() => Instantiate(AssetPath.MOBILE_JOYSTICK);

      public GameObject CreateMenu(WindowType windowType)
      {
         switch (windowType)
         {
            case WindowType.MainMenu:
               return Instantiate<LoadGameButton>(AssetPath.MAIN_MENU).With(m => Inject(m)).gameObject;
            default:
               return null;
         }
      }

      public LoadingCurtain CreateLoadingCurtain()
      {
         Debug.Log("LoadingCurtain");
         return Instantiate<LoadingCurtain>(AssetPath.LOADING_CURTAIN);
      }
   }
}
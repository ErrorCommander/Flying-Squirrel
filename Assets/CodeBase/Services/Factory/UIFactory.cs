using System;
using CodeBase.Infrastructure;
using CodeBase.Services.AssetProvider;
using CodeBase.UI;
using UnityEngine;
using Zenject;

namespace CodeBase.Services.Factory
{
   public class UIFactory : FactoryBase, IUIFactory
   {
      public UIFactory(DiContainer container, IAssetProvider assetProvider) : base(container, assetProvider){}

      public GameObject CreateMobileJoystick() => 
         Instantiate(AssetPath.MOBILE_JOYSTICK_PATH);

      public GameObject CreateMenu(WindowType windowType)
      {
         if (windowType == WindowType.Unknown || !Enum.IsDefined(typeof(WindowType), windowType))
            return null;

         string path = windowType switch
         {
            WindowType.MainMenu => AssetPath.MAIN_MENU_PATH,
            _ => ""
         };

         return Instantiate<LoadGameButton>(AssetPath.MAIN_MENU_PATH)
                .With(m => Inject(m))
                .gameObject;
      }
   }
}
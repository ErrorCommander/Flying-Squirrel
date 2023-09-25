using CodeBase.Services.Curtain;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Services.Factory
{
   public interface IUIFactory
   {
      GameObject CreateMobileJoystick();
      GameObject CreateMenu(WindowType windowType);
      LoadingCurtain CreateLoadingCurtain();
   }
}
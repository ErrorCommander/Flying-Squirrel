using UnityEngine;

namespace CodeBase.Services.Factory
{
   public interface IUIFactory
   {
      GameObject CreateMobileJoystick();
      GameObject CreateMenu(WindowType windowType);
   }

   public enum WindowType
   {
      Unknown = 0,
      MainMenu = 1
   }
}
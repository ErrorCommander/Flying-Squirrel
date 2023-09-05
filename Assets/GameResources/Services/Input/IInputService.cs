using UnityEngine;

namespace GameResources.Services.Input
{
   public interface IInputService
   {
      Vector2 Axis { get; }
      bool JumpPressed();
   }
}
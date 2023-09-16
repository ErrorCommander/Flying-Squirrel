using UnityEngine;

namespace GameResources.Services.Input
{
   public class StandaloneInputServiceService : BaseInputService
   {
      public override Vector2 Axis => GetUnityAxis();
      public override bool JumpPressed() => GetUnityJump();
   }
}
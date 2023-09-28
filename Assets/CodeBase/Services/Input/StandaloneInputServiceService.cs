using UnityEngine;

namespace CodeBase.Services.Input
{
   public class StandaloneInputServiceService : BaseInputService
   {
      public override Vector2 Axis => GetUnityAxis();
      public override bool JumpPressed() => GetUnityJumpPressed();
      public override bool JumpDown() => GetUnityJumpDown();
   }
}
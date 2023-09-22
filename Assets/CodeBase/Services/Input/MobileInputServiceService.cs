using UnityEngine;

namespace CodeBase.Services.Input
{
   public class MobileInputServiceService : BaseInputService
   {
      public override Vector2 Axis => GetUiInputAxis();
      public override bool JumpPressed() => GetUiInputJump();
   }
}
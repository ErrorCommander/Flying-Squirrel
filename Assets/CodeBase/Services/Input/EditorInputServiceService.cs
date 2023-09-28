using UnityEngine;

namespace CodeBase.Services.Input
{
   public class EditorInputServiceService : BaseInputService
   {
      public override Vector2 Axis
      {
         get
         {
            var input = GetUnityAxis();
            if (input == Vector2.zero)
            {
               input = GetUiInputAxis();
            }

            return input;
         }
      }

      public override bool JumpPressed() => GetUiInputJumpPressed() || GetUnityJumpPressed();
      public override bool JumpDown() => GetUiInputJumpDown() || GetUnityJumpDown();
   }
}
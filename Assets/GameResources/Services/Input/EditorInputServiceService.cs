using UnityEngine;

namespace GameResources.Services.Input
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

      public override bool JumpPressed() => GetUiInputJump() || GetUnityJump();
   }
}
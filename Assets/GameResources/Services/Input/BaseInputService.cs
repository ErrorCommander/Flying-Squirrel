using UnityEngine;

namespace GameResources.Services.Input
{
   public abstract class BaseInputService : IInputService
   {
      protected const string HORIZONTAL_AXIS = "Horizontal";
      protected const string VERTICAL_AXIS = "Vertical";
      protected const string JUMP_BUTTON = "Space";

      public abstract Vector2 Axis { get; }
      public abstract bool JumpPressed();

      protected Vector2 GetUnityAxis() =>
         new(UnityEngine.Input.GetAxis(HORIZONTAL_AXIS), 
             UnityEngine.Input.GetAxis(VERTICAL_AXIS));

      protected Vector2 GetUiInputAxis() =>
         new(SimpleInput.GetAxis(HORIZONTAL_AXIS), 
             SimpleInput.GetAxis(VERTICAL_AXIS));

      protected bool GetUiInputJump() => SimpleInput.GetKey(KeyCode.Space);

      protected bool GetUnityJump() => UnityEngine.Input.GetKey(JUMP_BUTTON);
   }
}
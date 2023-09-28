using UnityEngine;

namespace CodeBase.Services.Input
{
   public abstract class BaseInputService : IInputService
   {
      protected const string HORIZONTAL_AXIS = "Horizontal";
      protected const string VERTICAL_AXIS = "Vertical";
      protected const string JUMP_BUTTON = "Jump";

      public abstract Vector2 Axis { get; }
      public abstract bool JumpPressed();
      public abstract bool JumpDown();

      protected Vector2 GetUnityAxis() =>
         new(UnityEngine.Input.GetAxis(HORIZONTAL_AXIS), UnityEngine.Input.GetAxis(VERTICAL_AXIS));

      protected Vector2 GetUiInputAxis() =>
         new(SimpleInput.GetAxis(HORIZONTAL_AXIS), SimpleInput.GetAxis(VERTICAL_AXIS));

      protected bool GetUiInputJumpPressed() => SimpleInput.GetButton(JUMP_BUTTON);

      protected bool GetUnityJumpPressed() => UnityEngine.Input.GetButton(JUMP_BUTTON);
      
      protected bool GetUiInputJumpDown() => SimpleInput.GetButtonDown(JUMP_BUTTON);

      protected bool GetUnityJumpDown() => UnityEngine.Input.GetButtonDown(JUMP_BUTTON);
   }
}
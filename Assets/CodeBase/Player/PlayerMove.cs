using CodeBase.Common;
using CodeBase.Services.Input;
using UnityEngine;
using Zenject;

namespace CodeBase.Player
{
   public class PlayerMove : MonoBehaviour
   {
      [Min(0)] public float Speed = 2f;
         
      [SerializeField] private Rigidbody2D _rigidbody;
      
      [Inject] private IInputService _input;

      private void Update()
      {
         if(_input == null)
            return;
         
         if (_input.Axis.sqrMagnitude < Constants.EPSILON)
            return;
         
         _rigidbody.AddForce(_input.Axis * (Time.deltaTime * Speed), ForceMode2D.Force);
      }
   }
}

using CodeBase.Services.Input;
using UnityEngine;
using Zenject;

namespace CodeBase.Player
{
   public class HeroMove : MonoBehaviour
   {
      [Min(0)] public float Speed = 2f;
         
      [SerializeField] private Rigidbody2D _rigidbody;
      
      private IInputService _input;

      [Inject]
      private void Construct(IInputService input)
      {
         _input = input;
      }
       
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

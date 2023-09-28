using UnityEditor.SceneManagement;
using UnityEngine;
using CodeBase.Services.Input;
using Sirenix.OdinInspector;
using UniRx;
using UniRx.Triggers;
using Zenject;

namespace CodeBase.Player
{
   public class HeroMove : MonoBehaviour
   {
      private const string JUMP_CHARGE_NOTES = "Will be multiplied by the frame time.";
      private const string COLLIDER_GROUP = "ColliderGroup";
      private const string RIG_GROUP = "RidgitBodyGroup";

      [Min(0)] public float Speed = 2f;
      [Min(0)] public float JumpInitialForce = 10;
      [Min(0)] public float MaxJumpChargeTime = 1;
      [Tooltip(JUMP_CHARGE_NOTES), Min(0)] public float JumpChargeForce = 50;

      [HorizontalGroup(RIG_GROUP)]
      [SerializeField] private Rigidbody2D _rigidbody2D;
      [HorizontalGroup(COLLIDER_GROUP)]
      [SerializeField] private Collider2D _groundCheckCollider;

      private readonly CompositeDisposable _disposable = new CompositeDisposable();
      private IInputService _input;
      private bool _isGrounded = false;
      private bool _isChargingJump;
      private float _remainingJumpTime;
      private PhysicsMaterial2D _physicsMaterial;

      [Inject]
      private void Construct(IInputService input)
      {
         _input = input;
      }

      private void Start()
      {
         if (_input == null)
         {
            Debug.LogError($"HeroMove in {name}: No received InputService");
            return;
         }

         _physicsMaterial = _rigidbody2D.sharedMaterial;
         
         Observable.EveryUpdate().Subscribe(_ => CheckJump()).AddTo(_disposable);
         Observable.EveryFixedUpdate().Subscribe(_ => Move()).AddTo(_disposable);
         _groundCheckCollider.OnTriggerEnter2DAsObservable().Subscribe(_ => Landing()).AddTo(_disposable);
         _groundCheckCollider.OnTriggerExit2DAsObservable().Subscribe(_ => Takeoff()).AddTo(_disposable);
      }

      private void OnDestroy()
      {
         _disposable.Dispose();
         _disposable.Clear();
      }

      private void Move()
      {
         if (_input.Axis.sqrMagnitude < Constants.EPSILON)
            return;

         float horizontalMove = _input.Axis.x * Speed;
         Vector3 velocity = _rigidbody2D.velocity;
         velocity.x = horizontalMove;
         _rigidbody2D.velocity = velocity;
      }

      private void CheckJump()
      {
         if (_input.JumpPressed())
            Jump();
         else if (_isChargingJump) 
            StopChargingJump();
      }

      private void Jump()
      {
         if (_isChargingJump)
            ChargingJump();
         else if (_isGrounded && _input.JumpDown())
            InitialJump();
      }

      private void StopChargingJump()
      {
         _isChargingJump = false;
         Debug.Log("Stopped Jump Charging");
      }

      private void ChargingJump()
      {
         _rigidbody2D.AddForce(new Vector2(0, JumpChargeForce * Time.deltaTime), ForceMode2D.Impulse);
         _remainingJumpTime -= Time.deltaTime;
         _isChargingJump = _remainingJumpTime > 0;

         if (!_isChargingJump)
            Debug.Log("Jump Power is Max");
      }

      private void InitialJump()
      {
         _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
         _rigidbody2D.AddForce(new Vector2(0, JumpInitialForce), ForceMode2D.Impulse);
         _isChargingJump = true;
         _remainingJumpTime = MaxJumpChargeTime;
         Debug.Log("Jump Start");
      }

      private void Landing()
      {
         _isGrounded = true;
         SetFriction(1);
      }

      private void Takeoff()
      {
         _isGrounded = false;
         SetFriction(0);
      }

      private void SetFriction(float friction)
      {
         _physicsMaterial.friction = friction;
         _rigidbody2D.sharedMaterial = _physicsMaterial;
      }

      [HorizontalGroup(RIG_GROUP, 90)]
      [HideInPlayMode][Button]
      private void GetRigidbody()
      {
         _rigidbody2D = GetComponent<Rigidbody2D>();
         EditorSceneManager.MarkSceneDirty(gameObject.scene);
      }

      [HorizontalGroup(COLLIDER_GROUP, 90)]
      [HideInPlayMode][Button]
      private void GetCollider()
      {
         _groundCheckCollider = GetComponentInChildren<Collider2D>();
         EditorSceneManager.MarkSceneDirty(gameObject.scene);
      }
   }
}
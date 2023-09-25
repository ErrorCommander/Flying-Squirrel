namespace CodeBase.Infrastructure.States
{
   public class BootStrapState : IState
   {
      private const string INITIAL_SCENE_NAME = "Initial";
      private readonly GameStateMachine _stateMachine;
      private readonly SceneLoader _sceneLoader;

      public BootStrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
      {
         _stateMachine = stateMachine;
         _sceneLoader = sceneLoader;
      }

      public void Enter()
      {
#if UNITY_EDITOR
         _sceneLoader.Load(INITIAL_SCENE_NAME, LoadLevel);
#else
         LoadLevel();
#endif
      }

      public void Exit()
      {
      }

      private void LoadLevel()
      {
         _stateMachine.Enter<LoadMenuState>();
      }
   }
}
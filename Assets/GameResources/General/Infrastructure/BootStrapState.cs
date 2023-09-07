namespace GameResources.General.Infrastructure
{
   public class BootStrapState : IState
   {
      private readonly GameStateMachine _stateMachine;
      private readonly SceneLoader _sceneLoader;

      public BootStrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
      {
         _stateMachine = stateMachine;
         _sceneLoader = sceneLoader;
      }

      public void Enter()
      {
         LoadLevel();
         //_sceneLoader.Load("Initial", LoadLevel);
      }

      public void Exit()
      {
         
      }

      private void LoadLevel()
      {
         _stateMachine.Enter<LoadSceneState>();
      }

   }
}
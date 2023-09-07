namespace GameResources.General.Infrastructure
{
   public class Game
   {
      public readonly GameStateMachine StateMachine;
      public readonly ICoroutineRunner CoroutineRunner;

      public Game(ICoroutineRunner coroutineRunner)
      {
         CoroutineRunner = coroutineRunner;
         StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner));
      }
   }
}
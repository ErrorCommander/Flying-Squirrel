using CodeBase.Services.Factory;

namespace CodeBase.Infrastructure
{
   public class Game
   {
      public readonly GameStateMachine StateMachine;

      public Game(SceneLoader sceneLoader, IGameFactory gameFactory)
      {
         StateMachine = new GameStateMachine(sceneLoader, gameFactory);
      }
   }
}
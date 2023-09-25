using CodeBase.Infrastructure.States;
using CodeBase.Services.Factory;

namespace CodeBase.Infrastructure
{
   public class Game
   {
      public readonly GameStateMachine StateMachine;

      public Game(SceneLoader sceneLoader, IGameFactory gameFactory, IUIFactory uiFactory)
      {
         StateMachine = new GameStateMachine(sceneLoader, gameFactory, uiFactory);
      }
   }
}
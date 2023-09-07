using GameResources.Services.Input;
using UnityEngine;
using Zenject;

namespace GameResources.General.Infrastructure
{
   public class Game
   {
      public readonly GameStateMachine StateMachine;
      public readonly ICoroutineRunner CoroutineRunner;
      
      private static DiContainer _container;

      public Game(DiContainer container, ICoroutineRunner coroutineRunner)
      {
         _container = container;
         CoroutineRunner = coroutineRunner;
         StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner));
      }
   }
}
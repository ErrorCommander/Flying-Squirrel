using System;
using System.Collections.Generic;

namespace GameResources.General.Infrastructure
{
   public class GameStateMachine
   {
      private readonly Dictionary<Type, IState> _states;
      private IState _activeState;
 
      public GameStateMachine(SceneLoader sceneLoader)
      {
         _states = new Dictionary<Type, IState>()
         {
            [typeof(BootStrapState)] = new BootStrapState(this, sceneLoader),
            [typeof(LoadSceneState)] = new LoadSceneState(sceneLoader)
         };
      }

      public void Enter<TState>() where TState : IState
      {
         _activeState?.Exit();
         _activeState = _states[typeof(TState)];
         _activeState.Enter();
      }
   }

   public class LoadSceneState : IState
   {
      private readonly SceneLoader _sceneLoader;

      public LoadSceneState(SceneLoader sceneLoader)
      {
         _sceneLoader = sceneLoader;
      }

      public void Enter()
      {
         _sceneLoader.Load("Game");
      }

      public void Exit()
      {
         
      }
   }
}
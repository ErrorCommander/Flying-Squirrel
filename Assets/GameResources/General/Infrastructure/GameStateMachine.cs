using System;
using System.Collections.Generic;   

namespace GameResources.General.Infrastructure
{
   public class GameStateMachine
   {
      private readonly Dictionary<Type, IExitableState> _states;
      private IExitableState _activeState;
 
      public GameStateMachine(SceneLoader sceneLoader)
      {
         _states = new ()
         {
            [typeof(BootStrapState)] = new BootStrapState(this, sceneLoader),
            [typeof(LoadSceneState)] = new LoadSceneState(sceneLoader)
         };
      }

      public void Enter<TState>() where TState : class, IState
      {
         var state = ChangeState<TState>();
         state.Enter();
      }

      public void Enter<TState, TPayload>(TPayload value) where TState : class, IPayloadState<TPayload>
      {
         var state = ChangeState<TState>();
         state.Enter(value);
      }

      private TState ChangeState<TState>() where TState : class, IExitableState
      {
         _activeState?.Exit();
         TState state = GetState<TState>();
         _activeState = state;
         return state;
      }

      private TState GetState<TState>() where TState : class, IExitableState
      {
         return _states[typeof(TState)] as TState;
      }
   }
}
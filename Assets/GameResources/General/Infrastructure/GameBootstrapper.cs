using UnityEngine;
using Zenject;

namespace GameResources.General.Infrastructure
{
   public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
   {
      [Inject] private DiContainer _container;
      private Game _game;

      private void Awake()
      {
         _game = new Game(this, _container);
         _game.StateMachine.Enter<BootStrapState>();

         DontDestroyOnLoad(this);
      }
   }
}
using GameResources.Services.AssetProvider;
using GameResources.Services.Factory;
using Zenject;

namespace GameResources.General.Infrastructure
{
   public class Game
   {
      public readonly GameStateMachine StateMachine;
      public readonly ICoroutineRunner CoroutineRunner;

      public Game(ICoroutineRunner coroutineRunner, DiContainer container, IAssetProvider assetProvider)
      {
         CoroutineRunner = coroutineRunner;
         StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), container, new GameFactory(assetProvider));
      }
   }
}
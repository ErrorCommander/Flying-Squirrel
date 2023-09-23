using CodeBase.Services.AssetProvider;
using CodeBase.Services.Curtain;
using CodeBase.Services.Factory;
using CodeBase.Services.Input;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure
{
   public class GameBootstrapper : MonoInstaller, ICoroutineRunner
   {
      [SerializeField] private LoadingCurtain _progressCurtain;
      
      private Game _game;

      public override void InstallBindings()
      {
         RegisterAssetProvider();
         RegisterGameFactory();
         RegisterUIFactory();
         RegisterCoroutineRunner();
         RegisterLoadingCurtain();
         RegisterSceneLoader();
         RegisterInputService();
         
         CreateGame();
      }

      private void Awake()
      {
         _game = Container.Resolve<Game>();
         _game.StateMachine.Enter<BootStrapState>();
      }

      private void CreateGame() => 
         Container.Bind<Game>()
                  .To<Game>()
                  .AsSingle()
                  .NonLazy();

      private void RegisterAssetProvider() => 
         Container.Bind<IAssetProvider>()
                  .To<AssetProvider>()
                  .AsSingle()
                  .NonLazy();

      private void RegisterGameFactory() => 
         Container.Bind<IGameFactory>()
                  .To<GameFactory>()
                  .AsSingle()
                  .NonLazy();

      private void RegisterUIFactory() => 
         Container.Bind<IUIFactory>()
                  .To<UIFactory>()
                  .AsSingle()
                  .NonLazy();

      private void RegisterCoroutineRunner() => 
         Container.Bind<ICoroutineRunner>()
                  .FromInstance(this)
                  .AsSingle()
                  .NonLazy();

      private void RegisterLoadingCurtain() => 
         Container.Bind<IProgressCurtain>()
                  .FromInstance(_progressCurtain)
                  .AsSingle()
                  .NonLazy();

      private void RegisterSceneLoader() => 
         Container.Bind<SceneLoader>()
                  .To<SceneLoader>()
                  .AsSingle()
                  .NonLazy();

      private void RegisterInputService()
      {
         IInputService input = GetInputService();
         Container.Bind<IInputService>()
                  .FromInstance(input)
                  .AsSingle();
      }

      private IInputService GetInputService()
      {
         if (Application.isEditor)
            return new EditorInputServiceService();

         if (Application.isMobilePlatform)
            return new MobileInputServiceService();

         return new StandaloneInputServiceService();
      }
   }
}
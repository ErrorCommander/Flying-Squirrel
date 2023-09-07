namespace GameResources.General.Infrastructure
{
   public class LoadSceneState : IPayloadState<string>
   {
      private readonly SceneLoader _sceneLoader;

      public LoadSceneState(SceneLoader sceneLoader)
      {
         _sceneLoader = sceneLoader;
      }

      public void Enter(string name)
      {
         _sceneLoader.Load(name);
      }

      public void Exit()
      {
         
      }
   }
}
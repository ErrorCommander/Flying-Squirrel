namespace GameResources.General.Infrastructure
{
   public interface IState : IExitableState
   {
      void Enter();
   }
}
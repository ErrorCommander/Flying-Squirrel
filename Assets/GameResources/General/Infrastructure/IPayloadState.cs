namespace GameResources.General.Infrastructure
{
   public interface IPayloadState<TValue> : IExitableState
   {
      void Enter(TValue value);
   }
}
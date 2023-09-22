namespace CodeBase.Infrastructure
{
   public interface IPayloadState<TValue> : IExitableState
   {
      void Enter(TValue value);
   }
}
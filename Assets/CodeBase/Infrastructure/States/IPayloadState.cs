namespace CodeBase.Infrastructure.States
{
   public interface IPayloadState<TValue> : IExitableState
   {
      void Enter(TValue value);
   }
}
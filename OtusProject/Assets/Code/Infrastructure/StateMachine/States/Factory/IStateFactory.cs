namespace Code.Infrastructure.StateMachine.States.Factory
{
  public interface IStateFactory
  {
    TState GetState<TState>() where TState : class, IExitableState;
  }
}
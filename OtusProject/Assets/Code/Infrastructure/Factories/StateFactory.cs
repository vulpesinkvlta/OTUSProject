public class StateFactory : IStateFactory
{
    private readonly IDIService _di;

    public StateFactory(IDIService di) =>
      _di = di;

    public TState GetState<TState>() where TState : class, IExitableState =>
      _di.Container.Resolve<TState>();
}


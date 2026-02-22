using Code.Infrastructure._Common.Abstractions;
using Code.Infrastructure.Services.Curtain;
using Code.Infrastructure.Services.SceneLoad;
using Code.Infrastructure.StateMachine.States.Factory;
using Zenject;

namespace Code.Infrastructure.StateMachine
{
  public class GameStateMachine : IGameStateMachine, ITickable
  {
    private readonly IStateFactory _stateFactory;
    private readonly ISceneLoaderService _sceneLoader;
    private readonly ILoadingCurtain _curtain;
    private IExitableState _currentState;
    
    public GameStateMachine(IStateFactory stateFactory,
      ISceneLoaderService sceneLoader, 
      ILoadingCurtain curtain)
    {
      _stateFactory = stateFactory;
      _sceneLoader = sceneLoader;
      _curtain = curtain;
    }

    public void Enter<TState>() where TState : class, IState
    {
      IState state = ChangeState<TState>();
      state.Enter();
    }

    void ITickable.Tick()
    {
      if (_currentState is ITick tickable) 
        tickable.Tick();
    }

    public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
    {
      TState state = ChangeState<TState>();
      state.Enter(payload);
    }

    private TState ChangeState<TState>() where TState : class, IExitableState
    {
     _currentState?.Exit();

     TState state = GetState<TState>();
     _currentState = state;
     return state;
    }

    private TState GetState<TState>() where TState : class, IExitableState => 
      _stateFactory.GetState<TState>();
  }
}
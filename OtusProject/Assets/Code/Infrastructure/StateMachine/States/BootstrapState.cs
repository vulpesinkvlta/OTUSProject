using Code.Infrastructure.Services.Curtain;
using Code.Infrastructure.Services.SceneLoad;
using UnityEngine;

namespace Code.Infrastructure.StateMachine.States
{
  public class BootstrapState : IState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly ISceneLoaderService _sceneLoader;
    private readonly ILoadingCurtain _curtain;
    private readonly IConfigDataService _config;

    public BootstrapState(IGameStateMachine stateMachine,
        ISceneLoaderService sceneLoader,
        ILoadingCurtain curtain,
        IConfigDataService config)
    {
        _stateMachine = stateMachine;
        _sceneLoader = sceneLoader;
        _curtain = curtain;
        _config = config;
    }

    public void Enter()
    {
      _curtain.Show();
      _config.Load();      
      _stateMachine.Enter<LoadLevelState, string>("1.Game");
    }

    public void Exit()
    {
      
    }
  }
}
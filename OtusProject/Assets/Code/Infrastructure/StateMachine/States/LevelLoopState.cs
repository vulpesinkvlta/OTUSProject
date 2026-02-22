using Code.Infrastructure._Common.Abstractions;
using Code.Infrastructure.Contexts;
using Code.Infrastructure.Services.Curtain;
using Code.Infrastructure.Services.SceneLoad;
using UnityEngine;

namespace Code.Infrastructure.StateMachine.States
{
  public class LevelLoopState : IState, ITick
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly ISceneLoaderService _sceneLoader;
    private readonly ILoadingCurtain _curtain;
    private readonly GameLayerContext _gameContext;

    public LevelLoopState(IGameStateMachine stateMachine,
      ISceneLoaderService sceneLoader,
      ILoadingCurtain curtain,
      GameLayerContext gameContext)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
      _curtain = curtain;
      _gameContext = gameContext;
    }

    public void Enter()
    {
      Debug.Log("Enter Level Loop State");
      _gameContext.Initialize();
    }

    public void Exit()
    {
      
    }

    public void Tick()
    {
      // Debug.Log("Tick Level Loop State");
      _gameContext.Tick();
    }
  }
}
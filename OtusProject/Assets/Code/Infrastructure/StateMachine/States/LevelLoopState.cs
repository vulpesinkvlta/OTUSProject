using Code.Infrastructure._Common.Abstractions;
using Code.Infrastructure.Contexts;
using UnityEngine;

public class LevelLoopState : IState, ITick
{
    private readonly IStateMachine _stateMachine;
    private readonly ISceneLoaderService _sceneLoader;
    private readonly ILoadingCurtain _curtain;
    private readonly Code.Infrastructure.Contexts.GameContext _gameContext;

    public LevelLoopState(IStateMachine stateMachine,
      ISceneLoaderService sceneLoader,
      ILoadingCurtain curtain,
      Code.Infrastructure.Contexts.GameContext gameContext)
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
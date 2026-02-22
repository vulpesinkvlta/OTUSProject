using UnityEngine;

public class BootstrapState : IState
{
    private readonly IStateMachine _stateMachine;
    private readonly ISceneLoaderService _sceneLoader;
    private readonly ILoadingCurtain _curtain;

    public BootstrapState(IStateMachine stateMachine,
        ISceneLoaderService sceneLoader,
        ILoadingCurtain curtain)
    {
        _stateMachine = stateMachine;
        _sceneLoader = sceneLoader;
        _curtain = curtain;
    }

    public void Enter()
    {
        _curtain.Show();
        Debug.Log("Create 50 Infrastructure Services");
        Debug.Log("Get to Server for updates");
        Debug.Log("Warmup Assets");
        Debug.Log("Game Warmup Complete");

        _stateMachine.Enter<LoadLevelState, string>("BattleScene");
    }

    public void Exit()
    {

    }
}

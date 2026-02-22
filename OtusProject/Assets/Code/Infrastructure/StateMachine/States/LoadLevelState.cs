using Code.Infrastructure.Services.Curtain;
using Code.Infrastructure.Services.SaveLoad;
using Code.Infrastructure.Services.SceneLoad;

namespace Code.Infrastructure.StateMachine.States
{
  public class LoadLevelState : IPayloadedState<string>
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly ISceneLoaderService _sceneLoader;
    private readonly ILoadingCurtain _curtain;

    public LoadLevelState(IGameStateMachine stateMachine,
      ISceneLoaderService sceneLoader,
      ILoadingCurtain curtain)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
      _curtain = curtain;
    }
    
    public void Enter(string sceneName)
    {
      _sceneLoader.Load(sceneName, OnLoaded);   
    }

    private void OnLoaded()
    {
      // _gameFactory.CreatePlayer(levelData.playerPosition);
      _stateMachine.Enter<LevelLoopState>();
      _curtain.Hide();
    }

    public void Exit()
    {
      // _saveLoad.Save();
      // _saveLoad.Cleanup();
      // _assetsProvider.Cleanup();
    }
  }
}
using Code.Infrastructure.Contexts;
using Code.Infrastructure.Services.Curtain;
using Code.Infrastructure.Services.SaveLoad;
using Code.Infrastructure.Services.SceneLoad;
using UnityEngine;

namespace Code.Infrastructure.StateMachine.States
{
  public class LoadLevelState : IPayloadedState<string>
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly ISceneLoaderService _sceneLoader;
    private readonly ILoadingCurtain _curtain;
    private readonly GameLayerContext _gameContext;
    private readonly ISaveLoadService _saveLoad;

    public LoadLevelState(IGameStateMachine stateMachine,
      ISceneLoaderService sceneLoader,
      ILoadingCurtain curtain 
      //GameLayerContext gameContext,
      //ISaveLoadService saveLoad
      )
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
      _curtain = curtain;
      //_gameContext = gameContext;
      //_saveLoad = saveLoad;
    }
    
    public void Enter(string sceneName)
    {
        Debug.Log("LoadLevelState Enter"); 
      _sceneLoader.Load(sceneName, OnLoaded);   
    }

    private void OnLoaded()
    {
      // _gameFactory.CreatePlayer(levelData.playerPosition);
    //  _saveLoad.Load();
      _stateMachine.Enter<LevelLoopState>();
      _curtain.Hide();
    }

    public void Exit()
    {
      //_saveLoad.Save();
      //_saveLoad.Cleanup();
      //_gameContext.Cleanup();
      //_assetsProvider.Cleanup();
      Debug.Log("LoadLevelState Exit"); 
    }
  }
}
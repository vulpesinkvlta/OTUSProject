using Code.Infrastructure.Services.SaveLoad;
using Code.Infrastructure.StateMachine;
using Code.Infrastructure.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Boot.AppInitializer
{
  public class AppInitializer : IInitializable
  {
    private readonly ISaveLoadService _saveLoad;
    private readonly IGameStateMachine _stateMachine;

    public AppInitializer(ISaveLoadService saveLoad,
      IGameStateMachine stateMachine)
    {
      _saveLoad = saveLoad;
      _stateMachine = stateMachine;
    }
    
    public void Initialize()
    {
      Debug.Log("App Initialize");
      _saveLoad.LoadProgressOrInitNew();
      _stateMachine.Enter<BootstrapState>();
    }
  }
}
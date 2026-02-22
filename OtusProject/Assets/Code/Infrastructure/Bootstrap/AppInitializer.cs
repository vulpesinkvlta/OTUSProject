using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AppInitializer : IInitializable
{
    private readonly ISaveLoadService _saveLoad;
    private readonly IStateMachine _stateMachine;

    public AppInitializer(ISaveLoadService saveLoad,
      IStateMachine stateMachine)
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

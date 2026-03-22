using System;
using Code.Infrastructure.Services.SaveLoad;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Scene.SaveLoad
{
  public class SaveLoadSystem : IInitializable, IDisposable
  {
    private readonly ISaveLoadService _saveLoad;

    public SaveLoadSystem(ISaveLoadService saveLoad)
    {
      _saveLoad = saveLoad;
    }
    
    public void Initialize()
    {
      //_saveLoad.Save();
      // _saveLoad.Load();

      Application.quitting += OnApplicationQuitting;
    }

    public void Dispose()
    {
        Application.quitting -= OnApplicationQuitting;
        _saveLoad.Save();
        _saveLoad.Cleanup();
        }

        private void OnApplicationQuitting()
        {
            _saveLoad.Save();
        }
    }
}
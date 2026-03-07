using System;
using Code.Infrastructure.Services.SaveLoad;
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
      _saveLoad.Save();
      // _saveLoad.Load();
    }

    public void Dispose()
    {
    }
  }
}
using System;

namespace Code.Infrastructure.Services.SceneLoad
{
  public interface ISceneLoaderService
  {
    void Load(string name, Action OnLoaded = null);
  }
}
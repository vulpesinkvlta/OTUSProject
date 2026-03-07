using Code.Infrastructure.Services.SaveLoad;
using Zenject;

namespace Code.Gameplay.Features.Scene.SaveLoad
{
  public class SaveLoadContributor : IInitializable
  {
    private readonly ISaveLoadService _saveLoad;
    private readonly PlayerFacade _playerFacade;

    public SaveLoadContributor(ISaveLoadService saveLoad,
      PlayerFacade playerFacade)
    {
      _saveLoad = saveLoad;
      _playerFacade = playerFacade;
    }

    public void Initialize()
    {
      //_saveLoad.AddSaveLoad(_playerFacade.PlayerHealthMono as ISaveLoad);
        
    }
  }
}
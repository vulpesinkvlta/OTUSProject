using Code.Infrastructure.Data;
using Code.Infrastructure.Services.Progress;
using Code.Infrastructure.Services.SaveLoad;

namespace Code.Gameplay.Features.Gold.Services
{
  public class GoldService : IGoldService, ISaveLoad
  {
    private readonly IProgressService _progress;
    private int _currentGold;

    public GoldService(IProgressService progress)
    {
      _progress = progress;
    }

    public void AddGold(int goldAmount)
    {
      _currentGold += goldAmount;
    }

    public void RemoveGold()
    {
    }

    public void Save(PlayerProgress progress)
    {
      //_progress.PlayerProgress.ResourcesData.Gold = _currentGold;
    }

    public void Load(PlayerProgress progress)
    {
     // _currentGold = _progress.PlayerProgress.ResourcesData.Gold;
    }
  }
}
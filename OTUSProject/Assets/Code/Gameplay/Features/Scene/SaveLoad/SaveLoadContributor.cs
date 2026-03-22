using Code.Infrastructure.Services.SaveLoad;
using Zenject;

namespace Code.Gameplay.Features.Scene.SaveLoad
{
  public class SaveLoadContributor : IInitializable
  {
        private readonly ISaveLoadService _saveLoad;
        private readonly IPlayerProgressService _playerProgress;
        private readonly IExperienceService _experienceService;
        private readonly TowerPlacementSaveLoad _towerPlacementSaveLoad;

        public SaveLoadContributor(
            ISaveLoadService saveLoad,
            IPlayerProgressService playerProgress,
            IExperienceService experienceService,
            TowerPlacementSaveLoad towerPlacementSaveLoad)
        {
            _saveLoad = saveLoad;
            _playerProgress = playerProgress;
            _experienceService = experienceService;
            _towerPlacementSaveLoad = towerPlacementSaveLoad;
        }

        public void Initialize()
        {
            _saveLoad.AddSaveLoad(_playerProgress);
            _saveLoad.AddSaveLoad(_experienceService);
            _saveLoad.AddSaveLoad(_towerPlacementSaveLoad);
            _saveLoad.Load();
        }
   }
}
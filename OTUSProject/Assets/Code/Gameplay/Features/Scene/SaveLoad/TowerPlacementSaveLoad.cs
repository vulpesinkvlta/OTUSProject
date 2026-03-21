using Code.Infrastructure.Data;
using Code.Infrastructure.Services.SaveLoad;

public class TowerPlacementSaveLoad : ISaveLoad
{

    private readonly TowerFactory _towerFactory;
    private readonly ITowerLimitService _towerLimitService;

    public TowerPlacementSaveLoad(
        TowerFactory towerFactory,
        ITowerLimitService towerLimitService)
    {
        _towerFactory = towerFactory;
        _towerLimitService = towerLimitService;
    }

    public void Save(PlayerProgress progress)
    {
        progress.PlayerData.PlacedTowers = new System.Collections.Generic.List<PlacedTowerData>(_towerFactory.CapturePlacedTowers());
    }

    public void Load(PlayerProgress progress)
    {
        if (progress.PlayerData?.PlacedTowers == null)
            return;

        foreach (PlacedTowerData towerData in progress.PlayerData.PlacedTowers)
        {
            _towerFactory.CreateTower(towerData.TowerId, towerData.WeaponType, towerData.Position);
            _towerLimitService.RegisterSpawn();
        }
    }
}
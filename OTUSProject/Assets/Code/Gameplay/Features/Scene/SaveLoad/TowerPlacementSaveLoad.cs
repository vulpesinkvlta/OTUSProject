using Code.Infrastructure.Data;
using Code.Infrastructure.Services.SaveLoad;
using System.Collections.Generic;

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
        if (progress.PlayerData == null)
            progress.PlayerData = new PlayerData();

        progress.PlayerData.PlacedTowers = new List<PlacedTowerData>(_towerFactory.CapturePlacedTowers());
    }

    public void Load(PlayerProgress progress)
    {
        List<PlacedTowerData> placedTowers = progress.PlayerData?.PlacedTowers;
        if (placedTowers == null || placedTowers.Count == 0)
            return;

        foreach (PlacedTowerData towerData in placedTowers)
        {
            if (towerData == null || string.IsNullOrWhiteSpace(towerData.TowerId))
                continue;
            _towerFactory.CreateTower(towerData.TowerId, towerData.WeaponType, towerData.ToPosition());
            _towerLimitService.RegisterSpawn();
        }
    }
}
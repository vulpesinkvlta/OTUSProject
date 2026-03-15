using System.Collections.Generic;

public class PlayerProgressService : IPlayerProgressService
{
    private Dictionary<string, TowerStats> _towerStats
        = new Dictionary<string, TowerStats>();

    public TowerStats GetTowerStats(string towerId)
    {
        if (!_towerStats.TryGetValue(towerId, out var stats))
        {
            stats = new TowerStats();
            _towerStats.Add(towerId, stats);
        }

        return stats;
    }

    public void UpgradeDamage(string towerId, float value)
    {
        GetTowerStats(towerId).ApplyDamageUpgrade(value);
    }

    public void UpgradeFireRate(string towerId, float value)
    {
        GetTowerStats(towerId).ApplyFireRateUpgrade(value);
    }

    public void UpgradeHealth(string towerId, int value)
    {
        GetTowerStats(towerId).ApplyHealthUpgrade(value);
    }

    public void UpgradeRange(string towerId, float value)
    {
        GetTowerStats(towerId).ApplyRangeUpgrade(value);
    }
}
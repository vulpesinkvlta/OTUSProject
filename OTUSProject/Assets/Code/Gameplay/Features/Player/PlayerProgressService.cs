using System.Collections.Generic;

public class PlayerProgressService : IPlayerProgressService
{
    private string BaseTowerId = "BaseTower";

    private readonly TowerConfigs _configs;
    private Dictionary<string, TowerStats> _towerStats
        = new Dictionary<string, TowerStats>();

    public PlayerProgressService(TowerConfigs configs)
    {
        _configs = configs;
        _towerStats[BaseTowerId] = CreateFromConfig(_configs);
    }
    public TowerStats GetTowerStats(string towerId)
    {
        if (!_towerStats.TryGetValue(towerId, out var stats))
        {
            stats = CreateFromConfig(_configs);
            _towerStats.Add(towerId, stats);
        }

        return stats;
    }
    private TowerStats CreateFromConfig(TowerConfigs config)
    {
        return new TowerStats
        {
            Damage = config.Damage,
            FireRate = config.FireRate,
            Range = config.Range,
            Health = config.Health
        };
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
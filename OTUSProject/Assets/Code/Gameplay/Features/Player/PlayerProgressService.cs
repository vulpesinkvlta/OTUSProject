using Code.Infrastructure.Data;
using Code.Infrastructure.Services.Progress;
using System.Collections.Generic;
using System.Linq;
using static UnityEngine.Rendering.DebugUI;

public class PlayerProgressService : IPlayerProgressService
{
    private const string BaseTowerId = "BaseTower";

    private readonly TowerConfigs _configs;
    private Dictionary<string, TowerStats> _towerStats
        = new Dictionary<string, TowerStats>();

    public PlayerProgressService(TowerConfigs configs)
    {
        _configs = configs;
        EnsureDefaultTower();
    }
    public TowerStats GetTowerStats(string towerId)
    {
        if (!_towerStats.TryGetValue(towerId, out TowerStats stats))
        {
            stats = CreateFromConfig(_configs, towerId);
            _towerStats.Add(towerId, stats);
        }

        return stats;
    }
    private TowerStats CreateFromConfig(TowerConfigs config, string towerId)
    {
        return new TowerStats
        {
            Id = towerId,
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

    public IReadOnlyCollection<TowerStatsData> GetAllTowerStats() =>
     _towerStats.Select(pair => pair.Value.ToData(pair.Key)).ToList();

    public void Save(PlayerProgress progress)
    {
        progress.PlayerData.Towers = GetAllTowerStats().ToList();
    }

    public void Load(PlayerProgress progress)
    {
        _towerStats.Clear();

        List<TowerStatsData> savedTowers = progress.PlayerData?.Towers;
        if (savedTowers != null)
        {
            foreach (TowerStatsData towerData in savedTowers)
            {
                if (towerData == null || string.IsNullOrWhiteSpace(towerData.Id))
                    continue;

                _towerStats[towerData.Id] = TowerStats.FromData(towerData);
            }
        }

        EnsureDefaultTower();
    }

    private void EnsureDefaultTower()
    {
        if (!_towerStats.ContainsKey(BaseTowerId))
            _towerStats[BaseTowerId] = CreateFromConfig(_configs, BaseTowerId);
    }
}
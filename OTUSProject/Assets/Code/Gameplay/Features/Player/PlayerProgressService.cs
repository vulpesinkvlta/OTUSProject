using Code.Infrastructure.Data;
using Code.Infrastructure.Services.Progress;
using System.Collections.Generic;
using System.Linq;
using static UnityEngine.Rendering.DebugUI;

public class PlayerProgressService : IPlayerProgressService
{
    private const string BaseTowerId = "BaseTower";

    private readonly TowerConfigs _configs;
    private readonly Dictionary<string, TowerStats> _towerStats = new();

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

    public void UpgradeDamage(string towerId, float value) =>
        GetTowerStats(towerId).ApplyDamageUpgrade(value);

    public void UpgradeFireRate(string towerId, float value) =>
        GetTowerStats(towerId).ApplyFireRateUpgrade(value);

    public void UpgradeHealth(string towerId, int value) =>
        GetTowerStats(towerId).ApplyHealthUpgrade(value);

    public void UpgradeRange(string towerId, float value) =>
        GetTowerStats(towerId).ApplyRangeUpgrade(value);
    public IReadOnlyCollection<TowerStatsData> GetAllTowerStats() =>
    _towerStats.Values
        .Select(stats => stats.ToData(stats.Id))
            .ToList();

    public void Save(PlayerProgress progress)
    {
        EnsurePlayerData(progress);
        progress.PlayerData.Towers = GetAllTowerStats().ToList();
    }

    public void Load(PlayerProgress progress)
    {
        EnsurePlayerData(progress);
        List<TowerStatsData> savedTowers = progress.PlayerData.Towers;
        if (savedTowers == null || savedTowers.Count == 0)
        {
            EnsureDefaultTower();
            return;
        }

        HashSet<string> savedTowerIds = new();

        foreach (TowerStatsData towerData in savedTowers)
        {
            if (towerData == null || string.IsNullOrWhiteSpace(towerData.Id))
                continue;

            savedTowerIds.Add(towerData.Id);

            if (_towerStats.TryGetValue(towerData.Id, out TowerStats existingStats))
                existingStats.RestoreFromData(towerData);
            else
                _towerStats[towerData.Id] = TowerStats.FromData(towerData);
        }

        List<string> staleTowerIds = _towerStats.Keys
            .Where(id => id != BaseTowerId && !savedTowerIds.Contains(id))
            .ToList();

        foreach (string staleTowerId in staleTowerIds)
            _towerStats.Remove(staleTowerId);

        EnsureDefaultTower();
    }

    private static void EnsurePlayerData(PlayerProgress progress)
    {
        if (progress.PlayerData == null)
            progress.PlayerData = new PlayerData();
    }

    private void EnsureDefaultTower()
    {
        if (!_towerStats.ContainsKey(BaseTowerId))
            _towerStats[BaseTowerId] = CreateFromConfig(_configs, BaseTowerId);
    }
}
using Code.Infrastructure.Data;
using Code.Infrastructure.Services.SaveLoad;
using System.Collections.Generic;

public interface IPlayerProgressService : ISaveLoad
{
    TowerStats GetTowerStats(string towerId);
    IReadOnlyCollection<TowerStatsData> GetAllTowerStats();

    void UpgradeDamage(string towerId, float value);
    void UpgradeFireRate(string towerId, float value);
    void UpgradeRange(string towerId, float value);
    void UpgradeHealth(string towerId, int value);
}
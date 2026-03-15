public interface IPlayerProgressService
{
    TowerStats GetTowerStats(string towerId);

    void UpgradeDamage(string towerId, float value);
    void UpgradeFireRate(string towerId, float value);
    void UpgradeRange(string towerId, float value);
    void UpgradeHealth(string towerId, int value);
}
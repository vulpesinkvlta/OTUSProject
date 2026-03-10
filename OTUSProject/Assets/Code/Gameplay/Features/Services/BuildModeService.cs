
public class BuildModeService
{
    public bool IsActive;
    public WeaponType TowerType;

    public void StartBuild(WeaponType type)
    {
        IsActive = true;
        TowerType = type;
    }

    public void StopBuild()
    {
        IsActive = false;
    }
}
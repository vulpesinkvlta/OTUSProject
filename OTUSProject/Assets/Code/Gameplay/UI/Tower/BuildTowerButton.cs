using UnityEngine;
using Zenject;

public class BuildTowerButton : MonoBehaviour
{
    [Inject] private BuildModeService _buildMode;

    public void OnClick()
    {
        _buildMode.StartBuild(WeaponType.Projectile);
    }
}
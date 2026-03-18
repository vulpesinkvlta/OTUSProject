using System;
using UnityEngine;
using Zenject;

public class BuildModeService 
{
    public bool IsActive { get; private set; }
    public WeaponType TowerType { get; private set; }

    public event Action<bool> OnBuildModeChanged;

    public void StartBuild(WeaponType type)
    {
        TowerType = type;
        IsActive = true;
        OnBuildModeChanged?.Invoke(true);
    }

    public void StopBuild()
    {
        IsActive = false;

        OnBuildModeChanged?.Invoke(false);
    }
}
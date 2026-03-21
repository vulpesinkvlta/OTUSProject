
using Code.Infrastructure.Data;
using Code.Infrastructure.Services.Progress;
using Code.Infrastructure.Services.SaveLoad;
using System;
using UnityEngine;

public class TowerStats 
{
    public float Damage;
    public float FireRate;
    public float Range;
    public int Health;

    public event Action OnStatsChanged;

    public void ApplyDamageUpgrade(float value)
    {
        Damage += value;
        OnStatsChanged?.Invoke();
    }

    public void ApplyFireRateUpgrade(float value)
    {
        FireRate += value;
        OnStatsChanged?.Invoke();
    }

    public void ApplyRangeUpgrade(float value)
    {
        Range += value;
        OnStatsChanged?.Invoke();
    }

    public void ApplyHealthUpgrade(int value)
    {
        Health += value;
        OnStatsChanged?.Invoke();
    }
}
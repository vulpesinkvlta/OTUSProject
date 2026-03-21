
using Code.Infrastructure.Data;
using Code.Infrastructure.Services.Progress;
using Code.Infrastructure.Services.SaveLoad;
using System;
using UnityEngine;

public class TowerStats : ISaveLoad
{
    public float Damage;
    public float FireRate;
    public float Range;
    public int Health;

    public event Action OnStatsChanged;

    private readonly IProgressService _progress;
    public TowerStats(IProgressService progress)
    {
        _progress = progress;
    }
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

    public void Save(PlayerProgress progress)
    {
        _progress.PlayerProgress.TowerStats.Damage = Damage;
        _progress.PlayerProgress.TowerStats.FireRate = FireRate;
        _progress.PlayerProgress.TowerStats.Range = Range;
        _progress.PlayerProgress.TowerStats.Health = Health;
    }

    public void Load(PlayerProgress progress)
    {
        Damage = _progress.PlayerProgress.TowerStats.Damage;
        FireRate = _progress.PlayerProgress.TowerStats.FireRate;
        Range = _progress.PlayerProgress.TowerStats.Range;
        Health = _progress.PlayerProgress.TowerStats.Health;
        OnStatsChanged?.Invoke();
    }
}
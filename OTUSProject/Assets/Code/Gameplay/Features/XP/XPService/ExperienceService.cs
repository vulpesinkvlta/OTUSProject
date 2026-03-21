using Code.Infrastructure.Data;
using Code.Infrastructure.Services.Progress;
using Code.Infrastructure.Services.SaveLoad;
using System;

public class ExperienceService : IExperienceService
{
    public int CurrentXP { get; private set; }
    public int Level { get; private set; } = 1;
    public int NextLevel { get; private set; } = 100;

    public event Action<int, int> OnExperienceChanged;
    public event Action OnLevelChanged;

    public ExperienceService()
    {
    }
    public void AddXP(int amount)
    {
        CurrentXP += amount;
        while (CurrentXP >= NextLevel)
        {
            CurrentXP -= NextLevel;
            Level++;
            NextLevel = CalcuteNextLevelXP(Level);
            OnLevelChanged?.Invoke();
        }

        OnExperienceChanged?.Invoke(CurrentXP, NextLevel);
    }

    private int CalcuteNextLevelXP(int level)
    {
        return 100 + level * 50;
    }

    public void Save(PlayerProgress progress)
    {
        progress.PlayerData.Level = Level;
        progress.PlayerData.CurrentXP = CurrentXP;
    }

    public void Load(PlayerProgress progress)
    {
        PlayerData playerData = progress.PlayerData ?? new PlayerData();
        Level = Math.Max(1, playerData.Level);
        CurrentXP = Math.Max(0, playerData.CurrentXP);
        NextLevel = CalcuteNextLevelXP(Level);
        OnLevelChanged?.Invoke();
        OnExperienceChanged?.Invoke(CurrentXP, NextLevel);
    }
}


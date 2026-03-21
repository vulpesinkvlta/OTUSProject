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

    private readonly IProgressService _progress;

    public ExperienceService(IProgressService progress)
    {
        _progress = progress;
    }
    public void AddXP(int amount)
    {
        CurrentXP += amount;
        while (CurrentXP >= NextLevel)
        {
            CurrentXP -= NextLevel;
            Level++;
            OnLevelChanged?.Invoke();
            NextLevel = CalcuteNextLevelXP(Level);
        }

        OnExperienceChanged?.Invoke(CurrentXP, NextLevel);
    }

    private int CalcuteNextLevelXP(int level)
    {
        return 100 + level * 50;
    }
}


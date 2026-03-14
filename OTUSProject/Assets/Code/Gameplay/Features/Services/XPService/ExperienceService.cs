using System;

public class ExperienceService : IExperienceService
{
    public int CurrentXP { get; private set; }
    public int Level { get; private set; } = 1;

    public event Action<int, int> OnExperienceChanged;
    public int NextLevel { get; private set; } = 100;

    public void AddXP(int amount)
    {
        CurrentXP += amount;
        while (CurrentXP >= NextLevel)
        {
            CurrentXP -= NextLevel;
            Level++;

            NextLevel = CalcuteNextLevelXP(Level);
        }

        OnExperienceChanged?.Invoke(CurrentXP, NextLevel);
    }

    private int CalcuteNextLevelXP(int level)
    {
        return 100 + level * 50;
    }
}


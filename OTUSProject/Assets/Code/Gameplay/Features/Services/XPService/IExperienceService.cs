using System;

public interface IExperienceService
{
    int CurrentXP { get;}
    int Level { get;}
    int NextLevel { get; }

    event Action<int, int> OnExperienceChanged;

    void AddXP(int amount);
}


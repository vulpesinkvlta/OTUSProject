using Code.Infrastructure.Services.SaveLoad;
using System;

public interface IExperienceService : ISaveLoad
{
    int CurrentXP { get;}
    int Level { get;}
    int NextLevel { get; }

    event Action<int, int> OnExperienceChanged;
    event Action OnLevelChanged;

    void AddXP(int amount);
}


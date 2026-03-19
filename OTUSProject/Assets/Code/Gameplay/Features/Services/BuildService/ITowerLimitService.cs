using System;

public interface ITowerLimitService
{
    int Spawned { get; }
    int CurrentLimit { get; }

    event Action OnLimitChanged;

    bool CanSpawn();
    void DestroySpawn();
    void RegisterSpawn();
    void SetLimit(int limit);
}
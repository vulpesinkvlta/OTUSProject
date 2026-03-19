using System;

public class TowerLimitService : ITowerLimitService
{
    private int _currentLimit;
    private int _spawned;

    public int CurrentLimit => _currentLimit;
    public int Spawned => _spawned;

    public event Action OnLimitChanged;

    public void SetLimit(int limit)
    {
        _currentLimit = limit;
        _spawned = 0;
        OnLimitChanged?.Invoke();
    }

    public bool CanSpawn()
    {
        return _spawned < _currentLimit;
    }

    public void RegisterSpawn()
    {
        _spawned++;
        OnLimitChanged?.Invoke();
    }
    public void DestroySpawn()
    {
        _spawned--;
        OnLimitChanged?.Invoke();
    }
}


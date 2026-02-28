using Entitas;

public class WaveInitSystem : IInitializeSystem
{
    private readonly GameContext _context;
    public WaveInitSystem(Contexts contexts)
    {
        _context = contexts.game;
    }
    public void Initialize()
    {
        var wave = _context.CreateEntity();

        wave.AddEnemyWave(
            newWaveIndex: 1,
            newEnemiesToSpawn: 5,
            newEnemiesSpawned: 0,
            newSpawnInterval: 1f,
            newTimer: 0f);
    }
}



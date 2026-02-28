using Entitas;
using UnityEngine;

public class EnemyWaveCompleteSystem : IExecuteSystem
{
    private readonly GameContext _context;
    private readonly IGroup<GameEntity> _waves;
    private readonly IGroup<GameEntity> _enemies;

    public EnemyWaveCompleteSystem(Contexts contexts)
    {
        _context = contexts.game;
        _waves = _context.GetGroup(GameMatcher.EnemyWave);
        _enemies = _context.GetGroup(GameMatcher.EnemyTag);
    }

    public void Execute()
    {
        if (_enemies.count > 0)
            return;

        foreach (var wave in _waves)
        {
            if (wave.enemyWave.enemiesSpawned < wave.enemyWave.enemiesToSpawn)
                continue;

            int nextIndex = wave.enemyWave.waveIndex + 1;

            wave.ReplaceEnemyWave(
                nextIndex,
                newEnemiesToSpawn: 5 + nextIndex * 5,
                newEnemiesSpawned: 0,
                newSpawnInterval: Mathf.Max(0.3f, 1f - nextIndex * 0.05f),
                newTimer: 0f
            );
        }
    }
}
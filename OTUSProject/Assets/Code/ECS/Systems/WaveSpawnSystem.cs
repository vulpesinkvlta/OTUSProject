using Entitas;
using UnityEngine;
public class WaveSpawnSystem : IExecuteSystem
{
    private readonly EnemyFactory _factory;
    private readonly IGroup<GameEntity> _waves;

    private readonly IGroup<GameEntity> _spawnPoint;

    private readonly GameContext _context;
    public WaveSpawnSystem(Contexts context, EnemyFactory factory)
    {
        _context = context.game;
        _factory = factory;
        _waves = _context.GetGroup(GameMatcher.EnemyWave);
        _spawnPoint = _context.GetGroup(GameMatcher.AllOf(
                GameMatcher.SpawnPoint,
                GameMatcher.Position,
                GameMatcher.EnemyTag));
    }
    public void Execute()
    {
        var points = _spawnPoint.GetEntities();

        foreach (var wave in _waves)
        {
            wave.ReplaceEnemyWave(
                wave.enemyWave.waveIndex,
                wave.enemyWave.enemiesToSpawn,
                wave.enemyWave.enemiesSpawned,
                wave.enemyWave.spawnInterval,
                wave.enemyWave.timer + Time.deltaTime);

            if (wave.enemyWave.enemiesSpawned >= wave.enemyWave.enemiesToSpawn)
                continue;

            if(wave.enemyWave.timer < wave.enemyWave.spawnInterval)
                continue;

            SpawnEnemy(points);

            wave.ReplaceEnemyWave(
                wave.enemyWave.waveIndex,
                wave.enemyWave.enemiesToSpawn,
                wave.enemyWave.enemiesSpawned + 1,
                wave.enemyWave.spawnInterval,
                0f);
        }
    }

    private void SpawnEnemy(GameEntity[] points)
    {
        var randomSpawnPoint = points[Random.Range(0, points.Length)];  
        var type = Random.value> 0.5f ? EnemyType.Melee : EnemyType.Range;

        _factory.Create(type, randomSpawnPoint.position.value);
    }
}


using Entitas;

[Game]
public class EnemyWaveComponent : IComponent
{
    public int waveIndex;
    public int enemiesToSpawn;
    public int enemiesSpawned;
    public float spawnInterval;
    public float timer;
}


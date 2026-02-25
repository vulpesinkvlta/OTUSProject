using Entitas;
using UnityEngine;

public class EnemySpawnSystem : IInitializeSystem
{
    private readonly EnemyFactory _factory;
    private readonly Vector3 _spawnPositions = new Vector3(25,0,0);

    public EnemySpawnSystem(EnemyFactory factory)
    {
        _factory = factory;
    }

    public void Initialize()
    {
        _factory.Create(EnemyType.Range, _spawnPositions);
        _factory.Create(EnemyType.Melee, _spawnPositions);
    }
}
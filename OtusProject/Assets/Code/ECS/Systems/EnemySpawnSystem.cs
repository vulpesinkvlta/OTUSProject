using Entitas;
using UnityEngine;

public class EnemySpawnSystem : IInitializeSystem
{
    private readonly EnemyFactory _factory;

    public EnemySpawnSystem(EnemyFactory factory)
    {
        _factory = factory;
    }

    public void Initialize()
    {
        _factory.Create(new Vector3(-5, 0, 0));
    }
}
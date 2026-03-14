using Entitas;
using UnityEngine;
using Zenject;

public class ThroneSpawningSystem : IInitializeSystem
{
    private readonly GameContext _context;


    private readonly IGroup<GameEntity> _spawnPoint;
    private readonly ThroneFactory _factory;

    public ThroneSpawningSystem(
            Contexts context,
            ThroneFactory factory)
    {
        _context = context.game;
  

        _spawnPoint = _context.GetGroup(GameMatcher.AllOf(
                        GameMatcher.SpawnPoint,
                        GameMatcher.Position,
                        GameMatcher.ThroneTag));
        _factory = factory;
    }
    public void Initialize()
    {
        var spawnPoint = _spawnPoint.GetSingleEntity();
        if (spawnPoint == null)
        {
            Debug.LogError("No Throne SpawnPoint found!");
            return;
        }
        Debug.Log("CreateThrone");
        _factory.CreateThrone(spawnPoint.position.value);        
    }
}


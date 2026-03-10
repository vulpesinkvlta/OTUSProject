using Entitas;
using UnityEngine;
using Zenject;

public class ThroneSpawningSystem : IInitializeSystem
{
    private readonly GameContext _context;
    private readonly DiContainer _container;
    private readonly ThroneView _prefab;

    private readonly IGroup<GameEntity> _spawnPoint;
    public ThroneSpawningSystem(
            Contexts context,
            DiContainer container,
            ThroneView throneView)
    {
        _context = context.game;
        _container = container;
        _prefab = throneView;

        _spawnPoint = _context.GetGroup(GameMatcher.AllOf(
                        GameMatcher.SpawnPoint,
                        GameMatcher.Position));
    }
    public void Initialize()
    {
        var spawnPoint = _spawnPoint.GetSingleEntity();
        var throneEntity = _context.CreateEntity();

        throneEntity.isThroneTag = true;
        throneEntity.AddHealth(500);
        throneEntity.isDestructible = true;
        throneEntity.AddPosition(spawnPoint.position.value);
        var view = _container.InstantiatePrefabForComponent<ThroneView>(
                    _prefab, spawnPoint.position.value, Quaternion.identity, null);
        
        view.Initialize(throneEntity);
        throneEntity.AddView(view);
    }
}


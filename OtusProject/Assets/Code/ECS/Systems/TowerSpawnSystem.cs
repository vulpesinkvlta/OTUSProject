using Entitas;
using UnityEngine;
using Zenject;

public class TowerSpawnSystem : IInitializeSystem
{
    private readonly GameContext _context;
    private readonly DiContainer _container;
    private readonly TowerView _towerPrefab;
    public TowerSpawnSystem(
        Contexts contexts,
        DiContainer container,
        TowerView towerPrefab)
    {
        _context = contexts.game;
        _container = container;
        _towerPrefab = towerPrefab;
    }

    public void Initialize()
    {
        Vector3 position = new Vector3(0, 0, 0);

        var entity = _context.CreateEntity();
        entity.isTowerTag = true;
        entity.AddHealth(100);
        entity.AddPosition(position);
        entity.AddDamage(1);
        entity.AddAttackCooldown(1);
        entity.isDestructible = true;

        var view = _container.InstantiatePrefabForComponent<TowerView>(
            _towerPrefab,
            position,
            Quaternion.identity,
            null);

        view.Initialize(entity);
        entity.AddView(view);
    }
}


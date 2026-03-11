using UnityEngine;
using Zenject;
using Entitas;

public class ThroneFactory
{
    private readonly GameContext _context;
    private readonly DiContainer _container;
    private readonly ThroneView _prefab;

    public ThroneFactory(Contexts contexts, DiContainer container, ThroneView prefab)
    {
        _context = contexts.game;
        _container = container;
        _prefab = prefab;
    }

    public GameEntity CreateThrone(Vector3 position)
    {
        var throneEntity = _context.CreateEntity();

        throneEntity.isThroneTag = true;
        throneEntity.AddHealth(500);
        throneEntity.isDestructible = true;
        throneEntity.AddPosition(position);

        var view = _container.InstantiatePrefabForComponent<ThroneView>(
            _prefab,
            position,
            Quaternion.identity,
            null);

        view.Initialize(throneEntity);

        throneEntity.AddView(view);

        Debug.Log("Throne Factory");

        return throneEntity;
    }
}
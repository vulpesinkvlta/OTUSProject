using UnityEngine;
using Zenject;
using Entitas;

public class ThroneFactory
{
    private readonly GameContext _context;
    private readonly DiContainer _container;
    private readonly ThroneConfig _prefab;
    public ThroneFactory(Contexts contexts, DiContainer container, ThroneConfig prefab)
    {
        _context = contexts.game;
        _container = container;
        _prefab = prefab;
    }

    public GameEntity CreateThrone(Vector3 position)
    {
        var throneConfig = _prefab;
        var throneEntity = _context.CreateEntity();

        throneEntity.isThroneTag = true;
        throneEntity.AddHealth(throneConfig.Health);
        throneEntity.isDestructible = true;
        throneEntity.AddPosition(position);
        throneEntity.AddHitRadius(throneConfig.HitRange);

        var view = _container.InstantiatePrefabForComponent<ThroneView>(
            throneConfig.Prefab,
            position,
            Quaternion.identity,
            null);

        view.Initialize(throneEntity);

        throneEntity.AddView(view);

        Debug.Log("Throne Factory");

        return throneEntity;
    }
}
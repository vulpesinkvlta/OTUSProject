using Entitas;
using UnityEngine;
using Zenject;

public class TowerFactory
{
    private readonly GameContext _context;
    private readonly DiContainer _container;
    private readonly TowerView _towerPrefab;

    public TowerFactory(Contexts contexts, DiContainer container, TowerView prefab)
    {
        _context = contexts.game;
        _container = container;
        _towerPrefab = prefab;
    }

    public GameEntity CreateTower(WeaponType type, Vector3 position)
    {
        var entity = _context.CreateEntity();

        entity.isTowerTag = true;
        entity.isCanShoot = true;

        entity.AddHealth(1000);
        entity.AddPosition(position);
        entity.AddAttackRange(15);
        entity.AddDamage(100);
        entity.AddAttackCooldown(1);
        entity.AddAttackTimer(0);

        entity.AddWeapon(type, 8f);

        entity.isDestructible = true;

        var view = _container.InstantiatePrefabForComponent<TowerView>(
            _towerPrefab,
            position,
            Quaternion.identity,
            null);

        view.Initialize(entity);
        entity.AddView(view);

        return entity;
    }
}

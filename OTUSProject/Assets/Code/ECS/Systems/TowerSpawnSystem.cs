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
        Vector3 position = new Vector3(0, 2, 0);

        var entity = _context.CreateEntity();

        entity.isTowerTag = true;
        entity.isCanShoot = true;

        entity.AddHealth(1000);
        entity.AddPosition(position);
        entity.AddAttackRange(15);
        entity.AddDamage(100);
        entity.AddAttackCooldown(1);
        entity.AddAttackTimer(0);

        entity.AddWeapon(
            WeaponType.Projectile,
            8f);

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


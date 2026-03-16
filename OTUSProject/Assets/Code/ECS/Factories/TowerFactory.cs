using Entitas;
using UnityEngine;
using Zenject;

public class TowerFactory
{
    private readonly GameContext _context;
    private readonly DiContainer _container;
    private readonly TowerConfigs _towerConfig;
    private readonly IPlayerProgressService _playerProgress;

    public TowerFactory(Contexts contexts, DiContainer container, 
                        TowerConfigs towerConfig, IPlayerProgressService playerProgress)
    {
        _context = contexts.game;
        _container = container;
        _towerConfig = towerConfig;
        _playerProgress = playerProgress;
    }

    public GameEntity CreateTower(WeaponType type, Vector3 position)
    {
        var entity = _context.CreateEntity();
        var stats = _playerProgress.GetTowerStats(_towerConfig.Id);
        entity.isTowerTag = true;
        entity.isCanShoot = true;

        entity.AddHealth(stats.Health);
        entity.AddPosition(position);
        entity.AddAttackRange(stats.Range);
        entity.AddDamage(stats.Damage);
        var cooldown = Mathf.Max(0.05f, stats.FireRate);
        entity.AddAttackCooldown(cooldown);
        entity.AddAttackTimer(0);

        entity.AddWeapon(type, 8f);

        entity.isDestructible = true;

        var view = _container.InstantiatePrefabForComponent<TowerView>(
            _towerConfig.Prefab,
            position,
            Quaternion.identity,
            null);

        view.Initialize(entity);
        entity.AddView(view);
        Debug.Log(entity.health.value + "Health");
        return entity;
    }
}

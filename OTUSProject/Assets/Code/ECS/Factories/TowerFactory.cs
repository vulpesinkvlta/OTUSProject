using Code.Infrastructure.Data;
using Entitas;
using System.Collections.Generic;
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
        return CreateTower(_towerConfig.Id, type, position);
    }
    public GameEntity CreateTower(string towerId, WeaponType type, Vector3 position)
    {
        GameEntity entity = _context.CreateEntity();
        TowerStats stats = _playerProgress.GetTowerStats(towerId);
        entity.isTowerTag = true;
        entity.isCanShoot = true;

        entity.AddHealth(stats.Health);
        entity.AddPosition(position);
        entity.AddAttackRange(stats.Range);
        entity.AddHitRadius(_towerConfig.HitRange);
        entity.AddDamage(stats.Damage);
        float cooldown = Mathf.Max(0.05f, stats.FireRate);
        entity.AddAttackCooldown(cooldown);
        entity.AddAttackTimer(0);

        entity.AddWeapon(type, 8f);

        entity.isDestructible = true;

        TowerView view = _container.InstantiatePrefabForComponent<TowerView>(
            _towerConfig.Prefab,
            position,
            Quaternion.identity,
            null);

        view.Initialize(entity);
        entity.AddView(view);
        Debug.Log(entity.health.value + "Health");
        return entity;
    }

    public IReadOnlyList<PlacedTowerData> CapturePlacedTowers()
    {
        List<PlacedTowerData> placedTowers = new List<PlacedTowerData>();
        IGroup<GameEntity> towers = _context.GetGroup(GameMatcher.AllOf(GameMatcher.TowerTag, GameMatcher.Position, GameMatcher.Weapon));

        foreach (GameEntity tower in towers)
        {
            placedTowers.Add(new PlacedTowerData
            {
                TowerId = _towerConfig.Id,
                WeaponType = tower.weapon.Type,
                Position = tower.position.value
            });
        }

        return placedTowers;
    }
}

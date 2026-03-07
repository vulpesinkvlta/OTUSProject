using Code.Infrastructure.Data;
using Entitas;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class EnemyFactory  
{
    private readonly GameContext _context;
    private readonly DiContainer _container;

    private readonly Dictionary<EnemyType, EnemyConfig> _configs = new Dictionary<EnemyType, EnemyConfig>();
    public EnemyFactory(
        Contexts contexts,
        DiContainer container,
        EnemyConfig[] configs)
    {
        _context = contexts.game;
        _container = container;
        _configs = configs.ToDictionary(conf => conf.EnemyType);
        Debug.Log(Contexts.sharedInstance.GetHashCode());
    }

    public GameEntity Create(EnemyType enemyType, Vector3 position)
    {
        var enemyConfig = _configs[enemyType];
        var entity = _context.CreateEntity();

        entity.isEnemyTag = true;

        if (enemyType == EnemyType.Range)
        {
            entity.isRangedAttacker = true;
        }
        else
        {
            entity.isMeleeAttacker = true;
        }

        entity.AddPosition(position);
        entity.AddHealth(enemyConfig.Health);
        entity.AddDamage(enemyConfig.Damage);
        entity.AddMoveSpeed(enemyConfig.Speed);

        entity.AddAttackRange(enemyConfig.AttackRange);
        entity.AddAttackCooldown(enemyConfig.AttakcCooldown);
        entity.AddAttackTimer(0);

        entity.AddWeapon(
            enemyType == EnemyType.Melee
                ? WeaponType.Melee
                : WeaponType.Projectile,
            8f);

        entity.isCanShoot = true;
        entity.isDestructible = true;

        var view = _container.InstantiatePrefabForComponent<EnemyView>(
            enemyConfig.Prefab,
            position,
            Quaternion.identity,
            null);

        view.Initialize(entity);
        entity.AddView(view);

        return entity;
    }
}


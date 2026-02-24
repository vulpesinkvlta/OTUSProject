using Entitas;
using UnityEngine;
using Zenject;

public class EnemyFactory  
{
    private readonly GameContext _context;
    private readonly DiContainer _container;
    private readonly EnemyView _enemyPrefab;

    private readonly IGroup<GameEntity> _targets;

    public EnemyFactory(
        Contexts contexts,
        DiContainer container,
        EnemyView enemyPrefab)
    {
        _context = contexts.game;
        _container = container;
        _enemyPrefab = enemyPrefab;
        _targets = contexts.game.GetGroup(GameMatcher.AllOf
                (GameMatcher.TowerTag, 
                GameMatcher.Position));
    }

    public GameEntity Create(Vector3 position)
    {
        var towers = _targets.GetEntities();

        if (towers.Length == 0)
            return null;

        var tower = towers[0];

        var entity = _context.CreateEntity();

        entity.isEnemyTag = true;
        entity.AddPosition(position);
        entity.AddHealth(50);
        entity.AddDamage(10);
        entity.AddMoveSpeed(3f);
        entity.AddAttackRange(1.5f);
        entity.AddAttackCooldown(1f);
        entity.AddAttackTimer(0);
        entity.AddTarget(tower);

        var view = _container.InstantiatePrefabForComponent<EnemyView>(
            _enemyPrefab,
            position,
            Quaternion.identity,
            null);

        view.Initialize(entity);
        entity.AddView(view);

        return entity;
    }
}


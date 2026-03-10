using Entitas;
using UnityEngine;

public class EnemyTargetSelectionSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _enemies;
    private readonly IGroup<GameEntity> _towers;
    private readonly IGroup<GameEntity> _throne;
    private readonly GameContext _context;

    public EnemyTargetSelectionSystem(Contexts contexts)
    {
        _context = contexts.game;

        _enemies = _context.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.EnemyTag,
                GameMatcher.Position));

        _towers = _context.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.TowerTag,
                GameMatcher.Position));

        _throne = _context.GetGroup(GameMatcher.ThroneTag);
    }

    public void Execute()
    {
        var throne = GetThrone();

        foreach (var enemy in _enemies)
        {
            if (IsTargetValid(enemy))
                continue;

            GameEntity closest = FindClosestTower(enemy);

            if (closest == null)
                closest = throne;

            if (closest != null)
                enemy.ReplaceTarget(closest);
        }
    }

    private bool IsTargetValid(GameEntity enemy)
    {
        if (!enemy.hasTarget)
            return false;

        var target = enemy.target.value;

        return target != null
            && target.isEnabled
            && target.hasPosition
            && target.hasHealth;
    }
    private GameEntity FindClosestTower(GameEntity enemy)
    {
        GameEntity closest = null;
        float minDist = float.MaxValue;

        foreach (var tower in _towers)
        {
            float dist = (enemy.position.value -
                          tower.position.value).sqrMagnitude;

            if (dist < minDist)
            {
                minDist = dist;
                closest = tower;
            }
        }

        return closest;
    }

    private GameEntity GetThrone()
    {
        var throneGroup = _context.GetGroup(GameMatcher.AllOf(GameMatcher.ThroneTag).NoneOf(GameMatcher.SpawnPoint));

        return throneGroup.count > 0
            ? throneGroup.GetSingleEntity()
            : null;
    }
}
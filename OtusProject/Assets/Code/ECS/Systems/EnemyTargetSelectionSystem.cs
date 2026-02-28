using Entitas;
using UnityEngine;

public class EnemyTargetSelectionSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _enemies;
    private readonly IGroup<GameEntity> _towers;
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
    }

    public void Execute()
    {
        var throneGroup = _context.GetGroup(GameMatcher.ThroneTag);

        GameEntity throne =
            throneGroup.count > 0
                ? throneGroup.GetSingleEntity()
                : null;

        foreach (var enemy in _enemies)
        {
            if (enemy.hasTarget &&
                enemy.target.value != null &&
                enemy.target.value.hasHealth)
                continue;

            GameEntity closest = null;
            float minDist = float.MaxValue;

            foreach (var tower in _towers)
            {
                float dist = Vector3.SqrMagnitude(
                    enemy.position.value -
                    tower.position.value);

                if (dist < minDist)
                {
                    minDist = dist;
                    closest = tower;
                }
            }

            if (closest == null)
                closest = throne;

            enemy.ReplaceTarget(closest);
        }
    }
}
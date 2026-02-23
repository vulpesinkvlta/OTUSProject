using Entitas;
using UnityEngine;

public class EnemyTargetSelectionSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _enemies;
    private readonly IGroup<GameEntity> _towers;
    private readonly IGroup<GameEntity> _throne;

    public EnemyTargetSelectionSystem(GameContext context)
    {
        _enemies = context.GetGroup(GameMatcher.EnemyTag);
        _towers = context.GetGroup(GameMatcher.TowerTag);
        _throne = context.GetGroup(GameMatcher.ThroneTag);
    }

    public void Execute()
    {
        foreach (var enemy in _enemies)
        {
            if (enemy.hasTarget) continue;

            GameEntity closest = null;
            float minDist = float.MaxValue;

            foreach (var tower in _towers)
            {
                float dist = Vector3.Distance(
                    enemy.position.value,
                    tower.position.value);

                if (dist < minDist)
                {
                    minDist = dist;
                    closest = tower;
                }
            }

            if (closest == null)
                closest = _throne.GetSingleEntity();

            enemy.AddTarget(closest);
        }
    }
}
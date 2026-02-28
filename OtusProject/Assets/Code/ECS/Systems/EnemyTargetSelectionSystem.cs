using Entitas;
using UnityEngine;

public class EnemyTargetSelectionSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _enemies;
    private readonly IGroup<GameEntity> _towers;
    private readonly IGroup<GameEntity> _throne;

    private readonly GameContext context;
    public EnemyTargetSelectionSystem(Contexts contexts)
    {
        context = contexts.game;
        _enemies = context.GetGroup(GameMatcher.EnemyTag);
        _towers = context.GetGroup(GameMatcher.TowerTag);
        _throne = context.GetGroup(GameMatcher.ThroneTag);
    }

    public void Execute()
    {
        foreach (var enemy in _enemies)
        {
            if (enemy.hasTarget) continue;

            GameEntity closestTower = null;
            float minDist = float.MaxValue;

            foreach (var tower in _towers)
            {
                float dist = Vector3.Distance(
                    enemy.position.value,
                    tower.position.value);

                if (dist < minDist)
                {
                    minDist = dist;
                    closestTower = tower;
                }
            }

            if (closestTower == null)
                closestTower = _throne.GetSingleEntity();

            enemy.AddTarget(closestTower);
        }

        foreach (var tower in _towers)
        {
            if (tower.hasTarget) continue;

            GameEntity closestEnemy = null;
            float minDist = float.MaxValue;

            foreach (var enemy in _enemies)
            {
                float dist = Vector3.Distance(
                    enemy.position.value,
                    tower.position.value);

                if (dist < minDist)
                {
                    minDist = dist;
                    closestEnemy = tower;
                }
            }

            if (closestEnemy == null)
                return;
            tower.AddTarget(closestEnemy);  
        }
    }
}
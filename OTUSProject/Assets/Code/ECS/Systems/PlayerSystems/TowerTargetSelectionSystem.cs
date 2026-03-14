using Entitas;
using UnityEngine;
public class TowerTargetSelectionSystem : IExecuteSystem
{

    private readonly IGroup<GameEntity> _towers;
    private readonly IGroup<GameEntity> _enemies;

    public TowerTargetSelectionSystem(Contexts contexts)
    {
        var context = contexts.game;

        _towers = context.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.TowerTag,
                GameMatcher.Position));

        _enemies = context.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.EnemyTag,
                GameMatcher.Position,
                GameMatcher.Health));
    }

    public void Execute()
    {
        if (_enemies.count == 0)
            return;

        foreach (var tower in _towers)
        {
            if (tower.hasTarget &&
                tower.target.value != null &&
                tower.target.value.hasHealth)
                continue;

            GameEntity closestEnemy = null;
            float minDist = float.MaxValue;

            foreach (var enemy in _enemies)
            {
                float sqrDist = Vector3.SqrMagnitude(
                    tower.position.value -
                    enemy.position.value);

                if (sqrDist < minDist)
                {
                    minDist = sqrDist;
                    closestEnemy = enemy;
                }
            }

            if (closestEnemy == null)
                continue;

            tower.ReplaceTarget(closestEnemy);
        }
    }
}


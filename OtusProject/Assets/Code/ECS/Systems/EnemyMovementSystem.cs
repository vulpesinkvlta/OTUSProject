using Entitas;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class EnemyMovementSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _enemies;

    public EnemyMovementSystem(GameContext context)
    {
        _enemies = context.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.EnemyTag,
                GameMatcher.Path,
                GameMatcher.Position,
                GameMatcher.MoveSpeed));
    }

    public void Execute()
    {
        foreach (var enemy in _enemies)
        {
            if (!enemy.hasTarget)
                continue;

            var targetEntity = enemy.target.value;

            if (!targetEntity.hasPosition)
                continue;

            float distanceToTarget = Vector3.Distance(
                enemy.position.value,
                targetEntity.position.value);

            if (enemy.hasAttackRange &&
                distanceToTarget <= enemy.attackRange.value)
            {
                continue;
            }

            var path = enemy.path.waypoints;
            int index = enemy.path.currentIndex;

            if (index >= path.Count)
                continue;

            Vector3 target = path[index];

            Vector3 newPos = Vector3.MoveTowards(
                enemy.position.value,
                target,
                enemy.moveSpeed.value * Time.deltaTime);

            enemy.ReplacePosition(newPos);

            if (Vector3.Distance(newPos, target) < 0.1f)
                enemy.ReplacePath(path, index + 1);
        }
    }
}
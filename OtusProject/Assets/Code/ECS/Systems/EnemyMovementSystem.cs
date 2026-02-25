using Entitas;
using UnityEngine;

public class EnemyMovementSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _enemies;

    public EnemyMovementSystem(Contexts contexts)
    {
        _enemies = contexts.game.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.EnemyTag,
                GameMatcher.Position,
                GameMatcher.MoveSpeed,
                GameMatcher.Target,
                GameMatcher.AttackRange
            ));
    }

    public void Execute()
    {
        foreach (var enemy in _enemies)
        {
            var target = enemy.target.value;

            if (target == null || !target.hasPosition)
                continue;

            float distance = Vector3.Distance(enemy.position.value, target.position.value);

            if (distance <= enemy.attackRange.value)
                continue;

            Vector3 direction = (target.position.value - enemy.position.value).normalized;

            Vector3 targetPostion = enemy.position.value + direction * enemy.moveSpeed.value * Time.deltaTime;
            enemy.ReplacePosition(targetPostion);
        }
    }
}
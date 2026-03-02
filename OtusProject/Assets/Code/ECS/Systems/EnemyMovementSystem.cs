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
        Debug.Log("EnemyMovementSystem created");
    }

    public void Execute()
    {
        Debug.Log("Enemies in movement group: " + _enemies.count);
        foreach (var e in _enemies)
        {
            Debug.Log(
                $"Enemy components: " +
                $"Pos:{e.hasPosition} " +
                $"Speed:{e.hasMoveSpeed} " +
                $"Target:{e.hasTarget}"
            );
        }
        foreach (var enemy in _enemies)
        {
            if (!enemy.hasTarget)
                continue;

            if (enemy.isInAttackRange)
                continue;

            var target = enemy.target.value;

            if (!target.hasPosition)
                continue;

            Vector3 dir =
                (target.position.value - enemy.position.value).normalized;

            enemy.ReplacePosition(
                enemy.position.value +
                dir * enemy.moveSpeed.value * Time.deltaTime);
        }
    }
}
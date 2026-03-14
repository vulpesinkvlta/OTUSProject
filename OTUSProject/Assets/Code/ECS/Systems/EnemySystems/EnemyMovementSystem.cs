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
                GameMatcher.Velocity));
    }

    public void Execute()
    {
        float dt = Time.deltaTime;

        foreach (var enemy in _enemies)
        {
            Vector3 dir = enemy.velocity.value;

            if (dir == Vector3.zero)
                continue;

            dir.Normalize();

            enemy.ReplacePosition(
                enemy.position.value +
                dir * enemy.moveSpeed.value * dt);
        }
    }
}
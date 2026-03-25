using Entitas;
using UnityEngine;

public class EnemyRotationSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _enemies;

    public EnemyRotationSystem(Contexts contexts)
    {
        _enemies = contexts.game.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.EnemyTag,
                GameMatcher.Position,
                GameMatcher.Target));
    }

    public void Execute()
    {
        foreach (var enemy in _enemies)
        {
            var target = enemy.target.value;

            if (target == null || !target.hasPosition)
                continue;

            Vector3 dir = target.position.value - enemy.position.value;

            if (dir == Vector3.zero)
                continue;

            dir.Normalize();

            enemy.ReplaceLookDirection(dir);
        }
    }
}
using Entitas;
using UnityEngine;

public class EnemyDesiredDirectionSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _enemies;

    public EnemyDesiredDirectionSystem(Contexts contexts)
    {
        _enemies = contexts.game.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.EnemyTag,
                GameMatcher.Position,
                GameMatcher.Target,
                GameMatcher.MoveSpeed));
    }

    public void Execute()
    {
        foreach (var enemy in _enemies)
        {
            if (!enemy.hasTarget)
                continue;

            var target = enemy.target.value;

            if (!target.hasPosition)
                continue;

            Vector3 dir =
                target.position.value - enemy.position.value;

            float dist = dir.magnitude;

            dir.Normalize();

            if (enemy.isRangedAttacker &&
                dist <= enemy.attackRange.value * 0.95f)
            {
                dir = Vector3.zero;
            }

            if (enemy.hasVelocity)
                enemy.ReplaceVelocity(dir);
            else
                enemy.AddVelocity(dir);
        }
    }
}
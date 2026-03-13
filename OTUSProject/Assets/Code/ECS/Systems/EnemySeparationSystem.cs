using Entitas;
using UnityEngine;

public class EnemySeparationSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _enemies;

    const float SeparationWeight = 2.2f;

    public EnemySeparationSystem(Contexts contexts)
    {
        _enemies = contexts.game.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.EnemyTag,
                GameMatcher.Position,
                GameMatcher.Radius,
                GameMatcher.Velocity));
    }

    public void Execute()
    {
        var enemies = _enemies.GetEntities();

        foreach (var enemy in enemies)
        {
            Vector3 separation = Vector3.zero;

            foreach (var other in enemies)
            {
                if (enemy == other)
                    continue;

                Vector3 diff =
                    enemy.position.value - other.position.value;

                float dist = diff.magnitude;

                float desired =
                    enemy.radius.Value + other.radius.Value;

                if (dist < desired && dist > 0.01f)
                {
                    separation += diff.normalized * (desired - dist);
                }
            }

            if (separation != Vector3.zero)
            {
                enemy.ReplaceVelocity(
                    enemy.velocity.value +
                    separation * SeparationWeight);
            }
        }
    }
}
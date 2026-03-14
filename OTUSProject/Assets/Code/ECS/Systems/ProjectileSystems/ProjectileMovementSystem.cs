using Entitas;
using UnityEngine;

public class ProjectileMovementSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _projectiles;

    public ProjectileMovementSystem(Contexts contexts)
    {
        _projectiles = contexts.game.GetGroup(GameMatcher.AllOf(
                        GameMatcher.MoveDirection,
                        GameMatcher.Position,
                        GameMatcher.MoveSpeed,
                        GameMatcher.Projectile));
    }
    public void Execute()
    {
        float delta = Time.deltaTime;

        foreach (var entity in _projectiles)
        {
            Vector3 newPosition = entity.position.value + entity.moveDirection.value * entity.moveSpeed.value * delta;
            entity.ReplacePosition(newPosition);    
        }
    }
}

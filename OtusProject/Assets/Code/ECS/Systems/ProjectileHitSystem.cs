using Entitas;
using UnityEngine;

public class ProjectileHitSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _projectiles;

    public ProjectileHitSystem(Contexts contexts)
    {
        _projectiles = contexts.game.GetGroup(GameMatcher.AllOf(
                    GameMatcher.Projectile,
                    GameMatcher.Position,
                    GameMatcher.Damage,
                    GameMatcher.Target));
    }
    public void Execute()
    {  
        foreach(var projectile in _projectiles)
        {
            var target = projectile.target.value;

            if (target == null || !target.hasPosition || !target.hasHealth)
                continue;
            float hitRadius = 3f;
            float sqrDist =
             (projectile.position.value - target.position.value).sqrMagnitude;

            if (sqrDist <= hitRadius * hitRadius)
            {
                target.ReplaceHealth(
                    target.health.value - projectile.damage.value);
                Debug.Log($"Получен урон: {target.health.value}");

               // projectile.isDestroyed = true;
            }

        }
    }
}


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

            float distance = Vector3.Distance(projectile.position.value, target.position.value);
                
            if(distance < 0.5f)
            {
                target.ReplaceHealth(target.health.value - projectile.damage.value);
                projectile.Destroy();
                break;
            }
            
        }
    }
}


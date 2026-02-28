using Entitas;
using UnityEngine;

public class ProjectileHitSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _targets;
    private readonly IGroup<GameEntity> _projectiles;

    public ProjectileHitSystem(Contexts contexts)
    {
        _targets = contexts.game.GetGroup(GameMatcher.AllOf(
                    GameMatcher.Health,
                    GameMatcher.Target,
                    GameMatcher.Position));

        _projectiles = contexts.game.GetGroup(GameMatcher.AllOf(
                    GameMatcher.Projectile,
                    GameMatcher.Position,
                    GameMatcher.Damage));
    }
    public void Execute()
    {
        var targets = _targets.GetEntities();
        var projectiles = _projectiles.GetEntities();
    
        foreach(var projectile in projectiles)
        {
            Vector3 projectilePostion = projectile.position.value;

            foreach (var target in targets)
            {
                float distance = Vector3.Distance(target.position.value, projectilePostion);
                
                if(distance < 1f)
                {
                    target.ReplaceHealth(target.health.value - projectile.damage.value);
                    break;
                }
            }
        }
    }
}


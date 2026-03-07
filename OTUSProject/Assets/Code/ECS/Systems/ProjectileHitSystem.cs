using Entitas;
using UnityEngine;

public class ProjectileHitSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _projectiles;
    private readonly GameContext _context;

    public ProjectileHitSystem(Contexts contexts)
    {
        _projectiles = contexts.game.GetGroup(GameMatcher.AllOf(
                    GameMatcher.Projectile,
                    GameMatcher.Position,
                    GameMatcher.Damage,
                    GameMatcher.Target
                    ));
        _context = contexts.game;
    }
    public void Execute()
    {
        var projectiles = _projectiles.GetEntities();

        foreach (var projectile in projectiles)
        {
            var target = projectile.target.value;

            if (target == null || !target.hasPosition)
                continue;

            float distance =
                Vector3.Distance(
                    projectile.position.value,
                    target.position.value);

            if (distance < 0.5f)
            {
                var damage = _context.CreateEntity();

                damage.AddDamageEvent(
                    target,
                    projectile.damage.value);
                projectile.isDestroyed = true;
            }
        }
    }
}


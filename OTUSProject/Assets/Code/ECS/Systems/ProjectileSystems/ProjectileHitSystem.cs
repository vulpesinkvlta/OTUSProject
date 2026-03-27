using Entitas;
using UnityEngine;

public class ProjectileHitSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _projectiles;
    private readonly IGroup<GameEntity> _targets;
    private readonly GameContext _context;

    public ProjectileHitSystem(Contexts contexts)
    {
        _context = contexts.game;

        _projectiles = _context.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.Projectile,
                GameMatcher.Position,
                GameMatcher.Damage)
            .NoneOf(GameMatcher.Destroyed));

        _targets = _context.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.Position,
                GameMatcher.Health)
        .NoneOf(GameMatcher.Projectile));
    }

    public void Execute()
    {
        var projectiles = _projectiles.GetEntities();
        var targets = _targets.GetEntities();

        foreach (var projectile in projectiles)
        {
            foreach (var target in targets)
            {
                float distance = Vector3.Distance(
                    projectile.position.value,
                    target.position.value);

                if (distance < 0.5f)
                {
                    var damage = _context.CreateEntity();

                    damage.AddDamageEvent(
                        target,
                        projectile.damage.value);

                    projectile.isDestroyed = true;
                    break;
                }
            }
        }
    }
}
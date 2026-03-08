using Entitas;
using UnityEngine;

public class ProjectileHitSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _projectiles;
    private readonly IGroup<GameEntity> _enemies;
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

        _enemies = _context.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.EnemyTag,
                GameMatcher.Position,
                GameMatcher.Health));
    }

    public void Execute()
    {
        var projectiles = _projectiles.GetEntities();
        var enemies = _enemies.GetEntities();

        foreach (var projectile in projectiles)
        {
            foreach (var enemy in enemies)
            {
                float distance = Vector3.Distance(
                    projectile.position.value,
                    enemy.position.value);

                if (distance < 0.5f)
                {
                    var damage = _context.CreateEntity();

                    damage.AddDamageEvent(
                        enemy,
                        projectile.damage.value);

                    projectile.isDestroyed = true;
                    break;
                }
            }
        }
    }
}
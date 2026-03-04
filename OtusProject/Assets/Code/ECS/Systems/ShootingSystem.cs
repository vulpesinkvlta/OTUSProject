using Entitas;
using UnityEngine;

public class ShootingSystem : IExecuteSystem
{
    private readonly GameContext _context;
    private readonly IGroup<GameEntity> _shooters;

    public ShootingSystem(Contexts contexts)
    {
        _context = contexts.game;

        _shooters = _context.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.CanShoot,
                GameMatcher.Position,
                GameMatcher.Target,
                GameMatcher.InAttackRange));
    }

    public void Execute()
    {
        var shooters = _shooters.GetEntities();

        foreach (var shooter in shooters)
        {
            var target = shooter.target.value;

            if (target == null || !target.hasPosition)
                continue;

            Vector3 dir =
                (target.position.value - shooter.position.value).normalized;

            var projectile = _context.CreateEntity();

            projectile.isProjectile = true;
            projectile.AddPosition(shooter.position.value + dir * 1.2f);
            projectile.AddMoveDirection(dir);
            projectile.AddMoveSpeed(8f);
            projectile.AddDamage(1);
            projectile.AddTarget(target);

            shooter.isCanShoot = false;
        }
    }
}
using Entitas;
using UnityEngine;

public class ShootingSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _projectiles;
    private readonly GameContext _gameContext;
    public ShootingSystem(Contexts context)
    {
        _gameContext = context.game;
        _projectiles = context.game.GetGroup(GameMatcher.AllOf(
                        GameMatcher.Projectile,
                        GameMatcher.MoveSpeed,
                        GameMatcher.CanShoot,
                        GameMatcher.Position,
                        GameMatcher.AttackCooldown,
                        GameMatcher.AttackTimer,
                        GameMatcher.MoveDirection,
                        GameMatcher.Target));
    }
    public void Execute()
    {
        foreach (var entity in _projectiles)
        {
            if (entity.attackCooldown.value > 0f)
                continue;

            var target = entity.target.value;

            Vector3 projectilePos = entity.position.value + entity.moveDirection.value * 1.5f;
            Vector3 projectileDirection = (target.position.value - projectilePos).normalized;
            Vector3 newPosition = entity.position.value + projectileDirection * entity.moveSpeed.value * Time.deltaTime;

            var projectile = _gameContext.CreateEntity();
            projectile.isProjectile = true;
            projectile.AddDamage(1);
            projectile.AddMoveSpeed(3);
            projectile.AddPosition(projectilePos);
            projectile.AddMoveDirection(projectileDirection);
            projectile.AddTarget(target);
            projectile.AddAttackCooldown(1);
            //projectile.AddLifeTime(5f);
            projectile.ReplaceAttackCooldown(0.5f);

            
        }
    }
}

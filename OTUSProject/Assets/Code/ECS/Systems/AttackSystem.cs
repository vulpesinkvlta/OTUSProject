using Entitas;
using UnityEngine;

public class AttackSystem : IExecuteSystem
{
    private readonly GameContext _context;
    private readonly IGroup<GameEntity> _attackers;

    public AttackSystem(Contexts contexts)
    {
        _context = contexts.game;

        _attackers = _context.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.Weapon,
                GameMatcher.CanShoot,
                GameMatcher.Target,
                GameMatcher.Position,
                GameMatcher.InAttackRange));
    }

    public void Execute()
    {
        var attackers = _attackers.GetEntities();

        foreach (var entity in attackers)
        {
            var target = entity.target.value;

            if (target == null || !target.hasPosition)
                continue;

            switch (entity.weapon.Type)
            {
                case WeaponType.Melee:
                    DoMeleeAttack(entity, target);
                    break;

                case WeaponType.Projectile:
                    ShootProjectile(entity, target);
                    break;
            }

            entity.isCanShoot = false;
            entity.ReplaceAttackTimer(entity.attackCooldown.value);
        }
    }

    private void DoMeleeAttack(GameEntity attacker, GameEntity target)
    {
        var damage = _context.CreateEntity();

        damage.AddDamageEvent(
            target,
            attacker.damage.value);
    }

    private void ShootProjectile(GameEntity attacker, GameEntity target)
    {
        Vector3 dir =
            (target.position.value - attacker.position.value).normalized;

        var projectile = _context.CreateEntity();

        projectile.isProjectile = true;
        projectile.AddPosition(attacker.position.value + dir * 1.2f);
        projectile.AddMoveDirection(dir);
        projectile.AddMoveSpeed(attacker.weapon.ProjectileSpeed);
        projectile.AddDamage(attacker.damage.value);
        projectile.AddTarget(target);
    }
}
using Entitas;

public class MeleeAttackSystem : IExecuteSystem
{
    private readonly GameContext _context;
    private readonly IGroup<GameEntity> _attackers;

    public MeleeAttackSystem(Contexts contexts)
    {
        _context = contexts.game;

        _attackers = _context.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.MeleeAttacker,
                GameMatcher.CanShoot,
                GameMatcher.Target,
                GameMatcher.Damage,
                GameMatcher.InAttackRange));
    }

    public void Execute()
    {
        var attackers = _attackers.GetEntities();

        foreach (var enemy in attackers)
        {
            var target = enemy.target.value;

            if (target == null)
                continue;

            var damage = _context.CreateEntity();

            damage.AddDamageEvent(
                target,
                enemy.damage.value);

            enemy.isCanShoot = false;
            enemy.ReplaceAttackTimer(enemy.attackCooldown.value);
        }
    }
}
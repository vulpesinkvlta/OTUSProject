using Entitas;
using UnityEngine;

public class AttackTimerSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _attackers;

    public AttackTimerSystem(Contexts contexts)
    {
        _attackers = contexts.game.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.AttackTimer,
                GameMatcher.AttackCooldown));
    }

    public void Execute()
    {
        float delta = Time.deltaTime;

        var attackers = _attackers.GetEntities();

        foreach (var entity in attackers)
        {
            if (entity.isCanShoot)
                continue;

            float timer = entity.attackTimer.value - delta;

            if (timer > 0f)
            {
                entity.ReplaceAttackTimer(timer);
                continue;
            }

            entity.ReplaceAttackTimer(0f);
            entity.isCanShoot = true;
        }
    }
}
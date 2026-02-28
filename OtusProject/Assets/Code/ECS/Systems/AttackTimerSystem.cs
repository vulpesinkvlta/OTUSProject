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
                GameMatcher.AttackCooldown,
                GameMatcher.InAttackRange,
                GameMatcher.Target));
    }

    public void Execute()
    {
        float delta = Time.deltaTime;

        foreach (var entity in _attackers)
        {
            float timer = entity.attackTimer.value - delta;

            if (timer > 0f)
            {
                entity.ReplaceAttackTimer(timer);
                continue;
            }

            entity.isCanShoot = true;
        }
    }
}
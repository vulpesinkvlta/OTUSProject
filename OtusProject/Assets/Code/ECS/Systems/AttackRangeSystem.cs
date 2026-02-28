using Entitas;
using UnityEngine;

public class AttackRangeSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _attackers;

    public AttackRangeSystem(Contexts contexts)
    {
        _attackers = contexts.game.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.AttackRange,
                GameMatcher.Position,
                GameMatcher.Target));
    }

    public void Execute()
    {
        foreach (var entity in _attackers)
        {
            var target = entity.target.value;

            if (target == null || !target.hasPosition)
            {
                entity.isInAttackRange = false;
                continue;
            }

            float sqrDist =
                (entity.position.value - target.position.value).sqrMagnitude;

            float range = entity.attackRange.value;

            entity.isInAttackRange = sqrDist <= range * range;
        }
    }
}
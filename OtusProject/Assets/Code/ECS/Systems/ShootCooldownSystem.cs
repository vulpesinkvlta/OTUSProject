using Entitas;
using UnityEngine;

public class ShootCooldownSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _entities;
    public ShootCooldownSystem(Contexts context)
    {
        _entities = context.game.GetGroup(GameMatcher.AllOf(
                    GameMatcher.AttackCooldown));
    }
    public void Execute()
    {
        float delta = Time.deltaTime;

        foreach (var entity in _entities.GetEntities())
        {
            if (entity.attackCooldown.value > 0)
                entity.ReplaceAttackCooldown(entity.attackCooldown.value - delta);
        }
    }
}


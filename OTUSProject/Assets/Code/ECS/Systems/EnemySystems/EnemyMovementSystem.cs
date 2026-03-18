using Entitas;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyMovementSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _enemies;

    public EnemyMovementSystem(Contexts contexts)
    {
        _enemies = contexts.game.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.EnemyTag,
                GameMatcher.Position,
                GameMatcher.MoveSpeed,
                GameMatcher.Velocity));
    }

    public void Execute()
    {
        float dt = Time.deltaTime;

        foreach (var enemy in _enemies)
        {
            if (enemy.isInAttackRange && enemy.weapon.Type == WeaponType.Melee)
                continue;

            Vector3 dir = enemy.velocity.value;

            if (dir == Vector3.zero)
                continue;

            dir.Normalize();

            enemy.ReplacePosition(
                enemy.position.value +
                dir * enemy.moveSpeed.value * dt);
        }
    }
}
using Entitas;
using UnityEngine;

public class EnemyAttackSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _enemies;

    public EnemyAttackSystem(Contexts contexts)
    {
        _enemies = contexts.game.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.EnemyTag,
                GameMatcher.Target,
                GameMatcher.Position,
                GameMatcher.Damage,
                GameMatcher.AttackRange,
                GameMatcher.AttackCooldown,
                GameMatcher.AttackTimer));
    }

    public void Execute()
    {
        foreach (var enemy in _enemies)
        {
            var target = enemy.target.value;

            if (!target.hasHealth)
                continue;

            float distance = Vector3.Distance(
                enemy.position.value,
                target.position.value);

            if (distance > enemy.attackRange.value)
                continue;

            enemy.ReplaceAttackTimer(
                enemy.attackTimer.value + Time.deltaTime);

            if (enemy.attackTimer.value < enemy.attackCooldown.value)
                continue;

            target.ReplaceHealth(
                target.health.value - enemy.damage.value);
            Debug.Log(target.health.value);

            enemy.ReplaceAttackTimer(0);
        }
    }
}
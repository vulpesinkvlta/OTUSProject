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
                GameMatcher.Damage,
                GameMatcher.CanShoot,
                GameMatcher.InAttackRange));
    }

    public void Execute()
    {
        foreach (var enemy in _enemies)
        {
            var target = enemy.target.value;

            if (target == null || !target.hasHealth)
                continue;

            target.ReplaceHealth(
                target.health.value - enemy.damage.value);

            Debug.Log("Башня получила урон: " + target.health.value);

            enemy.isCanShoot = false;
        }
    }
}
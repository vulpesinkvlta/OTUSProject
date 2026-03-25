using Entitas;
using UnityEngine;

public class EnemyAnimationSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _enemies;

    public EnemyAnimationSystem(Contexts contexts)
    {
        _enemies = contexts.game.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.EnemyTag,
                GameMatcher.Velocity));
    }

    public void Execute()
    {
        foreach (var enemy in _enemies)
        {
            if (enemy.isInAttackRange)
            {
                enemy.ReplaceAnimationState(AnimationState.Attack);
                continue;
            }

            if (enemy.velocity.value != Vector3.zero)
            {
                enemy.ReplaceAnimationState(AnimationState.Walk);
            }
            else
            {
                enemy.ReplaceAnimationState(AnimationState.Idle);
            }
        }
    }
}
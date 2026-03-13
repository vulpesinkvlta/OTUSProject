using Entitas;
using UnityEngine;

public class EnemyFlowMovementSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _enemies;

    private readonly FlowFieldService _flow;
    private readonly GridService _grid;

    public EnemyFlowMovementSystem(
        Contexts contexts,
        FlowFieldService flow,
        GridService grid)
    {
        _flow = flow;
        _grid = grid;

        _enemies = contexts.game.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.EnemyTag,
                GameMatcher.Position,
                GameMatcher.MoveSpeed));
    }

    public void Execute()
    {
        float dt = Time.deltaTime;

        foreach (var enemy in _enemies)
        {
            if (enemy.isInAttackRange)
                continue;

            Vector2Int cell = _grid.WorldToCell(enemy.position.value);

            if (!_grid.IsInside(cell))
                continue;

            Vector3 dir = _flow.GetDirection(cell.x, cell.y);

            if (dir == Vector3.zero && enemy.hasTarget)
            {
                dir = (enemy.target.value.position.value - enemy.position.value).normalized;
            }

            enemy.ReplacePosition(
                enemy.position.value +
                dir * enemy.moveSpeed.value * dt);
        }
    }
}
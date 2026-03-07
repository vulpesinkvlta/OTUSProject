using Entitas;

public class EnemyPathSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _enemies;
    private readonly PathService _pathService;

    public EnemyPathSystem(GameContext context, PathService pathService)
    {
        _enemies = context.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.EnemyTag,
                GameMatcher.Target,
                GameMatcher.Position));

        _pathService = pathService;
    }

    public void Execute()
    {
        foreach (var enemy in _enemies)
        {
            if (enemy.hasPath) continue;

            var path = _pathService.CalculatePath(
                enemy.position.value,
                enemy.target.value.position.value);

            enemy.AddPath(path, 0);
        }
    }
}
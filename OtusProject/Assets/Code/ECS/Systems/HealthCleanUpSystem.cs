using Entitas;

public class HealthCleanupSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _entities;

    public HealthCleanupSystem(Contexts contexts)
    {
        _entities = contexts.game.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.Health,
                GameMatcher.Destructible));
    }

    public void Execute()
    {
        foreach (var e in _entities)
        {
            if (e.health.value > 0)
                continue;

            e.Destroy();
        }
    }
}
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
        var entities = _entities.GetEntities();

        foreach (var e in entities)
        {
            if (e.health.value > 0)
                continue;
            e.isDestroyed = true;
        }
    }
}
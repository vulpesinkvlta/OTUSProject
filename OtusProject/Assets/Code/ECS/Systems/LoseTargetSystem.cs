using Entitas;

public class LoseTargetSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _entities;

    public LoseTargetSystem(Contexts contexts)
    {
        _entities = contexts.game.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.Target,
                GameMatcher.Position));
    }

    public void Execute()
    {
        var entities = _entities.GetEntities();

        foreach (var entity in entities)
        {
            var target = entity.target.value;

            if (target == null || !target.hasHealth)
            {
                entity.RemoveTarget();
            }
        }
    }
}
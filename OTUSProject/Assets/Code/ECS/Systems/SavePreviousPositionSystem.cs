using Entitas;

public class SavePreviousPositionSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _entities;

    public SavePreviousPositionSystem(Contexts contexts)
    {
        _entities = contexts.game.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.Projectile,
                GameMatcher.Position));
    }

    public void Execute()
    {
        foreach (var e in _entities)
        {
            if (e.hasPreviousPosition)
                e.ReplacePreviousPosition(e.position.value);
            else
                e.AddPreviousPosition(e.position.value);
        }
    }
}
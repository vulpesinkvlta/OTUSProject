using Entitas;

public class ViewSyncSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _group;

    public ViewSyncSystem(Contexts contexts)
    {
        _group = contexts.game.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.Position,
                GameMatcher.View));
    }

    public void Execute()
    {
        foreach (var entity in _group)
        {
            entity.view.value.transform.position =
                entity.position.value;
        }
    }
}
using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class ViewDestroySystem : ReactiveSystem<GameEntity>
{
    public ViewDestroySystem(Contexts context) : base(context.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Destroyed.Added());
    }
    protected override bool Filter(GameEntity entity)
    {
        return entity.hasView;
    }
    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var view = (MonoBehaviour)entity.view.value;

            Object.Destroy(view.gameObject);

            entity.RemoveView();
            entity.Destroy();
        }
    }
}


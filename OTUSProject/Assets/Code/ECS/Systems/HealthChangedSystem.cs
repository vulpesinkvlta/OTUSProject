using Entitas;
using System.Collections.Generic;

public class HealthChangedSystem : ReactiveSystem<GameEntity>
{
    public HealthChangedSystem(Contexts context) : base(context.game)
    {       
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Health);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasHealth && entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var view = entity.view.value;

            if(view is IHealthView healthView)
               healthView.Set(entity.health.value);
            
        }
    }
}


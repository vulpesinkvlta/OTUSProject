using Entitas;
using System.Collections.Generic;

public class DamageApplySystem : ReactiveSystem<GameEntity>
{
    public DamageApplySystem(Contexts contexts) : base(contexts.game) { }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.DamageEvent.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasDamageEvent;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var damage = e.damageEvent;

            var target = damage.Target;

            if (target != null && target.hasHealth)
            {
                target.ReplaceHealth(
                    target.health.value - damage.Value);
            }

            e.Destroy();
        }
    }
}
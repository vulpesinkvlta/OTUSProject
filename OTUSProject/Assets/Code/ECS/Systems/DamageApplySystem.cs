using Entitas;
using System.Collections.Generic;
using UnityEngine;

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
                if (target.isTowerTag)
                    Debug.Log($"Башня получила урон, здоровье: {target.health.value}");
                else if (target.isEnemyTag)
                    Debug.Log($"Враг {target.view.value} получил урон, здоровье: {target.health.value}");
                else
                    Debug.Log($"Трон получил урон, здоровье: {target.health.value}");

            }

            e.Destroy();
        }
    }
}
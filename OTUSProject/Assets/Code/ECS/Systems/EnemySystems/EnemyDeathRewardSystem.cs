using Entitas;
using System.Collections.Generic;

public class EnemyDeathRewardSystem : ReactiveSystem<GameEntity>
{
    private readonly IExperienceService _xpService;

    public EnemyDeathRewardSystem(Contexts contexts,
        IExperienceService xpService) : base(contexts.game)
    {
        _xpService = xpService;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Destroyed.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isEnemyTag;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var enemy in entities)
        {
            _xpService.AddXP(enemy.rewardedXP.Value);
        }
    }
}
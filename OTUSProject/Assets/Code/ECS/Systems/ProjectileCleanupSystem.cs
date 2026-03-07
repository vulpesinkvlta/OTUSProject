using Entitas;
using System.Collections.Generic;

public class ProjectileCleanupSystem : ReactiveSystem<GameEntity>
{
    private readonly ProjectileViewPool _pool;

    public ProjectileCleanupSystem(Contexts contexts, ProjectileViewPool pool) : base(contexts.game)
    {
        _pool = pool;
    }
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
         => context.CreateCollector(GameMatcher.Projectile.Removed());


    protected override bool Filter(GameEntity entity)
        => entity.hasView;

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var view = (ProjectileView)entity.view.value;
            _pool.Return(view); 
        }
    }
}


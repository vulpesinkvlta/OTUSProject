using Entitas;
using System.Collections.Generic;

public class ProjectileSpawnSystem : ReactiveSystem<GameEntity>
{
    private readonly ProjectileViewPool _pool;

    public ProjectileSpawnSystem(Contexts contexts, ProjectileViewPool pool) : base(contexts.game)
    {
        _pool = pool;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Projectile.Added());
    }

    protected override bool Filter(GameEntity entity)
        => entity.isProjectile && entity.hasPosition;
        
    

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var entity in entities)
        {
            var view = _pool.Get();
        
            view.transform.position = entity.position.value;
            view.Initialize(entity);
            entity.AddView(view);
        }
    }
}


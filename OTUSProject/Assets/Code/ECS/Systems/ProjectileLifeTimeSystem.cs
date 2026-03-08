using Entitas;
using UnityEngine;

public class ProjectileLifeTimeSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _entities;
    public ProjectileLifeTimeSystem(Contexts contexts)
    {
        _entities = contexts.game.GetGroup(GameMatcher.AllOf(
                    GameMatcher.Projectile,
                    GameMatcher.LifeTime).NoneOf(GameMatcher.Destroyed));
    }
    public void Execute()
    {
        float delta = Time.deltaTime;
        foreach (var entity in _entities.GetEntities())
        {
            if (entity.isDestroyed)
                continue;

            float lifeTime = entity.lifeTime.Value - delta;

            if (lifeTime <= 0f)
            {
                entity.isDestroyed = true;
                continue;
            }

            entity.ReplaceLifeTime(lifeTime);
        }
    }
}


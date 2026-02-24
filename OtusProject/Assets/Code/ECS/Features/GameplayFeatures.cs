using Zenject;

public class GameplayFeatures : Feature
{
    public GameplayFeatures(
        Contexts contexts,
        EnemyFactory enemyFactory,
        TowerView towerView,
        DiContainer container) : base("Gameplay")
    {
        Add(new TowerSpawnSystem(contexts, container, towerView));
        Add(new EnemySpawnSystem(enemyFactory));
        Add(new EnemyMovementSystem(contexts));
        Add(new EnemyAttackSystem(contexts));
        Add(new HealthCleanupSystem(contexts));
        Add(new ViewSyncSystem(contexts));
    }
}


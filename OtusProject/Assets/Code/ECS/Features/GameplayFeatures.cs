using Zenject;

public class GameplayFeatures : Feature
{
    public GameplayFeatures(
        Contexts contexts,
        EnemyFactory enemyFactory,
        ProjectileViewPool pool,
        TowerView towerView,
        DiContainer container) : base("Gameplay")
    {
        Add(new ThroneSpawnSystem(contexts));
        Add(new TowerSpawnSystem(contexts, container, towerView));
        Add(new EnemySpawnSystem(enemyFactory));

        Add(new WaveInitSystem(contexts));
        Add(new WaveSpawnSystem(contexts, enemyFactory));

        Add(new EnemyTargetSelectionSystem(contexts));
        Add(new TowerTargetSelectionSystem(contexts));

        Add(new AttackRangeSystem(contexts));
        Add(new LoseTargetSystem(contexts));

        Add(new AttackTimerSystem(contexts));
        Add(new ShootingSystem(contexts));

        Add(new ProjectileSpawnSystem(contexts, pool));
        Add(new ProjectileMovementSystem(contexts));
        Add(new ProjectileHitSystem(contexts));
        Add(new ProjectileCleanupSystem(contexts, pool));

        Add(new EnemyMovementSystem(contexts));
        Add(new EnemyAttackSystem(contexts));

        Add(new HealthCleanupSystem(contexts));

        Add(new EnemyWaveCompleteSystem(contexts));

        Add(new ViewSyncSystem(contexts));
    }
}


using Code.Infrastructure.Services.DI;
using Zenject;

public class GameplayFeatures : Feature
{
    public GameplayFeatures(
        Contexts contexts,
        EnemyFactory enemyFactory,
        ProjectileViewPool pool,
        TowerFactory factory,
        BuildModeService buildMode,
        GridService grid,
        ThroneFactory throneFactory,
        IExperienceService xpService,
        ITowerLimitService towerLimitService) : base("Gameplay")
    {
        Add(new ThroneSpawningSystem(contexts, throneFactory));
        Add(new TowerPlacementSystem(factory, buildMode, grid, towerLimitService));
        Add(new EnemySpawnSystem(enemyFactory));
        Add(new HealthChangedSystem(contexts));
        Add(new WaveInitSystem(contexts));
        Add(new WaveSpawnSystem(contexts, enemyFactory));

        Add(new EnemyTargetSelectionSystem(contexts));
        Add(new TowerTargetSelectionSystem(contexts));

        Add(new AttackRangeSystem(contexts));
        Add(new LoseTargetSystem(contexts));

        Add(new AttackTimerSystem(contexts));

        Add(new EnemyDesiredDirectionSystem(contexts));
        Add(new EnemySeparationSystem(contexts));
        Add(new EnemyMovementSystem(contexts));
        Add(new EnemyAnimationSystem(contexts));
        Add(new EnemyRotationSystem(contexts));
        Add(new AttackSystem(contexts));

        Add(new ProjectileSpawnSystem(contexts, pool));
        Add(new ProjectileMovementSystem(contexts));
        Add(new ProjectileHitSystem(contexts));
        Add(new DamageApplySystem(contexts));
        Add(new ProjectileLifeTimeSystem(contexts));
        Add(new ProjectileCleanupSystem(contexts, pool));


        Add(new HealthCleanupSystem(contexts));
        Add(new EnemyDeathRewardSystem(contexts, xpService));
        Add(new ViewDestroySystem(contexts));

        Add(new EnemyWaveCompleteSystem(contexts));
        Add(new TowerDestroyedSystem(contexts, towerLimitService));

        Add(new ViewSyncSystem(contexts));
    }
}


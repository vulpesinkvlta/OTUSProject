using UnityEngine;
using Zenject;
using Entitas;

public class GameBootstrap : MonoBehaviour
{
    private Systems _systems;

    [Inject]
    public void Construct(
        Contexts contexts,
        EnemyFactory factory,
        ProjectileViewPool pool,
        TowerFactory towerFactory,
        BuildModeService buildMode,
        GridService grid,
        ThroneFactory throneFactory,
        IExperienceService xpService,
        ITowerLimitService stats)
    {
        _systems = new Feature("Systems").Add(new GameplayFeatures(contexts, factory, pool,
                        towerFactory, buildMode, grid, throneFactory, xpService, stats));
    }

    void Start()
    {
        if (_systems == null)
            Debug.LogError("SYSTEMS NULL");
        _systems.Initialize();
    }

    void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }
}
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
        TowerView towerView,
        DiContainer container)
    {
        _systems = new Feature("Systems").Add(new GameplayFeatures(contexts, factory, pool, towerView, container));
    }

    void Start()
    {
        var contexts = Contexts.sharedInstance;

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
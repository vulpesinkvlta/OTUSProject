using UnityEngine;
using Zenject;

public class TowerView : MonoBehaviour
{
    public GameEntity Entity { get; private set; }
    private ITowerLimitService _limitService;

    [Inject]
    public void Construct(ITowerLimitService limitService)
    {
        _limitService = limitService;
    }
    public void Initialize(GameEntity entity)
    {
        Entity = entity;
    }

    private void OnDestroy()
    {
        _limitService.DestroySpawn();
    }
}
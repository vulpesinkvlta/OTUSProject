using Entitas;
using UnityEngine;

public class TowerDestroyedSystem : IExecuteSystem
{
    private GameContext _context;
    private IGroup<GameEntity> _destroyedTowers;
    private ITowerLimitService _limitService;
    public TowerDestroyedSystem(Contexts contexts, ITowerLimitService limitService)
    {
        _context = contexts.game;

        _destroyedTowers = _context.GetGroup(GameMatcher.AllOf(GameMatcher.TowerTag,
                                            GameMatcher.Destroyed));
        _limitService = limitService;
    }
    public void Execute()
    {
        foreach (var entity in _destroyedTowers)
        {
            _limitService.DestroySpawn();
            Debug.Log("Destroyed tower, remaining: " + _limitService.CurrentLimit);
            entity.Destroy();
        }
    }
}


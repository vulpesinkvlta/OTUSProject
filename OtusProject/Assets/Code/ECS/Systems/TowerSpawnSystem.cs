using Entitas;
using UnityEngine;

public class TowerSpawnSystem : IInitializeSystem
{
    private readonly GameContext _contexts;

    public TowerSpawnSystem(Contexts contexts)
    {
        _contexts = contexts.game;
    }
    public void Initialize()
    {
        var e = _contexts.CreateEntity();
        e.isTowerTag = true;
        e.AddHealth(100);
        e.AddPosition(new Vector3(0,0,0));
        e.AddDamage(1);
        e.AddAttackCooldown(1);
        e.isDestructible = true;
    }
}


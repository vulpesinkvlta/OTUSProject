using Entitas;
using UnityEngine;

public class ThroneSpawnSystem : IInitializeSystem
{
    private readonly GameContext _context;

    public ThroneSpawnSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        var throne = _context.CreateEntity();

        throne.isThroneTag = true;
        throne.AddPosition(new Vector3(5,0,0));
        throne.AddHealth(5000);
        throne.isDestructible = true;

        Debug.Log("THRONE CREATED");
    }
}
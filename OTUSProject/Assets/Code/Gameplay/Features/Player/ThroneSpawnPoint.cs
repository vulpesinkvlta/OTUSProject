using UnityEngine;
using Zenject;

public class ThroneSpawnPoint : MonoBehaviour
{
    private GameContext _context;

    [Inject]
    public void Construct(Contexts context)
    {
        _context = context.game;
    }

    private void Start()
    {
        var e = _context.CreateEntity();

        e.isSpawnPoint = true;
        e.AddPosition(transform.position);
        e.isThroneTag = true;
    }
}
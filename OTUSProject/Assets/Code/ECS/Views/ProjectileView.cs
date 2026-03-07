using UnityEngine;

public class ProjectileView : MonoBehaviour
{
    public GameEntity Entity { get; private set; }

    public void Initialize(GameEntity entity)
    {
        Entity = entity;
    }
}


using UnityEngine;

public class BulletView : MonoBehaviour
{
    public GameEntity Entity { get; private set; }

    public void Initialize(GameEntity entity)
    {
        Entity = entity;
    }
}


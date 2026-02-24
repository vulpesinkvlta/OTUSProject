using UnityEngine;

public class TowerView : MonoBehaviour
{
    public GameEntity Entity { get; private set; }

    public void Initialize(GameEntity entity)
    {
        Entity = entity;
    }
}
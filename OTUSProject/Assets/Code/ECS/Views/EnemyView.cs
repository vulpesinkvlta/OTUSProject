using Entitas.Unity;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    public GameEntity Entity { get; private set; }

    public void Initialize(GameEntity entity)
    {
        Entity = entity;
    }
}


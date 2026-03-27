
using Entitas;
using UnityEngine;
using Zenject;

public class EnemyRotationController : MonoBehaviour
{
    public GameEntity Entity { get; private set; }
    public void Initialize(GameEntity entity)
    {
        Entity = entity;
    }

    public void Update()
    {
        if (Entity.hasLookDirection)
        {
            Vector3 dir = Entity.lookDirection.Value;
            Quaternion rot = Quaternion.LookRotation(dir);
            transform.rotation = rot;
        }

        if (Entity.hasPosition)
        {
            transform.position = Entity.position.value;
        }
    }
}


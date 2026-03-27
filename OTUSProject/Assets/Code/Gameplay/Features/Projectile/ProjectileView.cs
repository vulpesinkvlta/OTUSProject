using UnityEngine;

public class ProjectileView : MonoBehaviour
{
    public GameEntity Entity { get; private set; }

    public void Initialize(GameEntity entity)
    {
        Entity = entity;
    }

    private void Update()
    {
        if (Entity == null)
            return;

        if (Entity.hasPosition)
            transform.position = Entity.position.value;

        if (Entity.hasMoveDirection)
        {
            Vector3 dir = Entity.moveDirection.value;

            if (dir != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(dir);
            }
        }
    }
}


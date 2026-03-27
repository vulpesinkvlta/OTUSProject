using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    private AnimationState _lastState;
    [SerializeField] private Animator _animator;
    public GameEntity Entity { get; private set; }
    public void Initialize(GameEntity entity)
    {
        Entity = entity;
    }

    public void Update()
    {
        if(Entity.hasAnimationState)
        {
            var state = Entity.animationState.Value;

            if (state != _lastState)
            {
                ApplyAnimation(state);
                _lastState = state;
            }
        }
    }

    private void ApplyAnimation(AnimationState state)
    {
        switch (state)
        {
            case AnimationState.Idle:
                _animator.SetBool("IsMoving", false);
                break;

            case AnimationState.Walk:
                _animator.SetBool("IsMoving", true);
                _animator.SetBool("IsAttacking", false);
                break;

            case AnimationState.Attack:
                _animator.SetBool("IsAttacking", true);
                break;
        }
    }
}


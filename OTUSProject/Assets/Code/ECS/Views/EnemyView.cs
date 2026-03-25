using Entitas.Unity;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EnemyView : MonoBehaviour, IHealthView
{
    public GameEntity Entity { get; private set; }

    [SerializeField] private Slider _hpSlide;
    [SerializeField] private Animator _animator;
    private AnimationState _lastState;
    public void Initialize(GameEntity entity)
    {
        Entity = entity;
            _hpSlide.maxValue = Entity.health.value;
    }
    

    public void Set(float health)
    {
        _hpSlide.value = health;
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

        if (Entity.hasAnimationState)
        {
            var state = Entity.animationState.Value;
            
            if(state != _lastState)
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


using Entitas.Unity;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EnemyView : MonoBehaviour, IHealthView
{
    public GameEntity Entity { get; private set; }

    [SerializeField] private Slider _hpSlide;
    public void Initialize(GameEntity entity)
    {
        Entity = entity;
        _hpSlide.maxValue = Entity.health.value;
    }

    public void Set(float health)
    {
        _hpSlide.value = health;
    }
}


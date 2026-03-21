using UnityEngine;
using UnityEngine.UI;

public class ThroneView : MonoBehaviour, IHealthView
{
    public GameEntity Entity { get; private set; }
    [SerializeField] private Slider _hpSilder;

    public void Initialize(GameEntity entity)
    {
        Entity = entity;
        _hpSilder.maxValue = Entity.health.value;
    }

    public void Set(float health)
    {
        _hpSilder.value = health;
    }
}


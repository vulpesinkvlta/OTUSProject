using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TowerView : MonoBehaviour, IHealthView
{
    public GameEntity Entity { get; private set; }

    [SerializeField] private Slider _hpSilder;

    [Inject]
    public void Construct()
    {

    }
    public void Initialize(GameEntity entity)
    {
        Entity = entity;
        _hpSilder.maxValue = Entity.health.value;
    }

    public void Set(float hp)
    {
       _hpSilder.value = hp;
    }

}
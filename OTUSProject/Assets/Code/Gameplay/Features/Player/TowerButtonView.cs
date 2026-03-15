
using TMPro;
using UnityEngine;

public class TowerButtonView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthStatText;
    [SerializeField] private TextMeshProUGUI _damageHtatText;
    [SerializeField] private TextMeshProUGUI _RAngeStatText;
    [SerializeField] private TextMeshProUGUI _FireRateStatText;

    public void SetHealthStatText(string name, float value)
    {
        _healthStatText.text = $"{name}: {value}";
    }
    public void SetDamageStatText(string name, float value)
    {
        _damageHtatText.text = $"{name}: {value}";
    }
    public void SetRangeStatText(string name, float value)
    {
        _RAngeStatText.text = $"{name}: {value}";
    }
    public void SetFireRateStatText(string name, float value)
    {
        _FireRateStatText.text = $"{name}: {value}";
    }
}


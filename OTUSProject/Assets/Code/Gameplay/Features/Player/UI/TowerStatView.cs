using TMPro;
using UnityEngine;

public class TowerStatView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _statNameText;
    [SerializeField] private TextMeshProUGUI _statValueText;

    public void Set(string name, string value)
    {
        _statNameText.text = name;
        _statValueText.text = value;
    }
}


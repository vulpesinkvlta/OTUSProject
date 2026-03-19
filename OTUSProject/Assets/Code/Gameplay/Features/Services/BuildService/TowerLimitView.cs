using TMPro;
using UnityEngine;
using Zenject;

public class TowerLimitView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private ITowerLimitService _service;

    [Inject]
    public void Construct(ITowerLimitService service)
    {
        _service = service;

        _service.OnLimitChanged += UpdateView;

        UpdateView();
    }

    private void UpdateView()
    {
        _text.text = $"Towers: {_service.Spawned} / {_service.CurrentLimit}";
    }

    private void OnDestroy()
    {
        _service.OnLimitChanged -= UpdateView;
    }
}


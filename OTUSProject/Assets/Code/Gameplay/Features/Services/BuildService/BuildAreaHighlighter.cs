using UnityEngine;
using Zenject;

public class BuildAreaHighlighter : MonoBehaviour
{
    [SerializeField] private GameObject _buildAreaVisual;

    private BuildModeService _buildMode;

    [Inject]
    public void Construct(BuildModeService buildMode)
    {
        _buildMode = buildMode;

        if (isActiveAndEnabled)
            Subscribe();
    }

    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDisable()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        if (_buildMode == null)
            return;

        _buildMode.OnBuildModeChanged -= Toggle;
        _buildMode.OnBuildModeChanged += Toggle;

        Toggle(_buildMode.IsActive);
    }

    private void Unsubscribe()
    {
        if (_buildMode == null)
            return;

        _buildMode.OnBuildModeChanged -= Toggle;
    }

    private void Toggle(bool isActive)
    {
        if (_buildAreaVisual != null)
            _buildAreaVisual.SetActive(isActive);
    }
}
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
    }

    private void OnEnable()
    {
        _buildMode.OnBuildModeChanged += Toggle;
    }

    private void OnDisable()
    {
        _buildMode.OnBuildModeChanged -= Toggle;
    }

    private void Toggle(bool isActive)
    {
        _buildAreaVisual.SetActive(isActive);
    }
}
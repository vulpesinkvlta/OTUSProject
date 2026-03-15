using Entitas;
using UnityEngine;

public class TowerPlacementSystem : IExecuteSystem
{
    private readonly TowerFactory _factory;
    private readonly BuildModeService _buildMode;
    private readonly GridService _grid;
    
    public TowerPlacementSystem(
        TowerFactory factory,
        BuildModeService buildMode,
        GridService grid)
    {
        _factory = factory;
        _buildMode = buildMode;
        _grid = grid;
    }

    public void Execute()
    {
        if (!_buildMode.IsActive)
            return;

        if (!Input.GetMouseButtonDown(0))
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out RaycastHit hit))
            return;

        if (!hit.collider.CompareTag("Ground"))
            return;

        Vector3 gridPos = _grid.GetCellCenter(hit.point);

        _factory.CreateTower(_buildMode.TowerType, gridPos);

        _buildMode.StopBuild();
    }
}
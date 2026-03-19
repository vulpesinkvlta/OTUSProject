using Entitas;
using UnityEngine;

public class TowerPlacementSystem : IExecuteSystem
{
    private readonly TowerFactory _factory;
    private readonly BuildModeService _buildMode;
    private readonly GridService _grid;
    private readonly ITowerLimitService _towerLimit;
    public TowerPlacementSystem(
        TowerFactory factory,
        BuildModeService buildMode,
        GridService grid,
        ITowerLimitService towerLimit)
    {
        _factory = factory;
        _buildMode = buildMode;
        _grid = grid;
        _towerLimit = towerLimit;
    }

    public void Execute()
    {
        if (!_buildMode.IsActive)
            return;

        if (!Input.GetMouseButtonDown(0))
            return;

        if (!_towerLimit.CanSpawn())
        {
            _buildMode.StopBuild();
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out RaycastHit hit))
            return;

        if (!hit.collider.CompareTag("Ground"))
            return;

        Vector3 gridPos = _grid.GetCellCenter(hit.point);

        _factory.CreateTower(_buildMode.TowerType, gridPos);
        _towerLimit.RegisterSpawn();
        _buildMode.StopBuild();
    }
}
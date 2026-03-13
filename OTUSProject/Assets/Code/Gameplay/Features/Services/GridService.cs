using UnityEngine;
using System.Collections.Generic;

public class GridService
{
    private float _cellSize = 2f;
    private int _width = 100;
    private int _height = 100;
    public int Width => _width;
    public int Height => _height;

    public Vector2Int WorldToCell(Vector3 worldPos)
    {
        int x = Mathf.FloorToInt(worldPos.x / _cellSize);
        int z = Mathf.FloorToInt(worldPos.z / _cellSize);

        return new Vector2Int(x, z);
    }

    public Vector3 CellToWorld(Vector2Int cell)
    {
        return new Vector3(
            cell.x * _cellSize,
            0,
            cell.y * _cellSize);
    }

    public Vector3 GetCellCenter(Vector3 worldPos)
    {
        var cell = WorldToCell(worldPos);
        return CellToWorld(cell);
    }

    public List<Vector2Int> GetNeighbours(Vector2Int cell)
    {
        return new List<Vector2Int>
        {
            new Vector2Int(cell.x + 1, cell.y),
            new Vector2Int(cell.x - 1, cell.y),
            new Vector2Int(cell.x, cell.y + 1),
            new Vector2Int(cell.x, cell.y - 1)
        };
    }
    public bool IsInside(Vector2Int cell)
    {
        return cell.x >= 0 &&
               cell.y >= 0 &&
               cell.x < _width &&
               cell.y < _height;
    }
}
using UnityEngine;

public class GridService
{
    private float _cellSize = 2f;

    public Vector3 GetCellCenter(Vector3 worldPos)
    {
        int x = Mathf.RoundToInt(worldPos.x / _cellSize);
        int z = Mathf.RoundToInt(worldPos.z / _cellSize);

        return new Vector3(
            x * _cellSize,
            0,
            z * _cellSize);
    }
}
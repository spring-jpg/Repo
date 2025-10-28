using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int width = 8;
    public int height = 6;
    public float cellSize = 1f;
    public GameObject tilePrefab;

    private GridTile[,] grid;

    public void GenerateGrid()
    {
        grid = new GridTile[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject tile = Instantiate(tilePrefab, new Vector3(x * cellSize, y * cellSize, 0), Quaternion.identity);
                tile.name = $"Tile_{x}_{y}";
                GridTile tileComp = tile.GetComponent<GridTile>();
                tileComp.Init(x, y, true); // Ä¬ÈÏ¿É×ß
                grid[x, y] = tileComp;
            }
        }
    }

    public bool IsWalkable(int x, int y)
    {
        if (x < 0 || y < 0 || x >= width || y >= height) return false;
        return grid[x, y].isWalkable;
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x * cellSize, y * cellSize, 0);
    }
}

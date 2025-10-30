using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance; // 添加Instance单例

    public int width = 8;  // 网格宽度
    public int height = 6; // 网格高度
    public float cellSize = 1f; // 每个格子的大小
    public GameObject tilePrefab;  // 格子预制件（用来显示）

    private GridTile[,] grid;  // 网格数组
    public List<GridTile> obstacles = new List<GridTile>(); // 障碍物列表

    void Awake()
    {
        // 初始化单例
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // 如果已有Instance，则销毁当前对象
        }
    }

    // 🟢 初始化网格
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
                tileComp.Init(x, y, true); // 默认可走
                grid[x, y] = tileComp;
            }
        }
    }

    // 🔄 获取指定坐标的格子
    public GridTile GetTileAt(int x, int y)
    {
        if (x >= 0 && x < width && y >= 0 && y < height)
        {
            return grid[x, y];
        }
        return null;
    }

    // 🟢 判断格子是否可走
    public bool IsWalkable(int x, int y)
    {
        if (x < 0 || y < 0 || x >= width || y >= height) return false;  // 防止越界
        return grid[x, y].isWalkable;
    }

    // 🧍 角色移动
    public bool MoveCharacter(Character character, int targetX, int targetY)
    {
        GridTile targetTile = GetTileAt(targetX, targetY);

        if (targetTile != null && targetTile.isWalkable)
        {
            // 移动角色
            character.transform.position = new Vector3(targetX * cellSize, targetY * cellSize, 0);
            Debug.Log($"{character.characterName} 成功移动到 {targetX}, {targetY}");
            return true;
        }
        return false;
    }

    // 🧱 添加障碍物
    public void AddObstacle(int x, int y)
    {
        GridTile obstacleTile = GetTileAt(x, y);
        if (obstacleTile != null && obstacleTile.isWalkable)
        {
            obstacleTile.isWalkable = false; // 设置为不可通行
            obstacles.Add(obstacleTile);
        }
    }

    // 🔲 获取世界坐标位置（给定 x 和 y 坐标）
    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x * cellSize, y * cellSize, 0);
    }
}

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GridManager : MonoBehaviour
{
    [Header("Grid Settings")]
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private float tileSize;
    [SerializeField] private Vector2 originPosition;
    [SerializeField] private GameObject plotPrefab;

    private Plot[,] grid;

    [Header("Temp")]
    [SerializeField] WorldProtoype worldProtoype;

    public static GridManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GenerateGrid();
        worldProtoype.Build();
    }

    public void GenerateGrid()
    {
        grid = new Plot[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                InitializePlot(x, y);
            }
        }
    }

    public void InitializePlot(int x, int y)
    {
        Vector2 worldPos = new Vector2((x * tileSize) + originPosition.x, (y * tileSize) + originPosition.y);
        GameObject plotInstance = Instantiate(plotPrefab, worldPos, Quaternion.identity, this.transform);
        plotInstance.name = $"Plot_{x}_{y}";

        Plot plot = plotInstance.GetComponent<Plot>();
        plot.Initialize(x, y);

        grid[x, y] = plot;
    }

    public Plot GetPlotFromWorldPos(Vector2 worldPos)
    {

        int x = (int)(worldPos.x - originPosition.x);
        int y = (int)(worldPos.y - originPosition.y);
        if (x >= 0 && x < width && y >= 0 && y < height)
        {
            return grid[x, y];
        }
        else
        {
            return null;
        }
    }
    public Plot GetPlotFromXY(int x, int y)
    {
        if (x >= 0 && x < width && y >= 0 && y < height)
        {
            return grid[x, y];
        }
        else
        {
            return null;
        }
    }
    public Plot GetPlotFromXY(Vector2Int location)
    {
        int x = location.x;
        int y = location.y;
        if (x >= 0 && x < width && y >= 0 && y < height)
        {
            return grid[x, y];
        }
        else
        {
            return null;
        }
    }

    public Vector2 GetWorldPosFromXY(int x, int y)
    {
        return grid[x, y].transform.position;
    }
    public int GetWidth()
    {
        return width;
    }
    public int GetHeight()
    {
        return height;
    }
}

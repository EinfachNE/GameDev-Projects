using UnityEngine;

public class GridManager : MonoBehaviour
{

    [Header("Grid Settings")]
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private float tileSize;
    [SerializeField] private Vector3 originPosition;


    [Header("Plots")]
    [SerializeField] private PlotStaticData defaultPlot;
    [SerializeField] private Transform gridParent;
    private Plot[,] grid;




    void Start()
    {
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        grid = new Plot[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                SpawnPlot(x, y, defaultPlot);
            }
        }
        GetComponent<GenerateStartScene>().BuildScene();
    }

    public void SpawnPlot(int x, int y, PlotStaticData data)
    {
        Vector3 worldPos = new Vector3((x * tileSize) + originPosition.x, (y * tileSize) + originPosition.y, 0);
        GameObject plotInstance = Instantiate(data.GetPrefab(), worldPos, Quaternion.identity, gridParent);
        plotInstance.name = $"Plot_{x}_{y}";

        Plot plot = plotInstance.GetComponent<Plot>();
        plot.Initialize(new Vector2Int(x, y), data);

        grid[x, y] = plot;
    }

    public void ReplacePlot(Vector2Int position, PlotStaticData data)
    {
        Plot oldPlot = grid[position.x, position.y];
        Destroy(oldPlot.gameObject);
        SpawnPlot(position.x, position.y, data);
    }

    public Plot GetPlot(Vector2Int position)
    {

        int x = (int)(position.x - originPosition.x);
        int y = (int)(position.y - originPosition.y);
        if (x >= 0 && x < width && y >= 0 && y < height)
        {
            return grid[x, y];
        }
        else
        {
            return null;
        }
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

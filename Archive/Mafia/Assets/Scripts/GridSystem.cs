using UnityEngine;
public class GridSystem : MonoBehaviour
{

    [SerializeField] private Plot plotPrefab;


    private Grid<GridObject> grid;
    private int width = 20;
    private int height = 10;
    private float cellSize = .8f;
    private Vector3 originPosition = new Vector3(-8, -4, 0);

    void Awake()
    {
        grid = new Grid<GridObject>(width, height, cellSize, originPosition, (Grid<GridObject> g, int x, int y) => new GridObject(g, x, y));
        
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                Plot plotInstance = Instantiate(plotPrefab, grid.GetWorldPosition(x,y) + new Vector3(cellSize, cellSize, 0f) * .5f, Quaternion.identity, transform); 
                plotInstance.name = $"Plot_{x}_{y}";

                GridObject cell = grid.GetGridObject(x, y); 
                cell.SetPlotInstance(plotInstance);
            }
        }
        
        
    }
    public Grid<GridObject> GetGrid()
    {
        return grid;
    }

}

public class GridObject
{
    
    private Grid<GridObject> grid;
    private int x;
    private int y;

    private Plot plot;

    public GridObject(Grid<GridObject> grid, int x, int y)
    {

        this.grid = grid;
        this.x = x;
        this.y = y;

    }
    public void SetPlotInstance(Plot plotInstance) 
    {
        plot = plotInstance; 
    }

    public void SetPlotType(PlotSO type) 
    {
        if (plot != null)            
        {    
            //grid.TriggerObjectChanged(x, y); 
        }
    }

    public Plot GetPlot() => plot;

}


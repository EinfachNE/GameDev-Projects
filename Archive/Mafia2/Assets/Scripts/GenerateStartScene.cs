using UnityEngine;

public class GenerateStartScene : MonoBehaviour
{
    private GridManager gridManager;

    [SerializeField] private PlotStaticData emptyPlot;
    [SerializeField] private PlotStaticData streetPlot;
    [SerializeField] private PlotStaticData housePlot;

    private void Awake()
    {
        gridManager = GetComponent<GridManager>();
    }
    public void BuildScene()
    {
        for (int x = 0; x < gridManager.GetWidth(); x++)
        {
            for (int y = 0; y < gridManager.GetHeight(); y++)
            {
                if((x+3) % 5 == 0 || y == 5)
                {
                    gridManager.ReplacePlot(new Vector2Int(x, y), streetPlot);
                }
                else if((x+4) % 5 == 0 || (x+2) % 5 == 0 || y==6 || y==4)
                {
                    gridManager.ReplacePlot(new Vector2Int(x, y), housePlot);
                }
            }
        }
    }
}

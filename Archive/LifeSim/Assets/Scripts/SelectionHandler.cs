using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.Texture2DShaderProperty;

public class SelectionHandler : MonoBehaviour
{
    [SerializeField] private PlotSO defaultType;
    [SerializeField] private PlotSO selectedType;
    [SerializeField] private GameObject gridTransform;
    private Grid<GridObject> grid;

    private void Start()
    {
        grid = gridTransform.GetComponent<GridSystem>().GetGrid();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            grid.GetXY(mouseWorld, out int x, out int y);

            if (x >= 0 && x < grid.GetWidth() && y >= 0 && y < grid.GetHeight())
            {
                GridObject cell = grid.GetGridObject(x, y);
                cell.SetPlotType(selectedType);
                grid.TriggerObjectChanged(x, y);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            grid.GetXY(mouseWorld, out int x, out int y);

            if (x >= 0 && x < grid.GetWidth() && y >= 0 && y < grid.GetHeight())
            {
                grid.GetGridObject(x, y).SetPlotType(defaultType);
            }
        }
    }
}

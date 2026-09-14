using UnityEngine;

public class Plot : MonoBehaviour
{
    private Vector2Int gridPosition;
    private PlotStaticData plotStaticData;
    private PlotRuntimeData plotRuntimeData;

    public void Initialize(Vector2Int position, PlotStaticData plotStaticData)
    {
        this.gridPosition = position;
        SetPlotStaticData(plotStaticData);
        SetPlotRuntimeData(GetComponent<PlotRuntimeData>());

    }

    public Vector2Int GetGridPosition()
    {
        return gridPosition;
    }
    public void SetGridPosition(Vector2Int value)
    {
        this.gridPosition = value;
    }
    public PlotStaticData GetPlotStaticData()
    {
        return plotStaticData;
    }
    public PlotRuntimeData GetPlotRuntimeData()
    {
        return plotRuntimeData;
    }
    public void SetPlotStaticData(PlotStaticData data)
    {
        this.plotStaticData = data;
    }
    public void SetPlotRuntimeData(PlotRuntimeData data)
    {
        this.plotRuntimeData = data;
    }
}

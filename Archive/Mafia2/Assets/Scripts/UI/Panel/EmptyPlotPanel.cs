using UnityEngine;

public class EmptyPlotPanel : PlotPanel
{
    public override void LoadData()
    {
        base.LoadData();
    }

    [SerializeField] private PlotStaticData houseData;
    public void BuildHouse()
    {
        gridManager.ReplacePlot(plot.GetGridPosition(), houseData);
        ClosePanel();

    }
}

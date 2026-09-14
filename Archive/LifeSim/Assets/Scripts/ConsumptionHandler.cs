using UnityEngine;
using System;

public class ConsumptionHandler : MonoBehaviour
{

    [SerializeField] private PlotSO DirtplotSO;
    private PlotSO plotSO;
    private Plot plot;
    private void Start()
    {
        plot = GetComponent<Plot>();
        plotSO = plot.GetPlotSO();
        TickHandler.onTick += Consume;
        plot.OnTypeChanged += AttuneToPlot;
    }

    private void AttuneToPlot(Plot plot, PlotSO plotSO)
    {
        this.plot = plot;
        this.plotSO = plotSO;
    }
    public void Consume()
    {
        Debug.Log(plotSO);
        if (plotSO != null)
        {
            if (plotSO.ConsumesWater()) 
            { 
                plot.DecreaseCurrentWaterAmountBy(plotSO.GetWaterUsageAmount()); 
                if (plot.GetCurrentWaterAmount() <= 0f)
                {
                    plot.SetPlotType(DirtplotSO);
                }
            }

        }
    }
}

using UnityEngine;
using System;

public class Plot : MonoBehaviour
{
    public PlotType CurrentType { get; private set; }
    private PlotSO currentPlotStats;

    [SerializeField] private SpriteRenderer sr;

    [SerializeField] private float waterCapacity;
    private float currentWaterAmount;

    private void Start()
    {
        currentWaterAmount = waterCapacity;
    }

    public void SetPlotType(PlotSO plotSO)
    {
        CurrentType = plotSO.GetPlotType();
        currentPlotStats = plotSO;

        sr.sprite = plotSO ? plotSO.GetSprite() : null;
        sr.color = plotSO ? plotSO.GetColor() : Color.white;

        OnTypeChanged?.Invoke(this, plotSO);
    }

    public PlotSO GetPlotSO()
    {
        return currentPlotStats;
    }

    public float GetCurrentWaterAmount()
    {
        return currentWaterAmount;
    }

    public void DecreaseCurrentWaterAmountBy(float amount)
    {
        currentWaterAmount -= amount;
    }


    public event Action<Plot, PlotSO> OnTypeChanged;
}

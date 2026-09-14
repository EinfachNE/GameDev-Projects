using UnityEngine;
using System;

public class Plot : MonoBehaviour
{
    [SerializeField] private PlotSO plotStats;
    [SerializeField] private SpriteRenderer spriteRenderer;
    

    private void OnEnable()
    {
        UpdateSprite();
    }
    public PlotSO GetPlotStats()
    {
        return plotStats;
    }
    public void UpdateSprite()
    {
        spriteRenderer.sprite = plotStats.GetSprite();
    }
}


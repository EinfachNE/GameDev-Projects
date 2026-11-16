using System;
using UnityEngine;

public enum PlotContentType
{
    Building,
    MeetingLocation
}
public class PlotContent : MonoBehaviour
{
    private Plot plot;
    [Header("Plot Data")]
    [SerializeField] private PlotContentType plotType;
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private SpriteRenderer visualGO;

    public void Initialize(Plot plot)
    {
        this.plot = plot;
        Initialize();
    }
    public PlotContentType GetPlotContentType()
    {
        return plotType;
    }
    public Vector2 GetInteractionPoint()
    {
        return interactionPoint.position;
    }
    public virtual void Initialize()
    {
    }
    public SpriteRenderer GetVisualGO()
    {
        return visualGO;
    }
    public Vector2Int GetXY()
    {
        return plot.GetXY();
    }
}

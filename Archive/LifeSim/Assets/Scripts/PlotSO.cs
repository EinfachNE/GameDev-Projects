using UnityEngine;

public enum PlotType { empty, dirt, grass }

[CreateAssetMenu(fileName = "PlotSO", menuName = "ScriptableObject/PlotSO")]
public class PlotSO : ScriptableObject
{ 

    [Header("Identity")]
    [SerializeField] private PlotType type;

    [Header("Visuals")]
    [SerializeField] private Sprite sprite;
    [SerializeField] private Color color = Color.white;

    [Header("Gameplay")]
    [SerializeField] private bool walkable = true;
    [SerializeField] private float moveCost = 1f;

    [SerializeField] private bool consumesWater = false;
    [SerializeField] private float waterUsageAmount = 1f;

    public PlotType GetPlotType()
    {
        return type;
    }
    public Sprite GetSprite()
    {
        return sprite;
    }
    public Color GetColor()
    {
        return color;
    }
    public bool IsWalkable()
    {
        return walkable;
    }
    public float GetMoveCost()
    {
        return moveCost;
    }
    public bool ConsumesWater()
    {
        return consumesWater;
    }public float GetWaterUsageAmount()
    {
        return waterUsageAmount;
    }
}

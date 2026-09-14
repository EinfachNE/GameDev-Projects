using UnityEngine;

public enum PlotType
{
    Empty,
    Street,
    House,
}
[CreateAssetMenu(menuName = "Grid/PlotStaticData")]
public class PlotStaticData : ScriptableObject
{
    [Header("System")]
    [SerializeField] private PlotType type;
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject panel;

    [Header("Stats")]
    [SerializeField] private bool isPurchasable;
    [SerializeField] private int baseValue;
    [SerializeField] private bool isRentable;
    public GameObject GetPrefab()
    {
        return prefab;
    }
    public void SetPrefab(GameObject prefab)
    {
        this.prefab = prefab;
    }
    public PlotType GetPlotType()
    {
        return type;
    }
    public void SetPlotType(PlotType plotType)
    {
        this.type = plotType;
    }
    public GameObject GetPanel()
    {
        return panel;
    }
    public void SetPanel(GameObject panel)
    {
        this.panel = panel;
    }
    public int GetBaseValue()
    {
        return baseValue;
    }
    
}

using UnityEngine;

public class PlotTypeReferences : MonoBehaviour
{
    [SerializeField] private Plot emptyPlotLogic;
    [SerializeField] private Plot streetPlotLogic;
    
    public Plot GetStreetPlotLogic()
    {
        return streetPlotLogic;
    }
    public Plot GetEmptyPlotLogic()
    {
        return emptyPlotLogic;
    }
}

using System.Globalization;
using UnityEngine;

public enum PlanterType
{
    Flowerpot
}

[CreateAssetMenu(fileName = "PlanterDefinition", menuName = "Scriptable Objects/PlanterDefinition")]
public class PlanterDefinition : PlacableDefinition
{
    [Header("Planter Values")]
    [SerializeField] private PlanterType planterType;
    [SerializeField] private int maxPlantAmount;
    public PlanterType GetPlanterType()
    {
        return planterType;
    }
    public int GetMaxPlantAmount()
    {
        return maxPlantAmount;
    }
}

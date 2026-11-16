using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Planter : Placable
{
    private Plant[] plants;
    private PlanterDefinition definition;
    private TimeManager timeManager;

    public Planter(PlanterDefinition definition) : base(definition)
    {
        timeManager = TimeManager.Instance;
        this.definition = definition;
        plants = new Plant[definition.GetMaxPlantAmount()];

    }
    public bool Plant(PlantDefinition plant, int idx)
    {
        if (plants[idx] == null)
        {
            plants[idx] = new Plant(plant, timeManager.GetTotalTime());
            return true;
        }
        return false;
    }
    public void RemovePlant(int idx)
    {
        plants[idx] = null;
    }
    public Plant[] GetPlants()
    {
        return plants;
    }
    public PlanterType GetPlanterType()
    {
        return definition.GetPlanterType();
    }
    public PlanterDefinition GetPlanterDefinition() 
    {
        return this.definition;
    }
}

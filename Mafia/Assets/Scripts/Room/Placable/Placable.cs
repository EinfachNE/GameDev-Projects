using System;
using UnityEngine;

public class Placable
{
    private PlacableDefinition definition;
    public Placable(PlacableDefinition definition)
    {
        this.definition = definition;
        SetDefinition(definition);
    }
    public int GetCapacityCost()
    {
        return definition.GetCapacityCost();
    }
    public  PlacableDefinition GetDefinition() 
    { 
        return definition;
    }
    public GameObject GetEntryUI()
    {
        return definition.GetEntryUI();
    }
    public void SetDefinition(PlacableDefinition definition)
    {
        this.definition = definition;
    }
    public PlacableItemDefinition GetItem()
    {
        return definition.GetItem();
    }
}

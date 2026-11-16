using System;
using Unity.VisualScripting;
using UnityEngine;

public enum PlacableType
{
    Planter,
    Storage,
}

[CreateAssetMenu(fileName = "PlacableDefinition", menuName = "Scriptable Objects/PlacableDefinition")]
public class PlacableDefinition : ScriptableObject
{
    [Header("Placable Values")]
    [SerializeField] private string displayName;
    [SerializeField] private PlacableType type;
    [SerializeField] private int capacityCost;
    [SerializeField] private GameObject entryUI;
    [SerializeField] private PlacableItemDefinition item;

    public int GetCapacityCost()
    {
        return capacityCost;
    }
    public GameObject GetEntryUI()
    {
        return entryUI;
    }
    public PlacableItemDefinition GetItem() 
    {
        return item;
    }
    public PlacableType GetPlacableType() { return type; }
    public string GetDisplayName() { return displayName; }
}

using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "PlantDefinition", menuName = "Scriptable Objects/PlantDefinition")]
public class PlantDefinition : ScriptableObject
{
    [SerializeField] private string displayName;
    [SerializeField] private ItemDefinition item;
    [SerializeField] private ItemDefinition seed;
    [SerializeField] private int seedHarvestAmount;
    [SerializeField] private int baseTimeToGrow;
    [SerializeField] private int baseYield;

    public string GetDisplayName()
    {
        return displayName;
    }
    public ItemDefinition GetItem()
    {
        return item;
    }
    public ItemDefinition GetSeed()
    {
        return seed;
    }
    public int GetBaseYield()
    {
        return baseYield;
    }
    public int GetSeedHarvestAmount()
    {
        return seedHarvestAmount;
    }
    public int GetBaseTimeToGrow()
    {
        return baseTimeToGrow;
    }   
}

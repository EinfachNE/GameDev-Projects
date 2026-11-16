using System.Collections.Generic;
using UnityEngine;

public enum PlantState
{
    NotPlanted,
    Seedling,
    Young,
    Maturing,
    Harvestable,
    SeedBearing
}
public class Plant
{
    private Inventory playerInventory;
    private PlantDefinition definition;
    private long timePlanted;
    private bool isHarvestable = false;
    private int growthPercent = 0;
    private PlantState state;

    public Plant(PlantDefinition definition, long timePlanted)
    {
        this.definition = definition;
        this.timePlanted = timePlanted;
        playerInventory = Player.Instance.GetComponent<Inventory>();
    }
    public int GetGrowthPercent()
    {
        return growthPercent;
    }
    public int GetBaseYield()
    {
        return definition.GetBaseYield();
    }
    public ItemDefinition GetItem() 
    {
        return definition.GetItem();
    }
    public bool IsHarvestable()
    {
        return isHarvestable;
    }
    public PlantState GetPlantState()
    {
        return state;
    }
    public ItemDefinition GetSeed()
    {
        return definition.GetSeed();
    }
    public int GetSeedHarvestAmount()
    {
        return definition.GetSeedHarvestAmount();
    }
    public bool Harvest()
    {
        if (isHarvestable)
        {
            if (state == PlantState.SeedBearing)
            {
                List<ItemDefinition> item = new List<ItemDefinition>();
                item.Add(GetItem());
                item.Add(GetSeed());
                List<int> amount = new List<int>();
                amount.Add(GetBaseYield());
                amount.Add(GetSeedHarvestAmount());

                if (playerInventory.HasSpace(item, amount))
                {
                    for (int i = 0; i < item.Count; i++)
                    {
                        playerInventory.AddItem(item[i], amount[i]);
                    }
                    return true;
                }
                else
                {
                    Debug.Log("Not enough space in inventory");
                }
            }
            else if (state == PlantState.Harvestable)
            {
                if (playerInventory.AddItem(GetItem(), GetBaseYield()))
                {
                    return true;
                }
            }
        }
        return false;
    }
    public void UpdateState(long currentTime)
    {
        growthPercent = (int)(((currentTime - timePlanted) * 100 / definition.GetBaseTimeToGrow()));
        switch (growthPercent)
        {
            case >= 120:
                state = PlantState.SeedBearing;
                isHarvestable = true;
                break; 
            case >= 100:
                state = PlantState.Harvestable;
                isHarvestable = true;
                break;
            case >= 50:
                state = PlantState.Maturing;
                break;
            case >= 20:
                state = PlantState.Young;
                break;
            case >= 0:
                state = PlantState.Seedling;
                break;
        }
    }
    public PlantDefinition GetDefinition()
    {
        return definition;
    }

}

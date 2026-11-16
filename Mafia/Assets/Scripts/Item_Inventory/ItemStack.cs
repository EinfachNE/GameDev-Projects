using UnityEngine;

public class ItemStack
{
    private ItemDefinition itemDefinition;
    private int amount;

    public ItemStack(ItemDefinition item, int amount)
    {
        itemDefinition = item;
        this.amount = amount;
    }
    public void SetItem(ItemDefinition itemDefinition)
    {
        this.itemDefinition = itemDefinition;
    }
    public ItemDefinition GetItem()
    {
        return itemDefinition;
    }
    public ItemDefinition GetItemDefinition()
    {
        return this.itemDefinition;
    }
    public void ChangeAmountBy(int amount)
    {
        this.amount += amount;
    }
    public void SetAmount(int amount)
    {
        this.amount = amount;
    }
    public int GetAmount()
    {
        return amount;
    }
}

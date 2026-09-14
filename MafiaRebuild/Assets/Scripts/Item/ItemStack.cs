using UnityEngine;

public class ItemStack
{
    private ItemDefinition item;
    private int amount;

    public ItemStack(ItemDefinition item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }
    #region getset
    #region amount
    public int GetAmount()
    {
        return amount;
    }
    public void SetAmount(int value)
    {
        amount = value;
    }
    public void IncreaseAmountBy(int value)
    {
        amount += value;
    }
    #endregion
    #region item
    public ItemDefinition GetItem()
    {
        return item;
    }
    #endregion
    #endregion
}

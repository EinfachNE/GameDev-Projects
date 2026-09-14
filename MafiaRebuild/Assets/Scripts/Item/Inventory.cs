using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<ItemStack> items = new List<ItemStack>();

    public IReadOnlyList<ItemStack> Items => items;

    public int GetAmount(ItemDefinition item)
    {
        ItemStack stack = FindStack(item);
        return stack == null ? 0 : stack.GetAmount();
    }

    public bool HasItem(ItemDefinition item)
    {
        return GetAmount(item) >= 0;
    }
    public bool HasItem(ItemDefinition item, int amount)
    {
        return GetAmount(item) >= amount;
    }

    public void AddItem(ItemDefinition item, int amount)
    {
        if (amount <= 0) return;

        ItemStack stack = FindStack(item);

        if (stack == null)
        {
            items.Add(new ItemStack(item, amount));
        }
        else
        {
            stack.IncreaseAmountBy(amount);
        }
    }

    public bool RemoveItem(ItemDefinition item, int amount)
    {
        if (amount <= 0) return false;

        ItemStack stack = FindStack(item);

        if (stack == null) return false;
        if (stack.GetAmount() < amount) return false;

        stack.IncreaseAmountBy(-amount);

        if (stack.GetAmount() <= 0)
        {
            items.Remove(stack);
        }

        return true;
    }

    private ItemStack FindStack(ItemDefinition item)
    {
        return items.Find(stack => stack.GetItem() == item);
        // Finde den ersten Stack, dessen Item gleich dem gesuchten Item ist
    }
}
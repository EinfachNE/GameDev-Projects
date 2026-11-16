using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int maxStacks;
    private ItemStack[] inventory;

    public event Action OnInventoryChanged;

    private void Awake()
    {
        inventory = new ItemStack[maxStacks];
    }

    public bool AddItem(ItemDefinition item, int amount)
    {
        if (HasSpace(item, amount))
        {
            while (amount > 0)
            {
                ItemStack stack = FindItem(item, false);
                if (stack?.GetAmount() + amount > item.GetMaxStackSize())
                {
                    amount -= item.GetMaxStackSize() - stack.GetAmount();
                    stack.SetAmount(item.GetMaxStackSize());
                }
                else if (stack == null)
                {
                    int idx = FindEmptyStackIndex();
                    if (idx >= 0)
                    {
                        if (amount > item.GetMaxStackSize())
                        {
                            inventory[idx] = new ItemStack(item, item.GetMaxStackSize());
                            amount -= inventory[idx].GetAmount();
                        }
                        else
                        {
                            inventory[idx] = new ItemStack(item, amount);
                            amount = 0; break;
                        }
                    }
                }
                else if (stack.GetAmount() + amount <= item.GetMaxStackSize())
                {
                    stack.ChangeAmountBy(amount);
                    amount = 0; break;
                }
            }
            OnInventoryChanged?.Invoke();
            return true;
        }
        else { return false; }
    }
    public bool HasSpace(ItemDefinition item, int amount)
    {
        int space = 0;
        for (int i = 0; i < inventory.Length; i++) 
        { 
            if (inventory[i]?.GetItemDefinition() == item)
            {
                space += item.GetMaxStackSize() - inventory[i].GetAmount();
            }
            else if (inventory[i] == null)
            {
                space += item.GetMaxStackSize();
            }
            if (space >= amount)
            {
                return true;
            }
        }
        return false;
    }
    public bool HasSpace(List<ItemDefinition> item, List<int> amount)
    {
        List<int> occupied = new List<int>();
        int space = 0;
        for(int j = 0; j < item.Count; j++)
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i]?.GetItemDefinition() == item[j])
                {
                    space += item[j].GetMaxStackSize() - inventory[i].GetAmount();
                }
                if (space >= amount[j])
                {
                    break;
                }
            }
            if (space < amount[j])
            {
                for (int i = 0; i < inventory.Length; i++)
                {
                    if (inventory[i] == null)
                    {
                        occupied.Add(i);
                        space += item[j].GetMaxStackSize();
                    }
                }
                if (space < amount[j])
                {
                    return false;
                }
            }
        }
        return true;
    }
    public bool RemoveItem(ItemDefinition item, int amount)
    {
        if (HasItem(item, amount))
        {
            for (int i = 0; i < inventory.Length; ++i) 
            {
                if (inventory[i]?.GetItemDefinition() == item)
                {
                    if (inventory[i].GetAmount() - amount <= 0)
                    {
                        amount -= inventory[i].GetAmount();
                        inventory[i] = null;
                        OnInventoryChanged?.Invoke();
                    }
                    else
                    {
                        inventory[i].ChangeAmountBy(-amount);
                        amount = 0;
                        OnInventoryChanged?.Invoke();
                        break;
                    }
                }   
                if (amount <= 0) { OnInventoryChanged?.Invoke();  break; }
            }
            OnInventoryChanged?.Invoke();
            return true;
        }
        else { return false; }
        
    }
    public bool HasItem(ItemDefinition item, int amount)
    {
        return GetAmount(item) >= amount;
    }
    public int GetAmount(ItemDefinition item)
    {
        int amount = 0;
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i]?.GetItemDefinition() == item)
            {
                amount += inventory[i].GetAmount();
            }
        }
        return amount;
    }
    public int GetAmountInItemstack(int index)
    {
        return inventory[index].GetAmount();
    }
    public ItemStack FindItem(ItemDefinition item, bool includeFullStacks = true)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i]?.GetItemDefinition() == item)
            {
                if (!includeFullStacks && inventory[i]?.GetAmount() >= item.GetMaxStackSize())
                {
                }
                else
                {
                    return inventory[i];
                }
            }
        }
        return null;
    }
    public int FindEmptyStackIndex()
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                return i;
            }
        }
        return -1;
    }
    public ItemDefinition GetItem(int index)
    {
        return inventory[index]?.GetItem();
        
    }
    public List<ItemDefinition> GetItems()
    {
        List<ItemDefinition> items = new List<ItemDefinition>();
        for (int i = 0;i < inventory.Length; i++)
        {
            items.Add(inventory[i].GetItem());
        }
        return items;
    }
    public int GetLength() { return inventory.Length; }
}

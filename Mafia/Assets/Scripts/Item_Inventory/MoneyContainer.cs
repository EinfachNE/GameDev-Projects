using System;
using Unity.VisualScripting;
using UnityEngine;

public class MoneyContainer : MonoBehaviour
{
    [SerializeField] private int currentAmount;

    public void AddMoney(int amount)
    {
        currentAmount += amount;
        TriggerMoneyChanged?.Invoke();
    }
    public bool RemoveMoney(int amount) 
    {
        if(HasAmount(amount)){
            currentAmount -= amount;
            TriggerMoneyChanged?.Invoke();
            return true;
        }
        return false;
    }
    public bool HasAmount(int amount)
    {
        return currentAmount >= amount;
    }
    public int GetCurrentAmount()
    {
        return currentAmount;
    }
    public event Action TriggerMoneyChanged;
}

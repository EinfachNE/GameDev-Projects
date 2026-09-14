using UnityEngine;
using System;

public class PlayerStats : MonoBehaviour
{
    private int damage = 1;
    [SerializeField] int money;

    public static event Action triggerMoneyChanged;

    #region getset
    public int GetDamageAmount() { return damage; }
    public void SetDamageAmount(int value) { damage = value; }
    public int GetMoneyAmount() { return money; }
    public void IncreaseMoneyAmountBy(int value) 
    { 
        money += value; 
        triggerMoneyChanged?.Invoke(); 
    }
    public void SetMoneyAmount(int value) 
    { 
        money = value;
        triggerMoneyChanged.Invoke();
    }
    #endregion
}

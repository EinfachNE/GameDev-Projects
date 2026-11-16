using System.Collections.Generic;
using UnityEngine;

public class RetailStore : MonoBehaviour 
{
    private Inventory playerInventory;
    private MoneyContainer playerMoney;
    [SerializeField] private string shopName;
    [SerializeField] private List<ItemDefinition> shopOffer;

    private void Start()
    {
        playerInventory = Player.Instance.GetComponent<Inventory>();
        playerMoney = Player.Instance.GetComponent<MoneyContainer>();
    }
    public string GetShopName()
    {
        return shopName;
    }
    public List<ItemDefinition> GetShopOffer()
    {
        return shopOffer;
    }
    public void BuyItem(int idx)
    {
        ItemDefinition item = shopOffer[idx];
        int value = item.GetBaseValue();

        if (playerMoney.HasAmount(value)){
            if (playerInventory.AddItem(item, 1))
            {
                playerMoney.RemoveMoney(value);
            }
        }
    }
}

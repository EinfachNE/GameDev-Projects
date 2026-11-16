using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopOfferUIEntry : MonoBehaviour, IPointerClickHandler
{

    private ItemDefinition item;
    private int idx;
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemPriceText;
    private UIManager uiManager;


    public void Populate(int idx, ItemDefinition item)
    {
        this.idx = idx;
        this.item = item;
        uiManager = UIManager.Instance;
        icon.sprite = item.GetIcon();
        itemNameText.text = item.GetDisplayName();
        itemPriceText.text = "price: " + item.GetBaseValue().ToString() + "$";

    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");
        Building building = uiManager.GetLastReferencedBuilding();
        building.gameObject.GetComponent<RetailStore>()?.BuyItem(idx);
    }
}

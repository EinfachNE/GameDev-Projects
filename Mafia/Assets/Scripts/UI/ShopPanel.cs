using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI shopName;
    [SerializeField] private GameObject offerEntry;
    [SerializeField] private Transform offerEntryParent;
    private RetailStore shopData;

    List<GameObject> offerEntrys = new List<GameObject>();

    public void Populate(Building building)
    {
        shopData = building.gameObject.GetComponent<RetailStore>();
        shopName.text = shopData.GetShopName();
        ClearEntrys();
        InitiateOfferList();
    }
    public void InitiateOfferList()
    {
        List<ItemDefinition> shopOffer = shopData.GetShopOffer();
        for (int i = 0; i < shopOffer.Count; i++)
        {
            ShopOfferUIEntry entry = Instantiate(offerEntry, offerEntryParent).GetComponent<ShopOfferUIEntry>();
            entry.Populate(i, shopOffer[i]);
            offerEntrys.Add(entry.gameObject);
        }
    }
    public void CloseUI()
    {
        ClearEntrys();
        UIManager.Instance.CloseUI(this.gameObject);
    }
    public void ClearEntrys()
    {
        for (int i = 0; i < offerEntrys.Count; i++)
        {
            Destroy(offerEntrys[i]);
        }
    }
}

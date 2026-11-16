using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HotbarUI : MonoBehaviour
{
    [SerializeField] private Inventory playerInventory;
    [SerializeField] private Sprite emptySprite;
    [SerializeField] Image slot0;
    [SerializeField] TextMeshProUGUI slot0text;
    [SerializeField] Image slot1;
    [SerializeField] TextMeshProUGUI slot1text;
    [SerializeField] Image slot2;
    [SerializeField] TextMeshProUGUI slot2text;

    private void OnEnable()
    {
        playerInventory.OnInventoryChanged += Repopulate;
    }
    private void OnDestroy()
    {
        playerInventory.OnInventoryChanged -= Repopulate;
    }
    private void Start()
    {
        Repopulate();
    }

    public void Repopulate()
    {
        ItemDefinition item = null;
        item = playerInventory?.GetItem(0);
        if (item == null)
        {
            slot0.sprite = emptySprite;
            slot0text.gameObject.SetActive(false);
        }
        else
        {
            slot0.sprite = item.GetIcon();
            slot0text.gameObject.SetActive(true);
            slot0text.text = playerInventory.GetAmountInItemstack(0).ToString();
        }

        item = playerInventory?.GetItem(1);
        if (item == null)
        {
            slot1.sprite = emptySprite;
            slot1text.gameObject.SetActive(false);
        }
        else 
        { 
            slot1.sprite = item?.GetIcon();
            slot1text.gameObject.SetActive(true);
            slot1text.text = playerInventory.GetAmountInItemstack(1).ToString();
        }

        item = playerInventory?.GetItem(2);
        if (item == null)
        {
            slot2.sprite = emptySprite;
            slot2text.gameObject.SetActive(false);
        }
        else 
        { 
            slot2.sprite = item?.GetIcon();
            slot2text.gameObject.SetActive(true);
            slot2text.text = playerInventory.GetAmountInItemstack(2).ToString();
        }
    }
}

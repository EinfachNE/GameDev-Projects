using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class AvailablePlacablesEntryUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI nameText;
    private Placable placable;
    private UIManager uIManager;
    private Inventory playerInventory;
    public event Action OnPlacableAdded;
    private void Start()
    {
        uIManager = UIManager.Instance;
        playerInventory = Player.Instance.GetComponent<Inventory>();
    }
    public void Setup(Placable placable)
    {
        this.placable = placable;
        nameText.text = placable.GetDefinition().GetDisplayName();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Room room = uIManager.GetLastReferencedRoom();

        if (room.HasSpace(placable) && playerInventory.RemoveItem(placable.GetItem(), 1))
        {
            if (room.AddPlacable(placable))
            {
                OnPlacableAdded?.Invoke();
            }
            else
            {
                playerInventory.AddItem(placable.GetItem(), 1);
            }
        }
    }
}

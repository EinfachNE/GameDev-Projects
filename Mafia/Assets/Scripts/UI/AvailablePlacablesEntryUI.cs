using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class AvailablePlacablesEntryUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI nameText;
    private Placable placable;
    private Room room;
    private Inventory playerInventory;
    public event Action OnPlacableAdded;
    private void Start()
    {
        playerInventory = Player.Instance.GetComponent<Inventory>();
    }
    public void Setup(Placable placable, Room room)
    {
        this.placable = placable;
        this.room = room;
        nameText.text = placable.GetDefinition().GetDisplayName();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
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

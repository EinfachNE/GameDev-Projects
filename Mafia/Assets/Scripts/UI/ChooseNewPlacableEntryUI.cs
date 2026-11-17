using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChooseNewPlacableEntryUI : MonoBehaviour, IPointerClickHandler
{
    UIManager uIManager;
    private Room room;
    private void Start()
    {
        uIManager = UIManager.Instance;
    }
    public void Setup(Room room)
    {
        this.room = room;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        uIManager.OpenChoosePlacableListUI(room);
    }
}

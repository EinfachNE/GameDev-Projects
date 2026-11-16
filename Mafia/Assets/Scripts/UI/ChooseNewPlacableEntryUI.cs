using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChooseNewPlacableEntryUI : MonoBehaviour, IPointerClickHandler
{
    UIManager uIManager;
    private void Start()
    {
        uIManager = UIManager.Instance;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        uIManager.OpenChoosePlacableListUI();
    }
}

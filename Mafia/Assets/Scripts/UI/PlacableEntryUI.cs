using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlacableEntryUI : MonoBehaviour, IPointerClickHandler
{
    public event Action OnEntryClicked;
    public virtual void OpenUI()
    {
    }
    public virtual void Setup(Placable placable) { }
    public void OnPointerClick(PointerEventData eventData)
    {
        OnEntryClicked?.Invoke();
        OpenUI();
    }
}

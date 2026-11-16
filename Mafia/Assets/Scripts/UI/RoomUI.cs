using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class RoomUI : MonoBehaviour
{
    [SerializeField] private Transform placableEntryParent;
    [SerializeField] private GameObject chooseNewEntrysUI;
    private Room currentRoom;
    private List<GameObject> entrys = new List<GameObject>();
    public void Populate(Room room)
    {
        currentRoom = room;
        InitializePlacables();
    }
    private void OnEnable()
    {
        currentRoom.OnPlacablesChanged += Repopulate;
    }
    private void OnDisable()
    {
        currentRoom.OnPlacablesChanged -= Repopulate;
    }
    public void Repopulate()
    {
        RemoveEntrys();
        InitializePlacables();
    }
    public void InitializePlacables()
    {
        if (currentRoom.GetCurrentCapacity() < currentRoom.GetMaxCapacity())
        {
            entrys.Add(Instantiate(chooseNewEntrysUI, placableEntryParent));
        }
        List<Placable> placables = currentRoom.GetPlacables();
        for (int i = 0; i < placables.Count; i++)
        {
            CreateEntry(placables[i]);
        }
    }
    public void CreateEntry(Placable placable)
    {
        GameObject placableEntry = placable.GetEntryUI();
        GameObject entry = Instantiate(placableEntry, placableEntryParent);
        entry.GetComponent<PlacableEntryUI>().Setup(placable);
        entry.GetComponent<PlacableEntryUI>().OnEntryClicked += CloseUI;
        entrys.Add(entry);

    }
    public void CloseUI()
    {
        RemoveEntrys();
        UIManager.Instance.CloseUI(this.gameObject);  
    }
    public void RemoveEntrys()
    {
        for (int i = 0; i < entrys.Count; i++)
        {
            PlacableEntryUI entryUI = entrys[i].GetComponent<PlacableEntryUI>();
            if (entryUI != null)
            {
                entryUI.OnEntryClicked -= CloseUI;
            }
            Destroy(entrys[i]);
        }
        entrys.Clear();
    }
    
}

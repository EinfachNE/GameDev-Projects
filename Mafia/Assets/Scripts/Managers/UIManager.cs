using System;
using Unity.Multiplayer.Center.Common;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance;

    public void Awake()
    {
        Instance = this;
    }

    #region UIReferences
    [SerializeField] GameObject A1OwnedPanel;
    [SerializeField] GameObject persistentUI;
    [SerializeField] GameObject contactsUI;
    [SerializeField] GameObject parkPanel; 
    [SerializeField] GameObject shopPanel; 
    [SerializeField] GameObject roomPanel;
    [SerializeField] GameObject flowerpotPanel;
    [SerializeField] GameObject choosePlacableListPanel;
    #endregion

    public event Action OnUnderlyingUIClosed;
    [SerializeField] private MeetingManager meetingManager;
    private GameObject selectedUI;
    private Building lastReferencedBuilding;
    private int lastReferencedRoomID;


    public void OpenBuildingUI(Building building)
    {
        lastReferencedBuilding = building;
        BuildingLayoutType type = building.GetBuildingType();
        if (building.IsOwned())
        {
            switch (type)
            {
                case BuildingLayoutType.A1:
                    selectedUI = A1OwnedPanel;
                    selectedUI.GetComponent<ParentHousePanel>().Populate(building);
                    selectedUI.SetActive(true);
                    ClosePersistentUI();
                    break;
            }
        }
        else if (building.IsPubliclyEnterable())
        {
            switch (building.GetBuildingUsageType())
            {
                case BuildingUsageType.Retail:
                    selectedUI = shopPanel;
                    selectedUI.GetComponent<ShopPanel>().Populate(building);
                    selectedUI.SetActive(true);
                    ClosePersistentUI();
                    break;
            }
        }
    }
    public void OpenLastReferencedBuildingUI()
    {
        OpenBuildingUI(lastReferencedBuilding);
    }
    public void OpenMeetingLocationUI(MeetingLocation location)
    {
        MeetingLocationType type = location.GetMeetingLocationType();
        switch (type)
        {
            case MeetingLocationType.Park:
                selectedUI = parkPanel;
                selectedUI.SetActive(true);
                selectedUI.GetComponent<ParkPanel>()?.Populate(location as Park);
                ClosePersistentUI();
                break;
        }
    }
    public void OpenLastReferencedRoomUI()
    {
        OpenRoomUI(lastReferencedRoomID);
    }
    public void OpenRoomUI(int roomId)
    {
        lastReferencedRoomID = roomId;
        Room room = lastReferencedBuilding.GetRoom(roomId);
        RoomUI roomUI = roomPanel.GetComponent<RoomUI>();
        roomUI.Populate(room);
        roomPanel.SetActive(true);
        ClosePersistentUI();

    }
    public void OpenPersistentUI()
    {
        persistentUI.SetActive(true);
    }
    public void ClosePersistentUI()
    {
        persistentUI.SetActive(false);
    }
    public void OpenContactsUI()
    {
        contactsUI.SetActive(true);
        ClosePersistentUI() ;
    }
    public void OpenPlanterUI(Planter planter)
    {
        PlanterType type = planter.GetPlanterType();
        switch (type)
        {
            case PlanterType.Flowerpot:
                flowerpotPanel.SetActive(true);
                flowerpotPanel.GetComponent<FlowerpotPanel>().Populate(planter);
                break;
        }
        ClosePersistentUI();
    }
    public void OpenChoosePlacableListUI(Room room)
    {
        choosePlacableListPanel.SetActive(true);
        choosePlacableListPanel.GetComponent<ChoosePlacableListPanel>().OpenUI(room);
    }
    public void CloseUI(GameObject selectedPanel)
    {
        OpenPersistentUI();
        OnUnderlyingUIClosed?.Invoke();
        selectedPanel.SetActive(false);
    }
    public Building GetLastReferencedBuilding() {  return lastReferencedBuilding; }
    public int GetLastReferencedRoomID() { return lastReferencedRoomID;  }
    public Room GetLastReferencedRoom() { return lastReferencedBuilding.GetRoom(lastReferencedRoomID); }
    public GameObject GetRoomPanel() { return roomPanel; }
}

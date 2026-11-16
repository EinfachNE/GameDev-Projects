using System;
using UnityEngine;

public class RoomBuilderHelper: MonoBehaviour
{
    private int roomId;
    [SerializeField] private GameObject newRoomPrefab;
    private Building building;
    [SerializeField] private UIManager uiManager;
    public void BuildRoom()
    {
        building = uiManager.GetLastReferencedBuilding();
        roomId = uiManager.GetLastReferencedRoomID();
        building.BuildRoom(newRoomPrefab, roomId);
    }
}

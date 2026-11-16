using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

public enum BuildingUsageType
{
    Residential,
    Retail
}
public class Building : PlotContent
{
    [Header("Building Data")]
    [SerializeField] private BuildingDefinition definition;
    [SerializeField] private BuildingUsageType buildingUsageType;
    [SerializeField] private bool isOwned;
    [SerializeField] private bool isPubliclyEnterable;
    [SerializeField] private List<Room> rooms = new List<Room>();

    private void Awake()
    {
        if (rooms.Count > definition.GetMaxRooms()) { throw new ArgumentOutOfRangeException("Building has more Rooms than definition allows"); }
    }
    public override void Initialize()
    {
        for (int i = 0; i < rooms.Count; i++) 
        {
            rooms[i].Setup();
        }
        GetVisualGO().sprite = definition.GetSprite();
    }
    public BuildingDefinition GetBuildingDefinition() {  return definition; }
    public bool IsOwned() {  return isOwned; }
    public bool IsPubliclyEnterable() {  return isPubliclyEnterable; }
    public BuildingUsageType GetBuildingUsageType() {  return buildingUsageType; }
    public void SetIsOwned(bool isOwned) { this.isOwned = isOwned; }
    public BuildingLayoutType GetBuildingType()
    {
        return definition.GetBuildingType();
    }
    public void BuildRoom(GameObject newRoomPrefab, int roomId)
    {
        Destroy(rooms[roomId].gameObject);
        rooms[roomId] = Instantiate(newRoomPrefab, transform.position, Quaternion.identity, this.transform).GetComponent<Room>();
        rooms[roomId].Setup();  
    }
    public RoomType GetRoomType(int id)
    {
        return rooms[id].GetRoomType();
    }
    public Room GetRoom(int id)
    {
        return rooms[id];
    }
}

using Unity.VisualScripting;
using UnityEngine;

public class WorldProtoype : MonoBehaviour
{
    [SerializeField] Building parentHouse;
    [SerializeField] Building testStore;
    [SerializeField] MeetingLocation meetingLocation;
    [SerializeField] private GridManager gridManager;
    [SerializeField] private Player player;
    [SerializeField] private ItemDefinition flowerpot;


    public void Build()
    {
        Plot plot = gridManager.GetPlotFromXY(2, 2);
        Building building = Instantiate(parentHouse, gridManager.GetWorldPosFromXY(2, 2), Quaternion.identity, plot.transform);
        plot.SetContent(building);

        plot = gridManager.GetPlotFromXY(0, 3);
        building = Instantiate(testStore, gridManager.GetWorldPosFromXY(0, 3), Quaternion.identity, plot.transform);
        plot.SetContent(building);

        plot = gridManager.GetPlotFromXY(0, 0);
        MeetingLocation park = Instantiate(meetingLocation, gridManager.GetWorldPosFromXY(0, 0), Quaternion.identity, plot.transform);
        plot.SetContent(park);

        player.GetComponent<Inventory>().AddItem(flowerpot, 1);
    }
}

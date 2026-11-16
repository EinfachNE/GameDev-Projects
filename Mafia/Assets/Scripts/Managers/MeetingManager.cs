using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class MeetingManager : MonoBehaviour
{

    public static MeetingManager Instance;
    [SerializeField] private List<Meeting> meetings = new List<Meeting>();
    [SerializeField] private GridManager grid;
    [SerializeField] Player player;

    ////////////////////////////////////////////////TEMP
    [SerializeField] private Vector2Int locationXY;
    [SerializeField] private Contact contact;
    [SerializeField] private ItemDefinition item;
    [SerializeField] private int amount;

    ///////////////////////////////////////////////////

    public static event Action OnMeetingClosed;

    private void Awake()
    {
        Instance = this;
    }
    //public void ArrangeMeeting(location, time, contact, type (selling/buying), product, amount)
    public void ArrangeMeeting()
    {
        PlotContent content = grid.GetPlotFromXY(locationXY).GetContent();
        if (content?.GetPlotContentType() == PlotContentType.MeetingLocation)
        {
            meetings.Add(new Meeting(locationXY, contact, item, amount));
        }
    }
    public List<Meeting> SearchByLocation(Vector2Int location)
    {
        List<Meeting> matches = new List<Meeting>();
        for (int i = 0; i<meetings.Count; i++)
        {
            if (meetings[i]?.GetLocation() == location)
            {
                matches.Add(meetings[i]);
            }
        }
        return matches;
    }
    public int GetNumberOfMeetingsAt(Vector2Int location)
    {
        return SearchByLocation(location).Count;
    }
    public void RemoveMeeting(int index)
    {
        meetings.Remove(meetings[index]);
    }
  
    public bool MeetingTransaction(Meeting meeting)
    {
        ItemDefinition item = meeting.GetItem();
        int amount = meeting.GetAmount();
        if(player.GetComponent<Inventory>().RemoveItem(item, amount))
        {
            player.GetComponent<MoneyContainer>().AddMoney(item.GetBaseValue()*amount);
            meetings.Remove(meeting);
            OnMeetingClosed?.Invoke();
            return true;
        }
        else return false;
    }
}

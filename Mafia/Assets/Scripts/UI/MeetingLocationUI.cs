using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class MeetingLocationUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI numberOfMeetingsText;
    [SerializeField] private GameObject meetingsEntry;
    [SerializeField] private Transform meetingsEntryParent;
    private MeetingManager meetingManager;
    private MeetingLocation location;

    List<GameObject> meetingEntrys = new List<GameObject>();
    
    private void Awake()
    {
        meetingManager = MeetingManager.Instance;
    }
    private void OnEnable()
    {
        MeetingManager.OnMeetingClosed += Repopulate;
    }
    private void OnDisable()
    {
        MeetingManager.OnMeetingClosed -= Repopulate;
    }
    public void Populate(MeetingLocation location)
    {
        this.location = location;
        Repopulate();
    }
    public void Repopulate()
    {
        ClearEntrys();
        InitiateMeetingsList();
        int numberOfMeetings = meetingManager.GetNumberOfMeetingsAt(location.GetXY());
        numberOfMeetingsText.text = numberOfMeetings.ToString();
    }
    public void InitiateMeetingsList()
    {
        List<Meeting> meetings = meetingManager.SearchByLocation(location.GetXY());
        for(int i = 0; i < meetings.Count; i++)
        {
            MeetingEntryUI newMeeting = Instantiate(meetingsEntry, meetingsEntryParent).GetComponent<MeetingEntryUI>();
            newMeeting.Populate(meetings[i]);
            meetingEntrys.Add(newMeeting.gameObject);
        }
    }
    public void CloseUI()
    {
        ClearEntrys();
        UIManager.Instance.CloseUI(this.gameObject);
    }
    public void ClearEntrys()
    {
        for (int i = 0; i < meetingEntrys.Count; i++)
        {
            Destroy(meetingEntrys[i]);
        }
        meetingEntrys.Clear();
    }
}

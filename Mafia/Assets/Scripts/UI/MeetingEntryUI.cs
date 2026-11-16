using TMPro;
using UnityEngine;

public class MeetingEntryUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI contactName;
    [SerializeField] private TextMeshProUGUI demand;
    [SerializeField] private TextMeshProUGUI offer;

    private MeetingManager meetingManager;
    private Meeting meeting;
    private void Start()
    {
        meetingManager = MeetingManager.Instance;
    }
    public void Populate(Meeting meeting)
    {
        this.meeting = meeting;
        contactName.text = meeting.GetContact().GetContactName(); 
        demand.text = "wants: " + meeting.GetAmount().ToString() + "x " + meeting.GetItem().GetDisplayName();
        offer.text = "for: " + meeting.GetItem().GetBaseValue() + "$";
    }
    public void CloseMeeting()
    {
        meetingManager.MeetingTransaction(meeting);
    }
}

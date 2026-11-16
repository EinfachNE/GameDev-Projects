using UnityEngine;

public class ContactPanel : MonoBehaviour
{
    [SerializeField] private MeetingManager contact;

    public void ArrangeMeeting()
    {
        contact.ArrangeMeeting();
    }
}

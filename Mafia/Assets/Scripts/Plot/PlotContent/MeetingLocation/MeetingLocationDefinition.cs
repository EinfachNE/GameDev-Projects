using UnityEngine;

public enum MeetingLocationType
{
    Park,
    ParkingLot
}

[CreateAssetMenu(fileName = "MeetingLoactionDefinition", menuName = "Scriptable Objects/MeetingLoactionDefinition")]
public class MeetingLocationDefinition : ScriptableObject
{
    [SerializeField] private string displayName;
    [SerializeField] private MeetingLocationType type;
    [SerializeField] private Sprite sprite;

    public string GetName()
    {
        return this.displayName;
    }
    public Sprite GetSprite()
    {
        return sprite;
    }
    public MeetingLocationType GetMeetingLoactionType()
    {
        return type;
    }
}

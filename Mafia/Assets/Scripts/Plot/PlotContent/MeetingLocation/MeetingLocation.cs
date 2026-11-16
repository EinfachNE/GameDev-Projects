using UnityEngine;

public class MeetingLocation : PlotContent
{
    [SerializeField] private MeetingLocationDefinition definition;

    public override void Initialize()
    {
        GetVisualGO().sprite = definition.GetSprite();
    }
    public MeetingLocationDefinition GetDefinition()
    {
        return definition;
    }
    public MeetingLocationType GetMeetingLocationType()
    {
        return definition.GetMeetingLoactionType();
    }
}

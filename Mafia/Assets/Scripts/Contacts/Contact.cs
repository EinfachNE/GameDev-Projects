using UnityEngine;

public class Contact : MonoBehaviour
{
    [SerializeField] private ContactDefinition contactDefinition;
    [SerializeField] private string displayName;
    [SerializeField] private Vector2Int closestMeetingLocation; // Maybe change to MeetingLocation closest...
    /*[SerializeField] private float timeSinceLastBuy;
     
     interest/demand
    relationship lvl
    trust
    
     
     */

    public string GetContactName()
    {
        return displayName;
    }
}

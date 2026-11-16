using System.ComponentModel;
using UnityEngine;

public enum ContactType
{
    Buyer,
    Dealer,
}

[CreateAssetMenu(fileName = "ContactDefinition", menuName = "Scriptable Objects/ContactDefinition")]
public class ContactDefinition : ScriptableObject
{
    [SerializeField] private ContactType contactType;

    public ContactType GetContactType() { return contactType; }
}

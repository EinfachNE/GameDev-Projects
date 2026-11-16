using UnityEngine;

public class Meeting
{
    private Vector2Int location;
    private Contact contact;
    private ItemDefinition item;
    private int amount;

    public Meeting(Vector2Int location, Contact contact, ItemDefinition item, int amount)
    {
        this.location = location;
        this.contact = contact;
        this.item = item;
        this.amount = amount;
    }
    public Vector2Int GetLocation()
    {
        return location;
    }
    public Contact GetContact() 
    {
        return contact;
    }
    public ItemDefinition GetItem() 
    {
        return item;
    }
    public int GetAmount()
    {
        return amount;
    }
}

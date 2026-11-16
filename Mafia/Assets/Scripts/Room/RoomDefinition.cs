using UnityEngine;

public enum RoomType
{
    Undefined,
    Standard,
    Garage,
    Basement,
}

[CreateAssetMenu(fileName = "RoomDefinition", menuName = "Scriptable Objects/RoomDefinition")]
public class RoomDefinition : ScriptableObject
{
    [SerializeField] private RoomType type;
    [SerializeField] private string displayName;
    [SerializeField] private int baseCapacity;

    public RoomType GetRoomType()
    {
        return type;
    }
    public int GetBaseCapacity()
    {
        return baseCapacity;
    }
}

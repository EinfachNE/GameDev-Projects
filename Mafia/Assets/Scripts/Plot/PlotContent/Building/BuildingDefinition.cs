using System;
using Unity.VisualScripting;
using UnityEngine;

public enum BuildingLayoutType
{
    Undefined,
    A1,

}

[CreateAssetMenu(fileName = "BuildingDefinition", menuName = "Scriptable Objects/BuildingDefinition")]
public class BuildingDefinition : ScriptableObject
{
    [SerializeField] private string displayName;
    [SerializeField] private BuildingLayoutType type;
    [SerializeField] private Sprite sprite;
    [SerializeField] private int maxRooms;



    //purchase value

    public string GetName()
    {
        return this.displayName;
    }
    public Sprite GetSprite()
    {
        return sprite;
    }
    public BuildingLayoutType GetBuildingType()
    {
        return type;
    }
    public int GetMaxRooms()
    {
        return maxRooms;
    }
}

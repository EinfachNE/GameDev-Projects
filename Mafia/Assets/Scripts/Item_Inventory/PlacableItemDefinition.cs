using UnityEngine;


[CreateAssetMenu(fileName = "ItemDefinition", menuName = "Scriptable Objects/Items/PlacableItemDefinition")]
public class PlacableItemDefinition : ItemDefinition
{
    [SerializeField] private PlacableDefinition placableDefinition;

    public PlacableDefinition GetPlacableDefinition() { return placableDefinition; }
    
}

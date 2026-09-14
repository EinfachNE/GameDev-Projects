using UnityEngine;

[CreateAssetMenu(fileName = "ItemDefinition", menuName = "Scriptable Objects/ItemDefinition")]
public class ItemDefinition : ScriptableObject
{
    [SerializeField] private string id;
    [SerializeField] private string DisplayName;
    [SerializeField] private Sprite icon;

    //[SerializeField] private int maxStackSize;
    [SerializeField] private int basePrice;

    [SerializeField] private ItemCategory category;
}

public enum ItemCategory
{
    Alcohol,
}

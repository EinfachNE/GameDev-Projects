using System.ComponentModel;
using UnityEngine;

public enum ItemType
{
    Canabis,
    Alcohol,
    Placable,
    Seed,
}

[CreateAssetMenu(fileName = "ItemDefinition", menuName = "Scriptable Objects/Items/ItemDefinition")]
public class ItemDefinition : ScriptableObject
{
    [SerializeField] private string displayName;
    [SerializeField] private ItemType type;
    [SerializeField] private Sprite icon;
    [SerializeField] private int baseValue;
    [SerializeField] private int maxStackSize;
    
    public int GetMaxStackSize()
    {
        return maxStackSize;
    }
    public int GetBaseValue() { return baseValue; }
    public string GetDisplayName() {  return displayName; }
    public Sprite GetIcon() { return icon; }
    public ItemType GetItemType() { return type; }
}

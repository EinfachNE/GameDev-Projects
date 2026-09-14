using UnityEngine;

public class WarehouseBehaviour : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private ItemDefinition beerItem;
    private void Awake()
    {
        inventory = GetComponent<Inventory>();
    }

    private void Start()
    {
        inventory.AddItem(beerItem, 20);
    }
}

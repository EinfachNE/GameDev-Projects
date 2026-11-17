using NUnit.Framework.Constraints;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChoosePlacableListPanel : MonoBehaviour
{

    [SerializeField] GameObject availableEntrysUI;
    [SerializeField] Transform availableEntrysParent;

    private List<GameObject> availableEntries = new List<GameObject>();
    private UIManager uIManager;
    private Inventory playerInventory;
    public void OpenUI(Room room)
    {
        RemoveEntrys();
        for (int i = 0; i < playerInventory.GetLength(); i++)
        {
            PlacableItemDefinition item = playerInventory.GetItem(i) as PlacableItemDefinition;
            if (item != null)
            {
                GameObject newEntry = Instantiate(availableEntrysUI, availableEntrysParent);
                newEntry.GetComponent<AvailablePlacablesEntryUI>().Setup(CreatePlacableFromItem(item), room);
                newEntry.GetComponent<AvailablePlacablesEntryUI>().OnPlacableAdded += CloseUI;
                availableEntries.Add(newEntry);
            }
        }
    }

    private Placable CreatePlacableFromItem(PlacableItemDefinition item)
    {
        PlacableDefinition definition = item.GetPlacableDefinition();

        switch (definition.GetPlacableType())
        {
            case PlacableType.Planter:
                {
                    if (definition is PlanterDefinition planterDefinition)
                    {
                        switch (planterDefinition.GetPlanterType())
                        {
                            case PlanterType.Flowerpot:
                                return new Flowerpot(planterDefinition);

                            default:
                                return new Planter(planterDefinition);
                        }
                    }

                    break;
                }
        }

        return new Placable(definition);
    }
    private void OnEnable()
    {
        uIManager = UIManager.Instance;
        playerInventory = Player.Instance.GetComponent<Inventory>();
        uIManager.OnUnderlyingUIClosed += CloseUI;
    }
    private void OnDisable()
    {
        
        uIManager.OnUnderlyingUIClosed -= CloseUI;
    }
    public void CloseUI()
    {
        RemoveEntrys();
        gameObject.SetActive(false); ;
    }
    public void RemoveEntrys()
    {
        for (int i = 0; i < availableEntries.Count; i++)
        {
            availableEntries[i].GetComponent<AvailablePlacablesEntryUI>().OnPlacableAdded -= CloseUI;
            Destroy(availableEntries[i]);
        }
        availableEntries?.Clear();
    }
}

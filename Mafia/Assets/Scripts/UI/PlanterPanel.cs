using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlanterPanel : MonoBehaviour
{

    /// //////////////////////////////////////// TEMP
    [SerializeField] private PlantDefinition seed;
    ///////////////////////////////////////////////////

    private TimeManager timeManager;
    private Plant[] plants;
    [SerializeField] private TextMeshProUGUI[] state;
    [SerializeField] private TextMeshProUGUI[] percent;
    [SerializeField] private TextMeshProUGUI[] plantName;
    [SerializeField] private GameObject[] harvestButton;
    [SerializeField] private GameObject[] plantButton;
    private Planter planter;
    private void Start()
    {
        timeManager = TimeManager.Instance;
    }
    public void Populate(Planter planter)
    {
        this.planter = planter;
        PlanterDefinition definition = planter.GetDefinition() as PlanterDefinition;
    }
    private void Update()
    {
        plants = planter.GetPlants();
        for (int i = 0; i < plants.Length; i++)
        {
            if (plants[i] != null) 
            {
                plants[i].UpdateState(timeManager.GetTotalTime());
                plantName[i].text = plants[i].GetDefinition().GetDisplayName();
                state[i].text = plants[i].GetPlantState().ToString();
                if (plants[i].IsHarvestable())
                {
                    harvestButton[i].SetActive(true);
                    percent[i].text = "Is Harvestable";
                }
                else
                {
                    percent[i].text = plants[i].GetGrowthPercent().ToString() + "% grown";
                }
            }
        }
    }
    public void Harvest(int idx)
    {
        if (plants[idx].Harvest())
        {
            planter.RemovePlant(idx);
            state[idx].text = "Not Planted";
            percent[idx].text = "0";
            harvestButton[idx].SetActive(false);
            plantButton[idx].SetActive(true);
        }
        
    }
    public void Plant(int idx)
    {
        planter.Plant(seed, idx);
        plantButton[idx].SetActive(false);
        state[idx].gameObject.SetActive(true);
        plantName[idx].gameObject.SetActive(true);
        percent[idx].gameObject.SetActive(true);
    }
}

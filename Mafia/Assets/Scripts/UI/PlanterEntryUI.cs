using TMPro;
using UnityEngine;

public class PlanterEntryUI : PlacableEntryUI
{
    private Planter planter;
    TimeManager timeManager;
    [SerializeField] TextMeshProUGUI[] plantName;
    [SerializeField] TextMeshProUGUI[] progress;
    private UIManager uIManager;
    public override void Setup(Placable placable)
    {
        this.planter = placable as Planter;
        uIManager = UIManager.Instance;

    }
    public override void OpenUI()
    {
        uIManager.OpenPlanterUI(planter);
    }
    private void Start()
    {
        timeManager = TimeManager.Instance;
    }
    private void Update()
    {
        Debug.Log(planter.GetPlants());
        Plant[] plants = planter.GetPlants();
        for (int i = 0; i < plants.Length; i++)
        {
            if (plants[i] == null)
            {
                plantName[i].text = "Empty";
                progress[i].text = "0%";
            }
            else
            {
                plants[i].UpdateState(timeManager.GetTotalTime());
                plantName[i].text = plants[i].GetDefinition().GetDisplayName().ToString();
                if (plants[i].GetGrowthPercent() >= 100)
                {
                    progress[i].text = "Harvestable";
                }
                else
                {
                    progress[i].text = plants[i].GetGrowthPercent().ToString() + "% grown";
                }
            }
        }
    }
}

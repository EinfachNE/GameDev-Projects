using TMPro;
using UnityEngine;


public abstract class PlotPanel : MonoBehaviour
{
    protected Plot plot;
    protected GridManager gridManager;
    private PlotUIManager plotUIManager;

    [SerializeField] private GameObject isOwnedPanel;
    [SerializeField] private GameObject notOwnedPanel;

    [SerializeField] private TextMeshProUGUI isOwnedByText;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI plotValueText;

    public void SetPlot(Plot plot)
    {
        this.plot = plot;
    }
    public void ClosePanel()
    {
        plotUIManager.ClosePlotPanel(this.gameObject);
    }
    public void SetGridManager(GridManager gridManager)
    {
        this.gridManager = gridManager;
    }
    public void SetPlotUIManager(PlotUIManager plotUIManager)
    {
        this.plotUIManager = plotUIManager;
    }
    public void BuyPlot()
    {
        plot.GetPlotRuntimeData().SetIsOwnedBy(EntityType.Player);
        LoadData();
    }
    public virtual void LoadData() 
    {
        if (plot.GetPlotRuntimeData().GetIsOwnedBy() == EntityType.Player)
        {
            isOwnedPanel.SetActive(true);
            notOwnedPanel.SetActive(false);

        }
        else
        {
            isOwnedPanel.SetActive(false);
            notOwnedPanel.SetActive(true);
        }
        isOwnedByText.text = "Owned by: " + plot.GetPlotRuntimeData().GetIsOwnedBy().ToString();
        nameText.text = plot.GetPlotStaticData().GetPlotType().ToString();
        plotValueText.text = plot.GetPlotStaticData().GetBaseValue().ToString() + "$";
    }
}

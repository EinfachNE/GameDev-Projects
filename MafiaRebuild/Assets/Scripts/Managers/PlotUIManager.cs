using UnityEngine;

public class PlotUIManager : MonoBehaviour
{
    private GameObject panelInstance;
    [SerializeField] private GridManager gridManager;
    [SerializeField] private SelectionManager selectionManager;
    [SerializeField] private GameObject runningUI;

    public void OpenPlotPanel(Plot plot)
    {
        runningUI.SetActive(false);
        panelInstance = Instantiate(plot.GetPlotStaticData().GetPanel(), this.transform);
        PlotPanel panel = panelInstance.GetComponent<PlotPanel>();
        panel.SetGridManager(gridManager);
        panel.SetPlotUIManager(this);
        panel.SetPlot(plot);
        panel.LoadData();
    }
    public void ClosePlotPanel(GameObject panel)
    {
        Destroy(panel);
        runningUI.SetActive(true);
        selectionManager.SetIsPanelOpen(false);
    }
}

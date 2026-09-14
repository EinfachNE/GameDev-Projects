using UnityEngine;
using TMPro;

public class WarehousePlotPanel : PlotPanel
{
    [SerializeField] private TextMeshProUGUI beerAmountText;
    [SerializeField] private ItemDefinition beerItem;
    public override void LoadData()
    {
        base.LoadData();
        beerAmountText.text = plot.GetComponent<Inventory>().GetAmount(beerItem).ToString();
    }
}

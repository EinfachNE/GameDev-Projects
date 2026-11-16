using System;
using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    private MoneyContainer playerMoney;
    [SerializeField] private TextMeshProUGUI cashText;
    private void Start()
    {
        playerMoney = Player.Instance.GetComponent<MoneyContainer>();
        playerMoney.TriggerMoneyChanged += UpdateUI;
    }
    private void OnDisable()
    {
        playerMoney.TriggerMoneyChanged -= UpdateUI;
    }

    public void UpdateUI()
    {
        cashText.text = playerMoney.GetCurrentAmount().ToString() + "$";
    }


}

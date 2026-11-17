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
        UpdateUI();
    }
    private void OnEnable()
    {
        if (playerMoney != null)
        {
            playerMoney.TriggerMoneyChanged += UpdateUI;
            UpdateUI();
        }
    }
    private void OnDisable()
    {
        if (playerMoney != null)
            playerMoney.TriggerMoneyChanged -= UpdateUI;
    }

    public void UpdateUI()
    {
        cashText.text = playerMoney.GetCurrentAmount().ToString() + "$";
    }


}

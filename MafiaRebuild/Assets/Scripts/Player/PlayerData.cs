using UnityEngine;
using TMPro;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private int moneyAmount;


    [SerializeField] private TextMeshProUGUI moneyAmountText;

    private void Start()
    {
        moneyAmountText.text = moneyAmount.ToString() + "$";
    }
}

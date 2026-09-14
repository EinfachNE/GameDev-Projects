using UnityEngine;
using TMPro;

public class DisplayPlayerMoney : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI moneyText;
    private PlayerStats playerStats;
    
        private void Start()
    {
        playerStats = References.player.GetComponent<PlayerStats>();
    }

    private void OnEnable()
    {
        PlayerStats.triggerMoneyChanged += ChangeMoneyDisplayedTo;
    }


    public void ChangeMoneyDisplayedTo()
    {
        moneyText.text = playerStats.GetMoneyAmount().ToString();
    }
}

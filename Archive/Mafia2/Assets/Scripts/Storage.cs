using UnityEngine;

public class Storage : MonoBehaviour
{
    private int moneyAmount = 0;

    #region getset
    public void SetMoneyAmount(int value)
    {
        moneyAmount = value;
    }
    public void IncreaseMoneyAmount(int value)
    {
        moneyAmount += value;
    }
    public int GetMoneyAmount()
    {
        return moneyAmount;
    }
    #endregion
}

using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private int currentTurnNumber = 0;

    public void InitNextTurn()
    {
        currentTurnNumber++;
    }
}

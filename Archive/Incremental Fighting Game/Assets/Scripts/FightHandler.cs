using UnityEngine;

public class FightHandler : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemyObject;
    private EnemyBehaviour enemy;
    private bool isPlayersTurn;

    public void FightStarted()
    {
        isPlayersTurn = true;
        enemy = enemyObject.GetComponent<EnemyBehaviour>();

    }
}

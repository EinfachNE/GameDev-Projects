using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    [SerializeField] private EnemyData enemy;

    private void Start()
    {
        enemy.SetHealth(enemy.GetBaseHealth());
    }
    public void print()
    {
        Debug.Log("I am an Enemy");
    }

    public EnemyData AccesStats()
    {
        return enemy;
    }
    

    
}

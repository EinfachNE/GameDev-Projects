using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Enemy : MonoBehaviour
{
    [SerializeField] EnemyData enemyData;
    Rigidbody2D rb;
    GameObject player;

    delegate void OnEnemyDeath();
    OnEnemyDeath onEnemyDeath;

    private float currentHealth;
    private void Awake()
    {
        currentHealth = enemyData.GetMaxHealthAmount();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        player = References.player;
    }

    public void TakeDamage(float value)
    {
        currentHealth -= value;
        Debug.Log(enemyData.GetEnemyName() + " has taken " + value + " Damage. Remaining health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log(enemyData.GetEnemyName() + " Dies");
        player.GetComponent<PlayerStats>().IncreaseMoneyAmountBy(enemyData.GetBaseMoneyWorthAmount());

        Destroy(gameObject);
    }


    public void MoveTowardsPlayer()
    {
        Vector3 playerDirection = player.transform.position - transform.position;
        rb.linearVelocity = playerDirection.normalized * enemyData.GetMoveSpeedAmount(); 
    }

    private void FixedUpdate()
    {
        MoveTowardsPlayer();
    }
}

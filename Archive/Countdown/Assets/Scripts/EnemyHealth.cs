using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maximumHealth;

    private float currentHealth;

    private void Awake()
    {
        currentHealth = maximumHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
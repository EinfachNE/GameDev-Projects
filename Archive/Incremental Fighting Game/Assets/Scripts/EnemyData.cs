using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/Enemy")]
public class EnemyData : ScriptableObject
{
    private int currentHealth;
    [SerializeField] private int baseHealth;
    [SerializeField] private int damage;

    public int GetHealth()
    {
        return currentHealth;
    }
    public void SetHealth(int value)
    {
        currentHealth = value;
    }
    public void IncreaseHealthBy(int value)
    {
        currentHealth += value;
        if(currentHealth <= 0)
        {
            Debug.Log(this.name + " has been slain");
            // Trigger Fight end
        }
    }

    public int GetBaseHealth()
    {
        return baseHealth;
    }
    public void SetBaseHealth(int value)
    {
        baseHealth = value;
    }
    public void IncreaseBaseHealthBy(int value)
    {
        baseHealth += value;
        if (baseHealth < currentHealth)
        {
            currentHealth = baseHealth;
        }
        else if (baseHealth <= 0)
        {
            Debug.Log(this.name + " has been slain (0 MaxHealth)");
            // Trigger Fight end
        }
    }

    public int GetDamage()
    {
        return damage;
    }
    public void SetDamage(int value)
    {
        damage = value;
    }
    public void IncreaseDamageBy(int value)
    {
        damage += value;
    }
}

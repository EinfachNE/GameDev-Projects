using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemies/New Enemy Data")]
public class EnemyData : ScriptableObject
{
    [SerializeField] private string enemyName;
    [SerializeField] private int damage;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxHealth;
    [SerializeField] private int baseMoneyWorth;

    #region getset
    public string GetEnemyName() { return enemyName; }
    public void SetEnemyName(string newName) { enemyName = newName; }
    public int GetDamageAmount() { return damage; }
    public void SetDamageAmount(int value) { damage = value; }
    public float GetMoveSpeedAmount() { return moveSpeed; }
    public void SetMoveSpeedAmount(float value) { moveSpeed = value; }
    public float GetMaxHealthAmount() { return maxHealth; }
    public void SetMaxHealthAmount(float value) { maxHealth = value; }
    public int GetBaseMoneyWorthAmount() { return baseMoneyWorth; }
    public void SetBaseMoneyWorthAmount(int value) { baseMoneyWorth = value; }
    #endregion
}

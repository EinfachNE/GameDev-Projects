
using UnityEngine;

public class AutoAttack : MonoBehaviour
{

    [SerializeField] private float detectionRange;
    [SerializeField] private float attackSpeed; //shots per second
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;

    private float nextShotTime;
    private Transform currentTarget;


    private void Update()
    {
        Transform target = FindClosestEnemy();

        if (target == null)
        {
            return;
        }

        if (Time.time >= nextShotTime)
        {
            Shoot(target);

            nextShotTime = Time.time + 1f / attackSpeed;
        }
    }

    private Transform FindClosestEnemy()
    {
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, detectionRange, enemyLayer);

        Transform closestEnemy = null;
        float closestDistanceSquared = Mathf.Infinity;

        foreach (Collider2D enemy in enemiesInRange)
        {
            Vector2 difference = enemy.transform.position - transform.position;
            float distanceSquared = difference.sqrMagnitude;

            if (distanceSquared < closestDistanceSquared)
            {
                closestDistanceSquared = distanceSquared;
                closestEnemy = enemy.transform;
            }
        }
        return closestEnemy;
    }

    private void Shoot(Transform target)
    {
        Vector2 direction =
            (target.position - firePoint.position).normalized;

        GameObject projectileObject = Instantiate(
            projectilePrefab,
            firePoint.position,
            Quaternion.identity
        );

        Projectile projectile =
            projectileObject.GetComponent<Projectile>();

        projectile.Initialize(direction);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }

}

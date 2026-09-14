using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform enemyPrefab;

    [SerializeField] private float spawnCooldown;
    private float timeTillNextSpawn = 2;



    // Update is called once per frame
    void Update()
    {
        if (timeTillNextSpawn <= 0)
        {
            Instantiate(enemyPrefab);
            timeTillNextSpawn = spawnCooldown;
        }
        else
        {
           timeTillNextSpawn -= Time.deltaTime;
        }
    }
}

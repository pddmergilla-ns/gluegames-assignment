using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool enemyPool;
    [SerializeField] private Transform player;
    [SerializeField] private float spawnRadius = 10f;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private EffectManager effectManager;
    [SerializeField] private Enemy[] enemyTags;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), spawnInterval, spawnInterval);
    }

    private void SpawnEnemy()
    {
        Vector2 spawnPosition;
        do
        {
            spawnPosition = (Vector2)player.position + Random.insideUnitCircle * spawnRadius;
        } while (Vector2.Distance(spawnPosition, player.position) < 2f); // Avoid close spawn

        string randomTag = enemyTags[Random.Range(0, enemyTags.Length)].Tag;
        GameObject enemy = enemyPool.GetObject(randomTag);

        if (enemy != null)
        {
            enemy.transform.position = spawnPosition;
            enemy.GetComponent<Enemy>().Initialize(player, enemyPool, gameManager, effectManager);
        }
    }
}

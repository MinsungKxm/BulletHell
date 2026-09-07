using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject[] enemyPrefabs;

    public float firstSpawnDelay = 1f;
    public float spawnInterval = 5f;

    private Renderer planeRenderer;

    void Start() {
        planeRenderer = GetComponent<Renderer>();

        if (planeRenderer == null) {
            Debug.LogError(
                "EnemySpawner must be attached to an object with a Renderer."
            );

            return;
        }

        if (enemyPrefabs == null || enemyPrefabs.Length == 0) {
            Debug.LogError(
                "No enemy prefabs have been assigned."
            );

            return;
        }

        InvokeRepeating(
            nameof(SpawnEnemy),
            firstSpawnDelay,
            spawnInterval
        );
    }

    void SpawnEnemy() {
        Bounds planeBounds = planeRenderer.bounds;

        Vector3[] spawnPoints =
        {
            // Top-left corner
            new Vector3(
                planeBounds.min.x,
                planeBounds.max.y,
                planeBounds.max.z
            ),

            // Top-right corner
            new Vector3(
                planeBounds.max.x,
                planeBounds.max.y,
                planeBounds.max.z
            ),

            // Bottom-left corner
            new Vector3(
                planeBounds.min.x,
                planeBounds.max.y,
                planeBounds.min.z
            ),

            // Bottom-right corner
            new Vector3(
                planeBounds.max.x,
                planeBounds.max.y,
                planeBounds.min.z
            )
        };

        int randomSpawnIndex =
            Random.Range(0, spawnPoints.Length);

        int randomEnemyIndex =
            Random.Range(0, enemyPrefabs.Length);

        GameObject selectedEnemy =
            enemyPrefabs[randomEnemyIndex];

        GameObject spawnedEnemy = Instantiate(
            selectedEnemy,
            spawnPoints[randomSpawnIndex],
            Quaternion.identity
        );

        PlaceEnemyOnGround(
            spawnedEnemy,
            planeBounds.max.y
        );
    }

    void PlaceEnemyOnGround(
        GameObject enemy,
        float groundHeight
    ) {
        Collider enemyCollider =
            enemy.GetComponentInChildren<Collider>();

        if (enemyCollider == null) {
            Debug.LogWarning(
                $"{enemy.name} does not have a Collider."
            );

            return;
        }

        float heightAdjustment =
            groundHeight - enemyCollider.bounds.min.y;

        enemy.transform.position +=
            Vector3.up * heightAdjustment;
    }
}
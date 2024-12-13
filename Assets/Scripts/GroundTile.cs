using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    [SerializeField] GameObject obstacleTallPrefab;
    [SerializeField] GameObject obstaclePrefab;

    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }

    // Spawning both obstacles randomly
    public void SpawnObstacle()
    {
        // Randomly pick the spawn index for the obstacles (choose 2 spawn points in this case)
        int ObstacleSpawnIndex1 = Random.Range(2, 5);
        int ObstacleSpawnIndex2;

        // Ensure the second spawn point is different from the first
        do
        {
            ObstacleSpawnIndex2 = Random.Range(2, 5);
        } while (ObstacleSpawnIndex2 == ObstacleSpawnIndex1);

        Transform spawnPoint1 = transform.GetChild(ObstacleSpawnIndex1).transform;
        Transform spawnPoint2 = transform.GetChild(ObstacleSpawnIndex2).transform;

        // Create an array of both obstacle prefabs
        GameObject[] obstacles = { obstaclePrefab, obstacleTallPrefab };

        // Randomly choose which prefab to spawn for each spawn point
        GameObject selectedObstacle1 = obstacles[Random.Range(0, obstacles.Length)];
        GameObject selectedObstacle2 = obstacles[Random.Range(0, obstacles.Length)];

        // Instantiate the obstacles at their respective spawn points
        Instantiate(selectedObstacle1, spawnPoint1.position, Quaternion.identity, transform);
        Instantiate(selectedObstacle2, spawnPoint2.position, Quaternion.identity, transform);
    }
}

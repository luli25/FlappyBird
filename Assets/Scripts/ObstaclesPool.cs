using UnityEngine;

public class ObstaclesPool : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private int poolSize = 5;
    [SerializeField] private float xSpawnPosition = 12f;
    [SerializeField] private float minYPosition = -2f;
    [SerializeField] private float maxYPosition = 3f;
    [SerializeField] private float baseSpawnTime = 2.5f;
    [SerializeField] private float minSpawnTime = 1.2f;

    private float timeElapsed;
    private int obstaclesCount;
    private GameObject[] obstacles;
    void Start()
    {
        obstacles = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            obstacles[i] = Instantiate(obstaclePrefab);
            obstacles[i].SetActive(false);
        }
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        // El spawnTime se reduce proporcionalmente a la velocidad
        float currentSpawnTime = Mathf.Max(
            minSpawnTime,
            baseSpawnTime * (SpeedManager.Instance.initialSpeed // <-- hacé initialSpeed [HideInInspector] public
                             / SpeedManager.Instance.CurrentSpeed)
        );

        if (timeElapsed > currentSpawnTime && !GameManager.Instance.IsGameOver)
        {
            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        float ySpawnPosition = Random.Range(minYPosition, maxYPosition);
        
        Vector2 spawnPosition = new Vector2(xSpawnPosition, ySpawnPosition);
        obstacles[obstaclesCount].transform.position = spawnPosition;

        if (!obstacles[obstaclesCount].activeSelf)
        {
            obstacles[obstaclesCount].SetActive(true);
        }
        
        timeElapsed = 0f;
        obstaclesCount++;

        if (obstaclesCount == poolSize)
        {
            obstaclesCount = 0;
        }
    }
}

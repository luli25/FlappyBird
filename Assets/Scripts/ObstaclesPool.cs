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

    private float _timeElapsed;
    private int _obstaclesCount;
    private GameObject[] _obstacles;
    void Start()
    {
        _obstacles = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            _obstacles[i] = Instantiate(obstaclePrefab);
            _obstacles[i].SetActive(false);
        }
    }

    void Update()
    {
        _timeElapsed += Time.deltaTime;
        
        float currentSpawnTime = Mathf.Max(
            minSpawnTime,
            baseSpawnTime * (SpeedManager.Instance.initialSpeed
                             / SpeedManager.Instance.CurrentSpeed)
        );

        if (_timeElapsed > currentSpawnTime && !GameManager.Instance.IsGameOver)
        {
            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        float ySpawnPosition = Random.Range(minYPosition, maxYPosition);
        
        Vector2 spawnPosition = new Vector2(xSpawnPosition, ySpawnPosition);
        _obstacles[_obstaclesCount].transform.position = spawnPosition;

        if (!_obstacles[_obstaclesCount].activeSelf)
        {
            _obstacles[_obstaclesCount].SetActive(true);
        }
        
        _timeElapsed = 0f;
        _obstaclesCount++;

        if (_obstaclesCount == poolSize)
        {
            _obstaclesCount = 0;
        }
    }
}

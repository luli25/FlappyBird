using UnityEngine;

public class CoinPool : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private int poolSize = 3;
    [SerializeField] private float xSpawnPosition = 12f;
    [SerializeField] private float minYPosition = -1f;
    [SerializeField] private float maxYPosition = 4f;
    [SerializeField] private float baseSpawnTime = 2.5f;
    [SerializeField] private float minSpawnTime = 1.2f;
    
    private float _timeElapsed;
    private int _coinCount;
    private GameObject[] _coins;
    
    void Start()
    {
        _coins = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            _coins[i] = Instantiate(coinPrefab);
            _coins[i].SetActive(false);
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
            SpawnCoins();
        }
    }

    private void SpawnCoins()
    {
        float ySpawnPosition = Random.Range(minYPosition, maxYPosition);
        Vector2 spawnPosition = new Vector2(xSpawnPosition, ySpawnPosition);
        _coins[_coinCount].transform.position = spawnPosition;

        if (!_coins[_coinCount].activeSelf)
        {
            _coins[_coinCount].SetActive(true);
        }

        _timeElapsed = 0f;
        _coinCount++;

        if (_coinCount == poolSize)
        {
            _coinCount = 0;
        }
    }
}

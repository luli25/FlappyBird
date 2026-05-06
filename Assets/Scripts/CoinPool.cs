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
    
    private float timeElapsed;
    private int coinCount;
    private GameObject[] coins;
    
    void Start()
    {
        coins = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            coins[i] = Instantiate(coinPrefab);
            coins[i].SetActive(false);
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
            SpawnCoins();
        }
    }

    private void SpawnCoins()
    {
        float ySpawnPosition = Random.Range(minYPosition, maxYPosition);
        Vector2 spawnPosition = new Vector2(xSpawnPosition, ySpawnPosition);
        coins[coinCount].transform.position = spawnPosition;

        if (!coins[coinCount].activeSelf)
        {
            coins[coinCount].SetActive(true);
        }

        timeElapsed = 0f;
        coinCount++;

        if (coinCount == poolSize)
        {
            coinCount = 0;
        }

    }
}

using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    public static SpeedManager Instance;

    [Header("Speed")] 
    [HideInInspector] public float initialSpeed = 2.5f;
    [SerializeField] private float maxSpeed = 6f;

    [Header("Progression")] 
    [SerializeField] private float timeToIncreaseSpeed = 5f; // How many seconds to increase speed
    [SerializeField] private float speedIncrement = 0.2f; // How much speed increases
    
    public float CurrentSpeed { get; private set; }

    private float _timer;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); return;
        }
        
        Instance = this;
        
        CurrentSpeed = initialSpeed;
    }

    private void Update()
    {
        if (GameManager.Instance.IsGameOver) return;

        _timer += Time.deltaTime;

        if (_timer >= timeToIncreaseSpeed)
        {
            _timer = 0f;
            CurrentSpeed = Mathf.Min(CurrentSpeed + speedIncrement, maxSpeed);
        }
    }
}

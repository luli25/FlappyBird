using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverText;
    
    [SerializeField]
    private TMP_Text scoreText;

    [SerializeField]
    private TMP_Text coinText;
    
    public static GameManager Instance;
    public bool IsGameOver { get; private set; }
    
    public event Action OnGameOver;

    private bool _canRestart = false;

    private int score;

    private int coinCount;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void GameOver()
    {
        if (IsGameOver)
        {
            return;
        }

        IsGameOver = true;
        gameOverText.SetActive(true);
        OnGameOver?.Invoke();
        
        Invoke(nameof(EnableRestart), 0.5f); // Adds a small delay before restarting the scene
    }

    private void EnableRestart()
    {
        _canRestart = true;
    }

    public void Restart()
    {
        if (!_canRestart)
        {
            return;
        }
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void IncreaseCoinCount()
    {
        coinCount++;
        coinText.text = coinCount.ToString();
    }
}

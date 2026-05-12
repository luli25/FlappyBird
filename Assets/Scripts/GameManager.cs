using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private GameObject homeButton;
    
    public static GameManager Instance;
    public bool IsGameOver { get; private set; }
    
    public event Action OnGameOver;

    private bool _canRestart = false;

    private int _score;

    private int _coinCount;

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
        homeButton.SetActive(true);
        OnGameOver?.Invoke();
        
        Invoke(nameof(EnableRestart), 0.5f); // Adds a small delay before restarting the scene
    }

    public void Restart()
    {
        if (!_canRestart)
        {
            return;
        }

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void IncreaseScore()
    {
        _score++;
        scoreText.text = _score.ToString();
    }

    public void IncreaseCoinCount()
    {
        _coinCount++;
        coinText.text = _coinCount.ToString();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    private void EnableRestart()
    {
        _canRestart = true;
    }
}

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverText;
    
    public static GameManager Instance;
    public bool IsGameOver { get; private set; }
    
    public event Action OnGameOver;

    private bool _canRestart = false;

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
}

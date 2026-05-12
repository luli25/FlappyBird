using UnityEngine;

public class Scroll : MonoBehaviour
{
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        if (_rb == null)
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        
        _rb.linearVelocity = Vector2.left * SpeedManager.Instance.CurrentSpeed;
    }

    void Update()
    {
        if (GameManager.Instance == null)
        {
            return;
        }
    
        if (GameManager.Instance.IsGameOver)
        {
            _rb.linearVelocity = Vector2.zero;
            return;
        }

        _rb.linearVelocity = Vector2.left * SpeedManager.Instance.CurrentSpeed;
    }
}
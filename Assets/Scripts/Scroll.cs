using UnityEngine;

public class Scroll : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();

        // Usa la velocidad actual al activarse desde el pool
        rb.linearVelocity = Vector2.left * SpeedManager.Instance.CurrentSpeed;
    }

    void Update()
    {
        if (GameManager.Instance == null) return;
    
        if (GameManager.Instance.IsGameOver)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        rb.linearVelocity = Vector2.left * SpeedManager.Instance.CurrentSpeed;
    }
}
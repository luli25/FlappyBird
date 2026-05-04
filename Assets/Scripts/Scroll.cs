using System;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    [SerializeField] private float speed = 2.5f;
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        
        rb.linearVelocity = Vector2.left * speed;
    }


    void Update()
    {
        if (GameManager.Instance.IsGameOver)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}

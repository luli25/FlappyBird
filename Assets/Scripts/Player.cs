using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    
    private Rigidbody2D _playerRb;
    private Animator _anim;
    
    void Awake()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        InputManager.Instance.OnFlap += Flap;
        GameManager.Instance.OnGameOver += HandleGameOver;
    }

    private void OnDisable()
    {
        InputManager.Instance.OnFlap -= Flap;
        GameManager.Instance.OnGameOver -= HandleGameOver;
    }

    private void Flap()
    {
        if (GameManager.Instance.IsGameOver)
        {
            return;
        }
        
        _playerRb.linearVelocity = Vector2.zero;
        _playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        _anim.SetTrigger("Flap");
    }
    
    private void HandleGameOver()
    {
        InputManager.Instance.OnFlap -= Flap;
    }

    private void OnCollisionEnter2D()
    {
        GameManager.Instance.GameOver();
        _anim.SetTrigger("Hit");
    }
    
}

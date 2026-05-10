using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private AudioClip flapSound;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioSource gameOverSound;
    
    private Rigidbody2D _playerRb;
    private Animator _anim;
    private AudioSource _audio;
    
    void Awake()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        InputManager.Instance.OnFlap += Flap;
    }

    private void OnDisable()
    {
        InputManager.Instance.OnFlap -= Flap;
    }

    private void Flap()
    {
        if (GameManager.Instance.IsGameOver)
        {
            GameManager.Instance.Restart();
            return;
        }
        
        _playerRb.linearVelocity = Vector2.zero;
        _playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        _anim.SetTrigger("Flap");
        _audio.PlayOneShot(flapSound);
    }

    private void OnCollisionEnter2D()
    {
        GameManager.Instance.GameOver();
        _anim.SetTrigger("Hit");
        _audio.PlayOneShot(hitSound);
        
        gameOverSound.PlayDelayed(hitSound.length);
    }
}

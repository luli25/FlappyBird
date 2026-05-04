using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private ParticleSystem burstFx;
    [SerializeField] private AudioSource coinSound;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
        
        PlayEffect();
        AudioSource.PlayClipAtPoint(coinSound.clip, transform.position);
        GameManager.Instance.IncreaseCoinCount();
        gameObject.SetActive(false); 
    }
    
    private void OnEnable()
    {
        if (burstFx != null)
        {
            burstFx.transform.SetParent(transform);
            burstFx.transform.localPosition = Vector3.zero;
        }
    }

    private void PlayEffect()
    {
        if (burstFx == null)
        {
            return;
        }
        
        ParticleSystem fxInstance = Instantiate(burstFx, transform.position, Quaternion.identity);
        fxInstance.Play();
        Destroy(fxInstance.gameObject, fxInstance.main.duration 
                                       + fxInstance.main.startLifetime.constantMax);
    }
}

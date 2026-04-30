using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private ParticleSystem burstFx;
    [SerializeField] private AudioSource coinSound;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (burstFx != null)
        {
            burstFx.transform.SetParent(null);
            burstFx.Play();
            Destroy(burstFx.gameObject, burstFx.main.duration
                                        + burstFx.main.startLifetime.constantMax);
        }
        
        AudioSource.PlayClipAtPoint(coinSound.clip, transform.position);
        
        GameManager.Instance.IncreaseCoinCount();
        Destroy(gameObject);
    }
}

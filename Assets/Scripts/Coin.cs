using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D()
    {
        GameManager.Instance.IncreaseCoinCount();
        Destroy(gameObject);
    }
}

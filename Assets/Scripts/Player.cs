using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _playerRb;

    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

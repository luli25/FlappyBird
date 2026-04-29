using System;
using UnityEngine;

public class Score : MonoBehaviour
{
    private void OnTriggerEnter2D()
    {
        GameManager.Instance.IncreaseScore();
    }
}

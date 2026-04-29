using UnityEngine;
using UnityEngine.PlayerLoop;

public class BackgroundRepeat : MonoBehaviour
{
    private float _spriteWidth;
    void Start()
    {
        BoxCollider2D groundCollider = GetComponent<BoxCollider2D>();
        _spriteWidth = groundCollider.size.x;
    }
    
    void Update()
    {
        if (transform.position.x < -_spriteWidth)
        {
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        transform.Translate(new Vector3(2 * _spriteWidth, 0, 0));
    }
}

using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    public event Action OnFlap;

    private Flap _flapControls; // Reference to player input system script

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        _flapControls = new Flap();
    }

    private void OnEnable()
    {
        _flapControls.Enable();
        _flapControls.Player.Flap.performed += HandleFlap;
    }

    private void OnDisable()
    {
        _flapControls.Player.Flap.performed -= HandleFlap;
        _flapControls.Disable();
    }

    private void HandleFlap(InputAction.CallbackContext context)
    {
        OnFlap?.Invoke();
    }
}

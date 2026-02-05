using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private PlayerInput _playerInput;
    public static event Action OnClick;

    void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();
        _playerInput.Player.Click.performed += ctx => OnClick?.Invoke();
    }
    
    void OnDestroy()
    {
        _playerInput.Disable();
    }
    
    
    
    
}

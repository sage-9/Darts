using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private PlayerInput _playerInput;
    public static event Action OnClick;
    public static event Action OnUIClick;

    void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.Enable();
        _playerInput.Player.Click.performed += ctx => OnClick?.Invoke();
        _playerInput.UI.Click.performed += ctx => OnUIClick?.Invoke();
    }

    public void ActivatePlayerInput()
    {
        _playerInput.Player.Enable();
    }

    public void ActivateUIInput()
    {
        _playerInput.UI.Enable();
    }

    public void DeactivateUIInput()
    {
        _playerInput.UI.Disable();
    }

    public void DeactivatePlayerInput()
    {
        _playerInput.Player.Disable();
    }
    
    void OnDestroy()
    {
        _playerInput.Disable();
    }
    
    
    
    
}

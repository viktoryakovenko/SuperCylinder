using System;
using UnityEngine;

public class GameplayInputManager: MonoBehaviour
{
    public event Action<Vector2> OnRotationInputReceived;
    public event Action<Vector2> OnMovementInputReceived;
    public event Action<bool> OnPickupInputReceived;

    private InputMap _gameInput;
    private KeyboardAndMouseInput _input;

    private void Awake() 
    {
        Cursor.lockState = CursorLockMode.Locked;

        _gameInput = new InputMap();
        _gameInput.Enable();      

        InitKeyboardAndMouseInput(_gameInput); 
    }

    private void OnEnable() 
    {
        _gameInput.Gameplay.Enable();
    }

    private void OnDisable()
    {
        _gameInput.Gameplay.Disable();
    }

    private void FixedUpdate()
    {
        ReceiveMovementInput();
    }

    private void InitKeyboardAndMouseInput(InputMap inputMap)
    {
        _input = new KeyboardAndMouseInput(inputMap);
        
        _input.OnRotationInputReceived += ReceiveRotationInput;
        _input.OnPickupInputReceived += ReceivePickupInput;
    }

    private void ReceiveRotationInput(Vector2 delta)
    {
        OnRotationInputReceived?.Invoke(delta);
    }

    private void ReceiveMovementInput()
    {
        var delta = _gameInput.Gameplay.Movement.ReadValue<Vector2>();
        OnMovementInputReceived?.Invoke(delta);
    }

    private void ReceivePickupInput(bool click)
    {
        OnPickupInputReceived?.Invoke(click);
    }
}
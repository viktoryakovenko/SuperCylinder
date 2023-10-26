using System;
using UnityEngine;

public class KeyboardAndMouseInput
{
    public event Action<Vector2> OnRotationInputReceived;
    public event Action<bool> OnPickupInputReceived;

    public KeyboardAndMouseInput(InputMap inputMap)
    {
        inputMap.Gameplay.Rotate.performed += context =>
        {
            var mouseDelta = context.ReadValue<Vector2>();

            OnRotationInputReceived?.Invoke(mouseDelta);
        };

        inputMap.Gameplay.PickUp.started += context =>
        {
            var leftButtonClick = context.ReadValueAsButton();
            
            Debug.Log(leftButtonClick);
            OnPickupInputReceived?.Invoke(leftButtonClick);
        };
    }
}

using System;
using UnityEngine;

public class KeyboardAndMouseInput
{
    public event Action<Vector2> OnRotationInputReceived;

    public KeyboardAndMouseInput(InputMap inputMap)
    {
        inputMap.Gameplay.Look.performed += context => 
        {
            var mouseDelta = context.ReadValue<Vector2>();

            OnRotationInputReceived?.Invoke(mouseDelta);
        };
    }
}

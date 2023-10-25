using System;
using UnityEngine;

public class CameraRotationHandler : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private float _sensitivity = 50f;
    [SerializeField] private GameplayInputManager _inputManager;
    [SerializeField] private Transform _rotationTarget;
    [SerializeField] private float _minVerticalAngle = -30f;
    [SerializeField] private float _maxVerticalAngle = 30f;


    private float _horizontal;
    private float _vertical;

    private void Start()
    {
        _inputManager.OnRotationInputReceived += OnRotationInputReceived;
    }

    private void OnDestroy()
    {
        _inputManager.OnRotationInputReceived -= OnRotationInputReceived;
    }

    private void OnRotationInputReceived(Vector2 delta)
    {
        var deltaTime = Time.deltaTime;

        _vertical -= _sensitivity * delta.y * deltaTime;
        _horizontal += _sensitivity * delta.x * deltaTime;

        gameObject.transform.eulerAngles = new Vector3(0f, _horizontal, 0f);

        _vertical = Mathf.Clamp(_vertical, _minVerticalAngle, _maxVerticalAngle);
        _rotationTarget.eulerAngles = new Vector3(_vertical, _horizontal, 0f);
    }
}

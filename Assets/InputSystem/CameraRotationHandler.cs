using System;
using UnityEngine;

public class CameraRotationHandler : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private float _sensitivity = 50f;
    [SerializeField] private GameplayInputManager _inputManager;
    [SerializeField] private Transform _rotationTarget;
    [SerializeField] private float _minVerticalAngle = -30f;
    [SerializeField] private float _maxVerticalAngle = 30f;
    [SerializeField] private float _raycastDistance = 1;


    private float _horizontal;
    private float _vertical;

    private void Start()
    {
        _inputManager.OnRotationInputReceived += Rotate;
        _inputManager.OnPickupInputReceived += OnPerformRaycast;
    }

    private void OnDestroy()
    {
        _inputManager.OnRotationInputReceived -= Rotate;
        _inputManager.OnPickupInputReceived += OnPerformRaycast;
    }

    private void Rotate(Vector2 delta)
    {
        var deltaTime = Time.deltaTime;

        _vertical -= _sensitivity * delta.y * deltaTime;
        _horizontal += _sensitivity * delta.x * deltaTime;

        gameObject.transform.eulerAngles = new Vector3(0f, _horizontal, 0f);

        _vertical = Mathf.Clamp(_vertical, _minVerticalAngle, _maxVerticalAngle);
        _rotationTarget.eulerAngles = new Vector3(_vertical, _horizontal, 0f);
    }

    private void OnPerformRaycast(bool clicked)
    {
        var direction = _rotationTarget.forward;
        var ray = new Ray(_rotationTarget.position, direction);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _raycastDistance))
        {
            var hitCollider = hitInfo.collider;

            if (hitCollider.TryGetComponent(out IPickable pickable))
            {
                pickable.PickUp();
            }
        }
    }
}

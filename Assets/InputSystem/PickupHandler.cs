using System;
using Mono.Reflection;
using UnityEngine;

public class PickupHandler : MonoBehaviour
{    
    [SerializeField] private float _raycastDistance = 2;
    [SerializeField] private GameplayInputManager _inputManager;
    
    private Canvas _messageCanvas;
    private IPickable _pickableObject;
    private Collider _hitCollider;

    private void Awake()
    {
        var prefab = Resources.Load("PickupMessage") as GameObject;
        var messageCanvas = prefab.GetComponent<Canvas>();
        _messageCanvas = Instantiate(messageCanvas, transform);
        _messageCanvas.worldCamera = Camera.main;

        HideMessage();
    }

    private void OnEnable()
    {
        _inputManager.OnPickupInputReceived += PerformPickup;
        
    }

    private void OnDisable()
    {
        _inputManager.OnPickupInputReceived -= PerformPickup;
        
    }

    private void FixedUpdate() 
    {
        PerformRaycast();
    }

    private void PerformPickup()
    {
        if (_pickableObject != null)
        {
            _pickableObject.Drop();
            _pickableObject = null;
            return;
        }
        
        if (_hitCollider != null && _hitCollider.TryGetComponent(out IPickable pickableObject))
        {
            _pickableObject = pickableObject;
            _pickableObject.PickUp();
        }
    }

    private void PerformRaycast()
    {
        var direction = transform.forward;
        var position = transform.position;

        if (Physics.Raycast(position, direction, out RaycastHit hitInfo, _raycastDistance) && _pickableObject == null)
        {
            _hitCollider = hitInfo.collider;
            if (_hitCollider.TryGetComponent(out IPickable pickable))
                ShowMessage();
        }
        else
        {
            _hitCollider = null;
            HideMessage();
        }
    }

    private void ShowMessage()
    {
        var messagePosition = _hitCollider.gameObject.transform.position;
        var scaleY = _hitCollider.gameObject.transform.localScale.y;
        messagePosition.y += scaleY/2f + 0.2f;

        _messageCanvas.gameObject.transform.position = messagePosition;
        _messageCanvas.gameObject.SetActive(true);
    }

    private void HideMessage()
    {
        _messageCanvas.gameObject.SetActive(false);
    }
}

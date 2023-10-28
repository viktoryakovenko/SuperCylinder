using UnityEngine;

public class PickupHandler : MonoBehaviour
{    
    [SerializeField] private float _raycastDistance = 2;
    [SerializeField] private GameplayInputManager _inputManager;
    
    private PickableObject _pickableObject;
    private Collider _hitCollider;

    private void Awake()
    {
        var prefab = Resources.Load("PickupMessage") as GameObject;
        var canvas = prefab.GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;
        canvas = Instantiate(canvas, transform);

        PickupMessage.Init(canvas);
        PickupMessage.Hide();
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
        
        if (_hitCollider != null && _hitCollider.TryGetComponent(out _pickableObject))
        {
            _pickableObject.PickUp(transform);
        }
    }

    private void PerformRaycast()
    {
        var direction = transform.forward;
        var position = transform.position;

        if (Physics.Raycast(position, direction, out RaycastHit hitInfo, _raycastDistance) && _pickableObject == null)
        {
            _hitCollider = hitInfo.collider;
            if (_hitCollider.TryGetComponent(out PickableObject pickable))
            {
                PickupMessage.Show(pickable.gameObject.transform);
            }
            else 
            {
                PickupMessage.Hide();
            }
        }
        else
        {
            _hitCollider = null; 
            PickupMessage.Hide();
        }
    }
}

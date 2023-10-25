using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    [SerializeField] private GameplayInputManager _inputManager;    
    [SerializeField] private GameObject _controllablePrefab;

    private IControllable _controllableObject;

    private void Awake()
    {
        _controllableObject = _controllablePrefab.GetComponent<IControllable>();
    }

    private void Start()
    {
        _inputManager.OnMovementInputReceived += OnMovementInputReceived;
    }

    private void OnDestroy()
    {
        _inputManager.OnMovementInputReceived -= OnMovementInputReceived;
    }

    private void OnMovementInputReceived(Vector2 vector)
    {
        var inputDirection = vector;
        var direction = new Vector3(inputDirection.x, 0f, inputDirection.y);

        _controllableObject.Move(direction);
    }
}

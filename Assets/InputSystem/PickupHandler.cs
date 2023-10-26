using UnityEngine;

public class PickupHandler : MonoBehaviour
{
    [SerializeField] private GameplayInputManager _inputManager;    

    private void Start()
    {
        _inputManager.OnPickupInputReceived += OnPickupInputReceived;
    }

    private void OnDestroy()
    {
        _inputManager.OnPickupInputReceived -= OnPickupInputReceived;
    }

    private void OnPickupInputReceived(bool click)
    {
        
    }
}

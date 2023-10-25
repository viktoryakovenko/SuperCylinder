using UnityEngine;

public class Player : MonoBehaviour, IControllable
{
    [SerializeField, Min(1)] private int _moveSpeed = 5;

    public int MoveSpeed => _moveSpeed;

    public void Move(Vector3 direction)
    {
        transform.position += transform.rotation * direction * _moveSpeed * Time.fixedDeltaTime;
    }
}

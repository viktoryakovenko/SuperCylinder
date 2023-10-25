using UnityEngine;

public interface IControllable 
{
    int MoveSpeed { get; }
    void Move(Vector3 direction);
}
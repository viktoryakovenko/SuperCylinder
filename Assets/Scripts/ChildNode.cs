using UnityEngine;

public abstract class ChildNode : MonoBehaviour 
{
    public Collider Parent { get; protected set; }
}

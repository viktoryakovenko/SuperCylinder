using UnityEngine;

namespace SuperCylinder
{
    [RequireComponent(typeof(SphereCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Sphere: ChildNode
    {
        private void OnCollisionEnter(Collision other) 
        {
            if (other.collider.GetComponent<Cube>()) 
            {
                Parent = other.collider;
            }
        }
    }
}
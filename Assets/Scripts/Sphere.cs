using System;
using UnityEngine;

namespace SuperCylinder
{
    public class Sphere : MonoBehaviour, IPickable
    {
        public void PickUp()
        {
            Debug.Log("Sphere picked up");
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        }

        public void Drop()
        {
            Debug.Log("Sphere dropped");
            gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }
}
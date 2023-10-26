using UnityEngine;

namespace SuperCylinder
{
    public class Sphere : MonoBehaviour, IPickable
    {
        public void PickUp()
        {
            Debug.Log("sphere");
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }
}